using Microsoft.AspNetCore.Mvc.RazorPages;
using TP3.Models;

namespace TP3.Repositories
{
    public interface IBaseRepository<TDbModel> where TDbModel : Base
    {
        public List<TDbModel> GetAll();
        public TDbModel Get(Guid id);
        public TDbModel Create(TDbModel model);
        public TDbModel Update(TDbModel model);
        public void Delete(Guid id);
    }
}
