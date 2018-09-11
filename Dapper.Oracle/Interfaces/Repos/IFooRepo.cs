using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper.Oracle.Entities;

namespace Dapper.Oracle.Interfaces.Repos
{
    public interface IFooRepo
    {
        Task<Foo> GetFoo(int fooId);
        Task<IEnumerable<Foo>> GetFoos();
    }
}
