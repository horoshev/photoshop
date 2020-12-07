using System;

namespace Photoshop.Filters.Parameters
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterInfoAttribute : Attribute
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public double DefaultValue { get; set; } = 10;
        public double MinValue { get; set; } = 0;
        public double MaxValue { get; set; } = 100;
        public double StepValue { get; set; } = .1;
    }
}