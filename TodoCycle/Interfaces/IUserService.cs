using TodoCycle.Models;

namespace TodoCycle.Interfaces
{
    public interface IUserService
    {
        User Get(int id);
        User Get(string userName);
    }
}
