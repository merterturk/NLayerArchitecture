using NLayerProject.Core.Models;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        //Category özgü methodlar burda tanımlanır.
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
