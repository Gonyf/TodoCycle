using System.Collections.Generic;
using TodoCycle.Models.DB;

namespace TodoCycle.Interfaces
{
	public interface ITodoItemRepository
	{
		void Update(TodoItem todoItem);
		void Delete(int itemId);
	}
}