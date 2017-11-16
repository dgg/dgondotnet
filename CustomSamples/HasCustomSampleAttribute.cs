using AutoFixture;
using AutoFixture.Kernel;
using System;
using System.Reflection;

namespace SwaggerSamples.CustomSamples
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class HasCustomSampleAttribute : Attribute
	{
		private static readonly IFixture _fixture;
		private static readonly MethodInfo _nonGenericCreation;
		static HasCustomSampleAttribute()
		{
			_fixture = new Fixture();
			_fixture.Customizations.Add(new SampleValueAttribute.SpecimenBuilder());
			_fixture.Customizations.Add(new SampleValuesAttribute.SpecimenBuilder());

			_nonGenericCreation = typeof(SpecimenFactory).GetMethod(
				nameof(SpecimenFactory.Create),
				BindingFlags.Static | BindingFlags.Public,
				null,
				new[] { typeof(ISpecimenBuilder) },
				null);
		}

		internal object BuildExample(Type type)
		{
			// there is no non-generic _fixture.Create<>()
			// encapsulated reflection-fu to the rescue
			MethodInfo genericCreation = _nonGenericCreation.MakeGenericMethod(type);
			object example = genericCreation.Invoke(null, new[] { _fixture });
			return example;
		}

		public static bool Decorates(Type type, out HasCustomSampleAttribute attribute)
		{
			MemberInfo mi = type;
			attribute = type.GetCustomAttribute<HasCustomSampleAttribute>();
			return attribute != null;
		}
	}
}
