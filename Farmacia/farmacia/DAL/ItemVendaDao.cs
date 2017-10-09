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
    public class ItemVendaDao : EntityCrud<ItemVenda>
    {
        public bool Insert(ItemVenda item)
        {
            try
            {
                var novoItemVenda = new ItemVenda();

                novoItemVenda = item;
                using (var db = new DatabaseEntities())
                {
                    db.ItemVenda.Add(novoItemVenda);
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

        public bool Update(ItemVenda item)
        {
            bool ret = false;

            try
            {
                ItemVenda itemVenda = new ItemVenda();

                using (var ctx = new DatabaseEntities())
                {
                    itemVenda = ctx.ItemVenda.Where(n => n.Id == item.Id).FirstOrDefault<ItemVenda>();
                }

                if (itemVenda != null)
                {
                    int id = itemVenda.Id;
                    itemVenda = item;
                    itemVenda.Id = id;
                    using (var dbCtx = new DatabaseEntities())
                    {
                        dbCtx.Entry(itemVenda).State = System.Data.Entity.EntityState.Modified;
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

        public bool Delete(ItemVenda item)
        {
            try
            {
                ItemVenda deletarItemVenda;

                using (var ctx = new DatabaseEntities())
                {
                    ItemVenda item2 = this.getByObject(item);
                    deletarItemVenda = ctx.ItemVenda.Where(n => n.Id == item2.Id).FirstOrDefault<ItemVenda>();
                }

                using (var newContext = new DatabaseEntities())
                {
                    newContext.Entry(deletarItemVenda).State = System.Data.Entity.EntityState.Deleted;
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

        public ItemVenda GetById(int id)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.ItemVenda
                            where p.Id == id
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new ItemVenda();
            }
        }

        public List<ItemVenda> GetAll()
        {
            List<ItemVenda> listaItemVenda = new List<ItemVenda>();
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var blogs = from p in context.ItemVenda
                                select new { p };
                    foreach (var item in blogs)
                    {
                        listaItemVenda.Add(item.p);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return listaItemVenda;
        }

        public ItemVenda getByNome(string nome)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.ItemVenda
                            where p.Produto.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper())
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new ItemVenda();
            }
        }

        public ItemVenda getByObject(ItemVenda obj)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.ItemVenda
                            where p.ValorVenda == obj.ValorVenda && p.Produto.Id.Equals(obj.Produto.Id)
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new ItemVenda();
            }
        }
    }
}
