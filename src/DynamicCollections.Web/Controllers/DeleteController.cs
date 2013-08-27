using System.Collections.Generic;
using System.Web.Mvc;
using DgonDotNet.Blog.Samples.DynamicCollections.Domain;
using DgonDotNet.Blog.Samples.DynamicCollections.Models;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Controllers
{
	public class DeleteController : Controller
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
	}
}