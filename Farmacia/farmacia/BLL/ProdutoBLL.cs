using Farmacia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.BLL
{
    public class ProdutoBLL : BaseValidator<Produto>, EntityCrud<Produto>
    {
        public override bool Validate(Produto item)
        {
            bool b = true;
            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                AddError("O nome deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(1, 50, item.Nome))
            {
                AddError("O nome deve ter entre 1 e 50 caracteres.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.Descricao))
            {
                AddError("A descrição deve ser informada.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(1, 50, item.Descricao))
            {
                AddError("A descrição deve ter entre 1 e 50 caracteres.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.Laboratorio))
            {
                AddError("O laboratório deve ser informado.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(1, 50, item.Laboratorio))
            {
                AddError("O laboratório deve ter entre 1 e 50 caracteres.");
                b = false;
            }

            if (item.Quantidade <= 0)
            {
                AddError("A quantidade não pode ser menor ou igual a zero.");
                b = false;
            }

            if (item.ValorVenda <= 0)
            {
                AddError("O valor de venda não pode ser menor ou igual a zero.");
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

        public bool Insert(Produto item)
        {
            if (Validate(item))
                return (new ProdutoDao().Insert(item));
            return false;
        }

        public bool Update(Produto item)
        {
            if (Validate(item))
                return (new ProdutoDao().Update(item));
            return false;
        }

        public bool Delete(Produto item)
        {
            return (new ProdutoDao().Delete(item));
        }

        public Produto GetById(int id)
        {
            Produto produto = new ProdutoDao().GetById(id);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado!");
            }
            return produto;
        }

        public List<Produto> GetAll()
        {
            return new ProdutoDao().GetAll();
        }

        public Produto getByNome(string nome)
        {
            Produto produto = new ProdutoDao().getByNome(nome);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado!");
            }
            return produto;
        }
    }
}
