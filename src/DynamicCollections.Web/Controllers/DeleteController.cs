using System.Collections.Generic;
using System.Web.Mvc;
using DgonDotNet.Blog.Samples.DynamicCollections.Domain;
using DgonDotNet.Blog.Samples.DynamicCollections.Models;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Controllers
{
	public class DeleteController : DiscardController<DeleteViewModel>
	{
		private readonly IThingRepository _repository;

		public DeleteController(IThingRepository repository)
		{
			_repository = repository;
		}

		public ActionResult Index()
		{
			IEnumerable<Thing> things = _repository.Find();
			var model = new DeleteViewModel
			{
				Things = DeletableThing.FromThings(things)
			};

			return View(model);
		}

		[HttpPost]
		public override ActionResult Index(string save, string discard, DeleteViewModel posted)
		{
			if (isSave(save, discard))
			{
				_repository.Save(DeletableThing.ToThings(posted.Things));
			}

			IEnumerable<Thing> updatedThings = _repository.Find();
			var model = new DeleteViewModel
			{
				Things = DeletableThing.FromThings(updatedThings)
			};
			return View(model);
		}
	}
}