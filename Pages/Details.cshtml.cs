using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationManager _manager;

        public ToDoPost toDoToShow;

        public DetailsModel(ApplicationManager manager)
        {
            _manager = manager;
        }

        public void OnGet(int id)
        {
            if (id > 0)
            {
                toDoToShow = _manager.GetToDoPostById(id);
            }
            else
            {
                RedirectToPage("Index");
            }
        }
    }
}
