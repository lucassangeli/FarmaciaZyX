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
    public class VendaDao : EntityCrud<Venda>
    {
        public bool Insert(Venda item)
        {
            try
            {
                var novaVenda = new Venda();

                novaVenda = item;
                using (var db = new DatabaseEntities())
                {
                    db.Venda.Add(novaVenda);
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

        public bool Update(Venda item)
        {
            bool ret = false;

            try
            {
                Venda venda = new Venda();

                using (var ctx = new DatabaseEntities())
                {
                    venda = ctx.Venda.Where(n => n.Id == item.Id).FirstOrDefault<Venda>();
                }

                if (venda != null)
                {
                    int id = venda.Id;
                    venda = item;
                    venda.Id = id;
                    using (var dbCtx = new DatabaseEntities())
                    {
                        dbCtx.Entry(venda).State = System.Data.Entity.EntityState.Modified;
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

        public bool Delete(Venda item)
        {
            try
            {
                Venda deletarVenda;

                using (var ctx = new DatabaseEntities())
                {
                    Venda item2 = this.getByObject(item);
                    deletarVenda = ctx.Venda.Where(n => n.Id == item2.Id).FirstOrDefault<Venda>();
                }

                using (var newContext = new DatabaseEntities())
                {
                    newContext.Entry(deletarVenda).State = System.Data.Entity.EntityState.Deleted;
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

        public Venda GetById(int id)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Venda
                            where p.Id == id
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Venda();
            }
        }

        public List<Venda> GetAll()
        {
            List<Venda> listaVenda = new List<Venda>();
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var blogs = from p in context.Venda
                                select new { p };
                    foreach (var item in blogs)
                    {
                        listaVenda.Add(item.p);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return listaVenda;
        }

        public Venda getByNome(string nome)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Venda
                            where p.Cliente.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper())
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Venda();
            }
        }

        public Venda getByObject(Venda obj)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Venda
                            where p.Data == obj.Data && p.Cliente.Id.Equals(obj.Cliente.Id) && p.Funcionario.Id.Equals(obj.Funcionario.Id)
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Venda();
            }
        }
    }
}
