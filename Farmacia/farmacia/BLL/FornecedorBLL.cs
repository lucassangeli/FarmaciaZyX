using Farmacia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.BLL
{
    public class FornecedorBLL : BaseValidator<Fornecedor>, EntityCrud<Fornecedor>
    {
        public override bool Validate(Fornecedor item)
        {
            bool b = true;
            if (string.IsNullOrWhiteSpace(item.CNPJ))
            {
                AddError("O CNPJ deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsCNPJ(item.CNPJ))
            {
                AddError("O CNPJ não é válido.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.RazaoSocial))
            {
                AddError("A razão social deve ser informada.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(3, 50, item.Nome))
            {
                AddError("A razão social deve conter entre 3 e 50 caracteres.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                AddError("O nome deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(1, 60, item.Nome))
            {
                AddError("O nome deve conter entre 1 e 30 caracteres.");
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

            if (string.IsNullOrWhiteSpace(item.Contato))
            {
                AddError("O contato deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(1, 50, item.Contato))
            {
                AddError("O contato deve conter entre 1 e 50 caracteres.");
                b = false;
            }

            if (item.ativo != 1 && item.ativo != 0)
            {
                AddError("O fornecedor pode ser apenas ativo (1) ou inativo (0).");
                b = false;
            }

            base.Validate(item);
            return b;
        }

        public bool Insert(Fornecedor item)
        {
            if (Validate(item))
                return (new FornecedorDao().Insert(item));
            return false;
        }

        public bool Update(Fornecedor item)
        {
            if (Validate(item))
                return (new FornecedorDao().Update(item));
            return false;
        }

        public bool Delete(Fornecedor item)
        {
            return (new FornecedorDao().Delete(item));
        }

        public Fornecedor GetById(int id)
        {
            Fornecedor entrada = new FornecedorDao().GetById(id);
            if (entrada == null)
            {
                throw new Exception("Fornecedor não encontrado!");
            }
            return entrada;
        }

        public List<Fornecedor> GetAll()
        {
            return new FornecedorDao().GetAll();
        }

        public Fornecedor getByNome(string nome)
        {
            Fornecedor fornecedor = new FornecedorDao().getByNome(nome);
            if (fornecedor == null)
            {
                throw new Exception("Fornecedor não encontrado!");
            }
            return fornecedor;
        }
    }
}
