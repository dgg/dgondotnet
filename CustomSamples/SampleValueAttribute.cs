using AutoFixture.Kernel;
using System;
using System.Reflection;

namespace SwaggerSamples.CustomSamples
{
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class SampleValueAttribute : Attribute
	{
		public SampleValueAttribute(object value)
		{
			Value = value;
		}

		public object Value { get; }

		private object AssignableValue(PropertyInfo property)
		{
			object assignableValue = Value;

			if (Value != null && !property.PropertyType.IsAssignableFrom(Value.GetType()))
			{
				assignableValue = Convert.ChangeType(Value, property.PropertyType);
			}
			return assignableValue;
		}

		public class SpecimenBuilder : ISpecimenBuilder
		{
			public object Create(object request, ISpecimenContext context)
			{
				object result = new NoSpecimen();
				PropertyInfo property = request as PropertyInfo;
				if (property != null)
				{
					var attribute = property.GetCustomAttribute<SampleValueAttribute>();
					if (attribute != null)
					{
						result = attribute.AssignableValue(property);
					}
				}
				return result;
			}
		}
	}
}
