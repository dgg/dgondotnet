using System.Collections.Generic;
using System.Web.Mvc;
using DgonDotNet.Blog.Samples.DynamicCollections.Domain;
using DgonDotNet.Blog.Samples.DynamicCollections.Models;
using DgonDotNet.Blog.Samples.DynamicCollections.Views;

namespace DgonDotNet.Blog.Samples.DynamicCollections.Controllers
{
	public class SortController : Controller
	{
		private readonly IThingRepository _repository;

		public SortController(IThingRepository repository)
		{
			_repository = repository;
		}

		public ActionResult Index()
		{
			IEnumerable<Thing> things = _repository.Find();
			var model = new SortViewModel
			{
				Things = SortableThing.FromThings(things)
			};

			return View(model);
		}

		[HttpPost]
		public ActionResult Index(string save, string discard, SortViewModel posted)
		{
			if (isSave(save, discard))
			{
				_repository.Save(SortableThing.ToThings(posted.Things));
			}

			IEnumerable<Thing> updatedThings = _repository.Find();
			var model = new SortViewModel
			{
				Things = SortableThing.FromThings(updatedThings)
			};
			return View(model);
		}

		private bool isSave(string save, string discard)
		{
			return !string.IsNullOrEmpty(save) && string.IsNullOrEmpty(discard);
		}
	}
}