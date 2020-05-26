using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoCycle.Interfaces;
using TodoCycle.Models.DB;
using TodoCycle.Models.DB.Contexts;
using System.Linq;

namespace TodoCycle.Repositories
{
	public class TodoItemRepository : ITodoItemRepository
	{
		private DataContext _context { get; set; }
		private DbSet<TodoItem> _todoItems => _context.TodoItems;

		public TodoItemRepository(DataContext dataContext)
		{
			_context = dataContext;
		}

		public void Update(TodoItem TodoItem)
		{
			_todoItems.Update(TodoItem);
			_context.SaveChanges();
		}

		public void Delete(int itemId)
		{
			var item = _todoItems.SingleOrDefault(i => i.Id == itemId);
			_todoItems.Remove(item);
			_context.SaveChanges();
		}
	}
}
