namespace DgonDotNet.Blog.Samples.DynamicCollections.Models
{
	public interface IClientDeletable
	{
		// flag for client-side deletes. The row cannot be delted altogether from the DOM 
		// as doing so leaves gaps in the collection posted and the binder does not bind beyond the gap
		bool ClientDeleted { get; set; }
	}
}