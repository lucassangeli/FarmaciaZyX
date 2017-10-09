using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Utility
{
    public static class StaticUser
    {
        public static int Id { get; set; }
        public static string Email { get; set; }
        public static string Senha { get; set; }
        public static bool Administrador { get; set; }
    }
}
