using SwaggerSamples.Messages;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerSamples
{
	internal class SampleFilter : ISchemaFilter
	{
		public void Apply(Schema model, SchemaFilterContext context)
		{
			if (context.SystemType == typeof(OneRequest))
			{
				model.Example = new { A = "B", B = "C" };
			}
		}
	}
}