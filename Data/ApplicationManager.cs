using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestApp.Models;

namespace TestApp.Data
{
	public class ApplicationManager
	{
		private readonly ApplicationDbContext _context;

		public ApplicationManager(ApplicationDbContext context) 
		{ 
			_context = context;
		}

		// Abrufen aller Posts
		public List<ToDoPost> GetAllToDoPosts()
		{
			return _context.ToDoPosts.ToList();
		}

		public List<Category> GetAllCategories()
		{
			return _context.Categories.ToList();
		}

		// Abrufen aller Posts einer Kategorie
		public List<ToDoPost> GetAllPostsByCategorie(int categorieId)
		{
			return _context.ToDoPosts.Where(post => post.CategoryId == categorieId).ToList();
		}

		// Abrufen einzelner Posts anhand der ID
		public ToDoPost GetToDoPostById(int id)
		{
			return _context.ToDoPosts.FirstOrDefault(post => post.Id == id);
		}

		// Hinzufügen eines neuen Posts
		public void AddToDoPost (ToDoPost toDoPost) 
		{
			toDoPost.TagsString = string.Join(",", toDoPost.Tags);

			_context.ToDoPosts.Add(toDoPost);
			_context.SaveChanges();
		}

		// Aktualisieren eines vorhandenen Posts
		public void UpdateToDoPost (ToDoPost updatedPost)
		{
			updatedPost.TagsString = string.Join(",", updatedPost.Tags);
			
			_context.ToDoPosts.Update(updatedPost);
		}

		// Löschen eines vorhandenen Posts
		public void DeleteToDoPost(int id) 
		{
			var postToDelete = _context.ToDoPosts.FirstOrDefault(post => post.Id == id);
			if (postToDelete != null) 
			{
				_context.ToDoPosts.Remove(postToDelete);
				_context.SaveChanges();
			}
		}
	}
}
