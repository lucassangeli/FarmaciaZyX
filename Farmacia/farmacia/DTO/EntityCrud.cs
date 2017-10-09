using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia
{
    public interface EntityCrud<T>
    {
        bool Insert(T item);
        bool Update(T item);
        bool Delete(T item);
        T GetById(int id);
        List<T> GetAll();
        T getByNome(string nome);
    }
}
