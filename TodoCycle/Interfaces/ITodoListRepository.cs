using System.Collections.Generic;
using TodoCycle.Models.DB;

namespace TodoCycle.Interfaces
{
	public interface ITodoListRepository
	{
		TodoList Get(int listId);
		IEnumerable<TodoList> List(string userName);
		void Update(TodoList todoList);
		void Add(TodoList todoList);
		void Delete(int listId);
	}
}