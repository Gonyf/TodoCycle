using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoCycle.Interfaces;
using TodoCycle.Models.DB;
using TodoCycle.Models.DB.Contexts;

namespace TodoCycle.Repositories
{
	public class TodoListRepository : ITodoListRepository
	{
		private DataContext _context { get; set; }
		private DbSet<TodoList> _todoLists => _context.TodoLists;

		public TodoListRepository(DataContext dataContext)
		{
			_context = dataContext;
		}

		public void Add(TodoList todoList)
		{
			_todoLists.Add(todoList);
			_context.SaveChanges();
		}

		public void Delete(int listId)
		{
			var list = _todoLists.SingleOrDefault(l => l.Id == listId);
			_todoLists.Remove(list);
			_context.SaveChanges();
		}

		public TodoList Get(int listId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TodoList> List(string userName)
		{
			throw new NotImplementedException();
		}

		public void Update(TodoList todoList)
		{
			throw new NotImplementedException();
		}
	}
}
