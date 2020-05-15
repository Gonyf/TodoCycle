using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoCycle.Models;

namespace TodoCycle.Interfaces
{
    public interface ICurrentUserResolver
    {
        User Get();
    }
}
