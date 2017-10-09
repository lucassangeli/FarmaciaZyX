using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.BLL
{
    public class BaseValidator<T>
    {
        private StringBuilder erros = new StringBuilder();

        public virtual bool Validate(T item)
        {
            CheckErrors();
            return true;
        }

        protected void AddError(string error)
        {
            erros.AppendLine(error);
        }

        private void CheckErrors()
        {
            string temp = erros.ToString();
            erros.Clear();
            if (temp.Length > 0)
            {
                throw new Exception(temp);
            }
        }
    }
}
