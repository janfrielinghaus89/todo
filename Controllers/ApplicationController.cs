using Microsoft.AspNetCore.Mvc;
using TestApp.Models;
using TestApp.Data;

namespace TestApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ApplicationController : Controller
	{
		private readonly ApplicationManager _manager;

		public ApplicationController(ApplicationManager manager)
		{
			_manager = manager;
		}

		[HttpGet("todos")]
		public IActionResult GetAllToDos()
		{
			var allToDoPosts = _manager.GetAllToDoPosts();
			return Ok(allToDoPosts);
		}

		[HttpGet("categories")]
		public IActionResult GetAllCategories()
		{
			var allCategories = _manager.GetAllCategories();
			return Ok(allCategories);
		}
	}
}
