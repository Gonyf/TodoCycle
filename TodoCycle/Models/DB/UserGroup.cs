using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoCycle.Models.DB
{
	public class UserGroup
	{
		public int Id { get; set; }
		public IEnumerable<User> UsersInGroup { get; set; }

	}
}
