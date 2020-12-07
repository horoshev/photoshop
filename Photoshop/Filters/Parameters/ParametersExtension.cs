using System.Linq;
using System.Reflection;

namespace Photoshop.Filters.Parameters
{
    public static class ParametersExtension
    {
        /*public static ParameterInfoAttribute[] GetDescription(this IParameters parameters)
        {
            return parameters
                .GetType()
                .GetProperties()
                .Select(info => info.GetCustomAttribute(typeof(ParameterInfoAttribute)))
                .Where(attribute => attribute is not null)
                .Cast<ParameterInfoAttribute>()
                .ToArray();
        }

        public static void SetValues(this IParameters parameters, double[] values)
        {
            return parameters
                .GetType()
                .GetProperties()
                .Select(info => info.GetCustomAttribute(typeof(ParameterInfoAttribute)))
                .Where(attribute => attribute is not null)
                .Cast<ParameterInfoAttribute>()
                .ToArray();
        }*/
    }
}