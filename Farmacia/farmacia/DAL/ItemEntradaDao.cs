using Farmacia.DTO;
using Farmacia.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia
{
    public class ItemEntradaDao : EntityCrud<ItemEntrada>
    {
        public bool Insert(ItemEntrada item)
        {
            try
            {
                var novoItemEntrada = new ItemEntrada();

                novoItemEntrada = item;
                using (var db = new DatabaseEntities())
                {
                    db.ItemEntrada.Add(novoItemEntrada);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var item2 in ex.EntityValidationErrors)
                {
                    foreach (var item3 in item2.ValidationErrors)
                    {
                        System.Windows.Forms.MessageBox.Show(item3.ErrorMessage);
                    }
                }

                return false;
            }
        }

        public bool Update(ItemEntrada item)
        {
            bool ret = false;

            try
            {
                ItemEntrada itemEntrada = new ItemEntrada();

                using (var ctx = new DatabaseEntities())
                {
                    itemEntrada = ctx.ItemEntrada.Where(n => n.Id == item.Id).FirstOrDefault<ItemEntrada>();
                }

                if (itemEntrada != null)
                {
                    int id = itemEntrada.Id;
                    itemEntrada = item;
                    itemEntrada.Id = id;
                    using (var dbCtx = new DatabaseEntities())
                    {
                        dbCtx.Entry(itemEntrada).State = System.Data.Entity.EntityState.Modified;
                        dbCtx.SaveChanges();
                    }
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            return ret;
        }

        public bool Delete(ItemEntrada item)
        {
            try
            {
                ItemEntrada deletarItemEntrada;

                using (var ctx = new DatabaseEntities())
                {
                    ItemEntrada item2 = this.getByObject(item);
                    deletarItemEntrada = ctx.ItemEntrada.Where(n => n.Id == item2.Id).FirstOrDefault<ItemEntrada>();
                }

                using (var newContext = new DatabaseEntities())
                {
                    newContext.Entry(deletarItemEntrada).State = System.Data.Entity.EntityState.Deleted;
                    newContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }

        public ItemEntrada GetById(int id)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.ItemEntrada
                            where p.Id == id
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new ItemEntrada();
            }
        }

        public List<ItemEntrada> GetAll()
        {
            List<ItemEntrada> listaItemEntrada = new List<ItemEntrada>();
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var blogs = from p in context.ItemEntrada
                                select new { p };
                    foreach (var item in blogs)
                    {
                        listaItemEntrada.Add(item.p);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return listaItemEntrada;
        }

        public ItemEntrada getByNome(string nome)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.ItemEntrada
                            where p.Produto.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper())
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new ItemEntrada();
            }
        }

        public ItemEntrada getByObject(ItemEntrada obj)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.ItemEntrada
                            where p.ValorCompra == obj.ValorCompra && p.Produto.Id.Equals(obj.Produto.Id)
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new ItemEntrada();
            }
        }
    }
}
