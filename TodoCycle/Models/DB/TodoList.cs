using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoCycle.Models.DB
{
	public class TodoList
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<TodoItem> TodoItems { get; set; }
		public IEnumerable<User> Users { get; set; }
		public IEnumerable<UserGroup> UserGroups { get; set; }
		public IEnumerable<User> AllUsersWithAccess => UserGroups.SelectMany(ug => ug.UsersInGroup).Union(Users);
	}
}
