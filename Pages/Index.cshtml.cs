using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationManager _manager;

        // BindProperties für das Formular
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Content { get; set; }
        [BindProperty]
        public string TagsString { get; set; }

        public IndexModel(ApplicationManager manager)
        {
            _manager = manager;
        }

        public List<ToDoPost> AllToDoPosts { get; private set; }
        public List<Category> AllCategories { get; private set; }

        public void OnGet()
        {
            AllToDoPosts = _manager.GetAllToDoPosts();
            AllCategories = _manager.GetAllCategories();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            var newToDo = new ToDoPost
            {
                Title = this.Title,
                Content = this.Content,
                CreateDate = DateTime.Now,
                TagsString = this.TagsString
            };

            _manager.AddToDoPost(newToDo);

            return RedirectToPage("Index");
        }

        public string getCategoryImage(string categoryName)
        {
            return $"Images/{categoryName}.png";
        }
        
    }
}
