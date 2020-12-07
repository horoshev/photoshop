using Photoshop.Core;
using Photoshop.Filters.Parameters;

namespace Photoshop.Filters
{
    public interface IFilter
    {
        string Name { get; set; }
        ParameterInfoAttribute[] GetParameters();
        Photo Process(Photo photo, double[] values);
    }
}