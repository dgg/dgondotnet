namespace DgonDotNet.Blog.Samples.DynamicCollections.Views
{
	public interface IClientSortable
	{
		// index set client-side to sort the collection once is posted back
		int ClientOrder { get; set; }
	}
}