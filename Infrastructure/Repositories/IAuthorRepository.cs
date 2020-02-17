using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IAuthorRepository
    {
        Task<ICollection<Author>> GetAllAsync();
    }
}
