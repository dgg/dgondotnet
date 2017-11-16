using AutoFixture.Kernel;
using System;
using System.Reflection;

namespace SwaggerSamples.CustomSamples
{
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class SampleValuesAttribute : Attribute
	{
		public SampleValuesAttribute(params object[] values)
		{
			Values = values;
		}

		public object[] Values { get; }

		public class SpecimenBuilder : ISpecimenBuilder
		{
			public object Create(object request, ISpecimenContext context)
			{
				object result = new NoSpecimen();
				PropertyInfo property = request as PropertyInfo;
				if (property != null)
				{
					var attribute = property.GetCustomAttribute<SampleValuesAttribute>();
					if (attribute != null)
					{
						assertArray(property);
						
						Array array = Array.CreateInstance(property.PropertyType.GetElementType(), attribute.Values.Length);
						Array.Copy(attribute.Values, array, attribute.Values.Length);
						result = array;
					}
				}
				return result;
			}

			private void assertArray(PropertyInfo property)
			{
				if (!property.PropertyType.IsArray)
				{
					throw new NotSupportedException("collection properties must be arrays");
				}
			}
		}
	}
}
