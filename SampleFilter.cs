using SwaggerSamples.CustomSamples;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerSamples
{
	internal class SampleFilter : ISchemaFilter
	{
		public void Apply(Schema model, SchemaFilterContext context)
		{
			if (HasCustomSampleAttribute.Decorates(context.SystemType, out HasCustomSampleAttribute attribute))
			{
				model.Example = attribute.BuildExample(context.SystemType);
			}
		}
	}
}