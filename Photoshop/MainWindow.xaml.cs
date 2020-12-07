using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Photoshop.Core;
using Photoshop.Filters;
using Photoshop.Filters.Parameters;
using Photoshop.ML;
using Photoshop.ML.Activation;

namespace Photoshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private bool _isSourceImageVisible = true;
        private bool _isRowHeightAuto = false;
        private string _imagePath = "Resources/cat.jpg";
        private List<IFilter> _filters = Enumerable.Empty<IFilter>().ToList();

        public bool IsHeightAuto
        {
            get => _isRowHeightAuto;
            set
            {
                _isRowHeightAuto = value;
                OnPropertyChanged(nameof(IsHeightAuto));
            }
        }

        public string ImagePath
        {
            get => _imagePath;
            private set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public BitmapImage Bitmap { get; set; }

        public List<IFilter> Filters
        {
            get => _filters;
            private set
            {
                _filters = value;
                OnPropertyChanged(nameof(Filters));
            }
        }

        public Visibility ParametersVisibility => FiltersParameters.Items.Count == 0 ? Visibility.Hidden : Visibility.Visible;

        public bool IsSourceImageVisible
        {
            get => _isSourceImageVisible;
            set
            {
                _isSourceImageVisible = value;
                OnPropertyChanged(nameof(IsSourceImageVisible));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // Window Size
            Height = 720;
            Width = 1280;

            // Filters
            FiltersComboBox.DisplayMemberPath = nameof(IFilter.Name);
            FiltersComboBox.Items.Add(new CannyEdgeFilter {Name = "Canny"});
            FiltersComboBox.Items.Add(new ConvolutionFilter3x3<ConvolutionMatrix3x3Parameter> {Name = "Custom Filter"});
            FiltersComboBox.Items.Add(new ConvolutionFilter3x3<GaussianBlurParameter> {Name = "Gaussian Blur"});
            FiltersComboBox.Items.Add(new ConvolutionFilter3x3<BoxBlurParameter> {Name = "Box Blur"});
            FiltersComboBox.Items.Add(new ConvolutionFilter3x3<EdgeDetectionParameter> {Name = "Edge Detection"});
            FiltersComboBox.Items.Add(new ConvolutionFilter3x3<Sharpen5Parameter> {Name = "Sharpen 5"});
            FiltersComboBox.Items.Add(new ConvolutionFilter3x3<Sharpen9Parameter> {Name = "Sharpen 9"});
            FiltersComboBox.Items.Add(new ConvolutionFilter3x3<EmbossParameter> {Name = "Emboss"});
            FiltersComboBox.Items.Add(new ConvolutionFilter3x3<KhoroshevBlurParameter> {Name = "Khoroshev Blur"});

            // Open Default Image
            if (Resources["DefaultImage"] is BitmapImage bitmap)
            {
                Bitmap = bitmap;
            }
        }

        private void OnOpenImage(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() is true)
            {
                ImagePath = fileDialog.FileName;
                Bitmap = new BitmapImage(new Uri(ImagePath));
                SourceImage.Source = Bitmap;
            }
        }

        private void OnSaveImage(object sender, RoutedEventArgs e)
        {
            var fileDialog = new SaveFileDialog();

            if (fileDialog.ShowDialog() is true)
            {
                using var file = fileDialog.OpenFile();
                var encoder = new JpegBitmapEncoder();
                var frame = BitmapFrame.Create(SourceImage.Source as WriteableBitmap);
                encoder.Frames.Add(frame);
                encoder.Save(file);
            }
        }

        private void OnFilterChanged(object sender, RoutedEventArgs e)
        {
            CreateFilterControls();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnApplyButtonClick(object sender, RoutedEventArgs e)
        {
            if (!(FiltersComboBox.SelectedItem is IFilter filter)) return;

            var values = new List<double>();
            foreach (var parameter in FiltersParameters.Items)
            {
                if (parameter is ParameterInfoAttribute parameterInfo)
                {
                    values.Add(parameterInfo.Value);
                }
            }

            var photo = ImageConverter.Bitmap2Photo(Bitmap);
            if (photo is not null)
            {
                var processedPhoto = filter.Process(photo, values.ToArray());
                var bitmap = ImageConverter.Photo2Bitmap(processedPhoto);

                ProcessedImage.Source = bitmap;
            }
        }

        private void OnResetButtonClick(object sender, RoutedEventArgs e)
        {
            CreateFilterControls();
        }

        private void OnTestButtonClick(object sender, RoutedEventArgs e)
        {
            var layer = new NeuronsLayer<SigmoidActivation>(4, 2, new SigmoidActivation(0.7));
            var network = NeuralNetwork.Build(4)
                .Add(layer)
                .Compile();

            var output = network.Predict(new [,] {{.0, 1, 2, 3}});

            Console.WriteLine(output);
        }

        private void CreateFilterControls()
        {
            if (!(FiltersComboBox.SelectedItem is IFilter filter)) return;

            FiltersParameters.Items.Clear();

            var parameters = filter.GetParameters();
            foreach (var parameter in parameters)
            {
                FiltersParameters.Items.Add(parameter);
            }

            OnPropertyChanged(nameof(ParametersVisibility));
        }
    }
}