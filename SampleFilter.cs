using AutoFixture;
using SwaggerSamples.Messages;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerSamples
{
	internal class SampleFilter : ISchemaFilter
	{
		private static readonly Fixture _fixture = new Fixture();

		public void Apply(Schema model, SchemaFilterContext context)
		{
			if (context.SystemType == typeof(OneRequest))
			{
				model.Example = _fixture.Create<OneRequest>();
			}
		}
	}
}