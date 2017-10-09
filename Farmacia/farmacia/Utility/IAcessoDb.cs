using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Utility
{
    public interface IAcessoDb<T>
    {
        List<T> GetUsuarios();
        T GetUsuarioPorLoginSenha(T registro);
        T GetUsuarioPorId(int id);
    }
}
