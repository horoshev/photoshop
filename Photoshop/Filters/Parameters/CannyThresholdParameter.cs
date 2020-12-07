namespace Photoshop.Filters.Parameters
{
    public class CannyThresholdParameter : IParameters
    {
        [ParameterInfo(Name = "Нижнее пороговое значение", DefaultValue = 50)]
        public double ThresholdMin { get; set; }

        [ParameterInfo(Name = "Верхнее пороговое значение", DefaultValue = 200)]
        public double ThresholdMax { get; set; }
    }
}