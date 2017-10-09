using Farmacia.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.BLL
{
    public class ClienteBLL : BaseValidator<Cliente>, EntityCrud<Cliente>
    {
        public override bool Validate(Cliente item)
        {
            bool b = true;

            if (string.IsNullOrWhiteSpace(item.CPF))
            {
                AddError("O CPF deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsCPF(item.CPF))
            {
                AddError("O CPF não é válido.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.RG))
            {
                AddError("O RG deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsRG(item.RG))
            {
                AddError("O RG não é válido.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                AddError("O nome deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(1, 60, item.Nome))
            {
                AddError("O nome deve ter entre 1 e 60 caracteres.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.Telefone))
            {
                AddError("O telefone deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(8, 15, item.Telefone))
            {
                AddError("O telefone deve conter entre 8 e 15 caracteres.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.Email))
            {
                AddError("O email deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(10, 50, item.Email))
            {
                AddError("O email deve conter entre 10 e 50 caracteres.");
                b = false;
            }
            else if (!CommonValidations.IsEmail(item.Email))
            {
                AddError("O email está inválido.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.Celular))
            {
                AddError("O celular deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(8, 15, item.Celular))
            {
                AddError("O celular deve conter entre 8 e 15 caracteres.");
                b = false;
            }

            if (item.Pontos < 0)
            {
                AddError("Os pontos não podem ser negativos.");
                b = false;
            }

            base.Validate(item);
            return b;
        }

        public bool Insert(Cliente item)
        {
            if (Validate(item))
                return (new ClienteDao().Insert(item));
            return false;
        }

        public bool Update(Cliente item)
        {
            if (Validate(item))
                return (new ClienteDao().Update(item));
            return false;
        }

        public bool Delete(Cliente item)
        {
            return (new ClienteDao().Delete(item));
        }

        public Cliente GetById(int id)
        {
            Cliente cliente = new ClienteDao().GetById(id);
            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado!");
            }
            return cliente;
        }

        public List<Cliente> GetAll()
        {
            return new ClienteDao().GetAll();
        }

        public Cliente getByNome(string nome)
        {
            Cliente cliente = new ClienteDao().getByNome(nome);
            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado!");
            }
            return cliente;
        }
    }
}
