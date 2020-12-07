using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Photoshop.Filters.Parameters
{
    public class ParametersHandler<TParams> where TParams : new()
    {
        private static PropertyInfo[] _properties;
        private static ParameterInfoAttribute[] _parameters;

        static ParametersHandler()
        {
            _properties = typeof(TParams)
                    .GetProperties()
                    .Where(info => info.GetCustomAttribute(typeof(ParameterInfoAttribute)) is not null)
                    .ToArray();

            _parameters = typeof(TParams)
                .GetProperties()
                .Select(info => info.GetCustomAttribute(typeof(ParameterInfoAttribute)))
                .Where(attribute => attribute is not null)
                .Cast<ParameterInfoAttribute>()
                .Select(attribute =>
                {
                    attribute.Value = attribute.DefaultValue;

                    return attribute;
                })
                .ToArray();
        }

        public ParameterInfoAttribute[] GetDescription()
        {
            return _parameters;
        }

        public TParams CreateParameters(ICollection<double> values)
        {
            if (_properties.Length != values.Count)
                throw new ArgumentException(nameof(values));

            var parameters = new TParams();

            foreach (var (property, value) in _properties.Zip(values))
            {
                property.SetValue(parameters, value);
            }

            return parameters;
        }
    }
}