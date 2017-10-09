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
    public class ProdutoDao : EntityCrud<Produto>
    {
        public bool Insert(Produto item)
        {
            try
            {
                var novoProduto = new Produto();

                novoProduto = item;
                using (var db = new DatabaseEntities())
                {
                    db.Produto.Add(novoProduto);
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

        public bool Update(Produto item)
        {
            bool ret = false;

            try
            {
                Produto produto = new Produto();

                using (var ctx = new DatabaseEntities())
                {
                    produto = ctx.Produto.Where(n => n.Id == item.Id).FirstOrDefault<Produto>();
                }

                if (produto != null)
                {
                    int id = produto.Id;
                    produto = item;
                    produto.Id = id;
                    using (var dbCtx = new DatabaseEntities())
                    {
                        dbCtx.Entry(produto).State = System.Data.Entity.EntityState.Modified;
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

        public bool Delete(Produto item)
        {
            try
            {
                Produto deletarProduto;

                using (var ctx = new DatabaseEntities())
                {
                    Produto item2 = this.getByObject(item);
                    deletarProduto = ctx.Produto.Where(n => n.Id == item2.Id).FirstOrDefault<Produto>();
                }

                using (var newContext = new DatabaseEntities())
                {
                    newContext.Entry(deletarProduto).State = System.Data.Entity.EntityState.Deleted;
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

        public Produto GetById(int id)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Produto
                            where p.Id == id
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Produto();
            }
        }

        public List<Produto> GetAll()
        {
            List<Produto> listaProduto = new List<Produto>();
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var blogs = from p in context.Produto
                                select new { p };
                    foreach (var item in blogs)
                    {
                        listaProduto.Add(item.p);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return listaProduto;
        }

        public Produto getByNome(string nome)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Produto
                            where p.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper())
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Produto();
            }
        }

        public Produto getByObject(Produto obj)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Produto
                            where p.Nome == obj.Nome && p.Descricao == obj.Descricao && p.Laboratorio == obj.Laboratorio
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Produto();
            }
        }
    }
}
