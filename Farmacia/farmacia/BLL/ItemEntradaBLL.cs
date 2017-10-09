using Farmacia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.BLL
{
    public class ItemEntradaBLL : BaseValidator<ItemEntrada>, EntityCrud<ItemEntrada>
    {
        public override bool Validate(ItemEntrada item)
        {
            bool b = true;
            if (item.IdProduto < 0)
            {
                AddError("O Id do produto não pode ser menor que zero.");
                b = false;
            }

            if (item.IdEntrada < 0)
            {
                AddError("O Id de entrada não pode ser menor que zero.");
                b = false;
            }

            if (item.Quantidade <= 0)
            {
                AddError("A quantidade não pode ser menor ou igual a zero.");
                b = false;
            }

            if (item.ValorCompra <= 0)
            {
                AddError("O valor de compra não pode ser menor ou igual a zero.");
                b = false;
            }

            base.Validate(item);
            return b;
        }

        public bool Insert(ItemEntrada item)
        {
            if (Validate(item))
                return (new ItemEntradaDao().Insert(item));
            return false;
        }

        public bool Update(ItemEntrada item)
        {
            if (Validate(item))
                return (new ItemEntradaDao().Update(item));
            return false;
        }

        public bool Delete(ItemEntrada item)
        {
            return (new ItemEntradaDao().Delete(item));
        }

        public ItemEntrada GetById(int id)
        {
            ItemEntrada itemEntrada = new ItemEntradaDao().GetById(id);
            if (itemEntrada == null)
            {
                throw new Exception("Item de entrada não encontrado!");
            }
            return itemEntrada;
        }

        public List<ItemEntrada> GetAll()
        {
            return new ItemEntradaDao().GetAll();
        }

        public ItemEntrada getByNome(string nome)
        {
            ItemEntrada itemEntrada = new ItemEntradaDao().getByNome(nome);
            if (itemEntrada == null)
            {
                throw new Exception("Item de entrada não encontrado!");
            }
            return itemEntrada;
        }
    }
}
