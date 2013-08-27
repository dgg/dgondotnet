using System.Collections.Generic;
using System.Web.Mvc;
using DgonDotNet.Blog.Samples.DynamicCollections.Domain;
using DgonDotNet.Blog.Samples.DynamicCollections.Models;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Controllers
{
	public class AddController : DiscardController<AddViewModel>
	{
		private readonly IThingRepository _repository;

		public AddController(IThingRepository repository)
		{
			_repository = repository;
		}

		public ActionResult Index()
		{
			IEnumerable<Thing> things = _repository.Find();
			var model = new AddViewModel
			{
				Things = AddableThing.FromThings(things)
			};
			return View(model);
		}

		[HttpPost]
		public override ActionResult Index(string save, string cancel, AddViewModel posted)
		{
			return View();
		}
	}
}