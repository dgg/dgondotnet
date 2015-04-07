namespace DgonDotNet.Blog.Samples.ProgressiveInnerClosure
{
	public class EntityDto
	{
		public EntityDto(string id, string name, string creationDate, string url)
		{
			Id = id;
			Name = name;
			CreationDate = creationDate;
			Url = url;
		}

		public string Id { get; private set; }
		public string Name { get; private set; }
		public string CreationDate { get; private set; }
		public string Url { get; private set; }
	}
}
