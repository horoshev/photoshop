using Photoshop.Core;
using Photoshop.Filters.Parameters;

namespace Photoshop.Filters
{
    public abstract class ParametrizedFilter<TParam> : IFilter where TParam : IParameters, new()
    {
        private readonly ParametersHandler<TParam> _handler = new ParametersHandler<TParam>();

        public string Name { get; set; }

        public ParameterInfoAttribute[] GetParameters()
        {
            return _handler.GetDescription();
        }

        public Photo Process(Photo photo, double[] values)
        {
            return Process(photo, _handler.CreateParameters(values));
        }

        public abstract Photo? Process(Photo photo, TParam parameters);
    }
}