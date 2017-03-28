using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.DataModel.Repositories
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        IReadOnlyList<TModel> GetAll();

        TModel Get(int id);

        TModel Insert(TModel item);

        TModel Update(TModel item);

        void Delete(int id);
    }
}
