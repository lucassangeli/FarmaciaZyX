using Farmacia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.BLL
{
    public class ItemVendaBLL : BaseValidator<ItemVenda>, EntityCrud<ItemVenda>
    {
        public override bool Validate(ItemVenda item)
        {
            bool b = true;
            if (item.IdProduto < 0)
            {
                AddError("O Id do produto não pode ser menor que zero.");
                b = false;
            }

            if (item.IdVenda < 0)
            {
                AddError("O Id de venda não pode ser menor que zero.");
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

            base.Validate(item);
            return b;
        }

        public bool Insert(ItemVenda item)
        {
            if (Validate(item))
                return (new ItemVendaDao().Insert(item));
            return false;
        }

        public bool Update(ItemVenda item)
        {
            if (Validate(item))
                return (new ItemVendaDao().Update(item));
            return false;
        }

        public bool Delete(ItemVenda item)
        {
            return (new ItemVendaDao().Delete(item));
        }

        public ItemVenda GetById(int id)
        {
            ItemVenda itemVenda = new ItemVendaDao().GetById(id);
            if (itemVenda == null)
            {
                throw new Exception("Item de venda não encontrado!");
            }
            return itemVenda;
        }

        public List<ItemVenda> GetAll()
        {
            return new ItemVendaDao().GetAll();
        }

        public ItemVenda getByNome(string nome)
        {
            ItemVenda itemVenda = new ItemVendaDao().getByNome(nome);
            if (itemVenda == null)
            {
                throw new Exception("Item de venda não encontrado!");
            }
            return itemVenda;
        }
    }
}
