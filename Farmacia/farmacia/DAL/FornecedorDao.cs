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
    public class FornecedorDao : EntityCrud<Fornecedor>
    {
        public bool Insert(Fornecedor item)
        {
            try
            {
                var novoFornecedor = new Fornecedor();

                novoFornecedor = item;
                using (var db = new DatabaseEntities())
                {
                    db.Fornecedor.Add(novoFornecedor);
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

        public bool Update(Fornecedor item)
        {
            bool ret = false;

            try
            {
                Fornecedor fornecedor = new Fornecedor();

                using (var ctx = new DatabaseEntities())
                {
                    fornecedor = ctx.Fornecedor.Where(n => n.Id == item.Id).FirstOrDefault<Fornecedor>();
                }

                if (fornecedor != null)
                {
                    int id = fornecedor.Id;
                    fornecedor = item;
                    fornecedor.Id = id;
                    using (var dbCtx = new DatabaseEntities())
                    {
                        dbCtx.Entry(fornecedor).State = System.Data.Entity.EntityState.Modified;
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

        public bool Delete(Fornecedor item)
        {
            try
            {
                Fornecedor deletarFornecedor;

                using (var ctx = new DatabaseEntities())
                {
                    string cpf = item.CNPJ.Replace(".", "").Replace("-", "");
                    deletarFornecedor = this.getByCpnj(cpf);
                }

                using (var newContext = new DatabaseEntities())
                {
                    newContext.Entry(deletarFornecedor).State = System.Data.Entity.EntityState.Deleted;
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

        public Fornecedor GetById(int id)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Fornecedor
                            where p.Id == id
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Fornecedor();
            }
        }

        public List<Fornecedor> GetAll()
        {
            List<Fornecedor> listaFornecedor = new List<Fornecedor>();
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var blogs = from p in context.Fornecedor
                                select new { p };
                    foreach (var item in blogs)
                    {
                        listaFornecedor.Add(item.p);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return listaFornecedor;
        }

        public Fornecedor getByNome(string nome)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Fornecedor
                            where p.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper())
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Fornecedor();
            }
        }

        public Fornecedor getByCpnj(string cnpj)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Fornecedor
                            where p.CNPJ.Trim().Equals(cnpj.Trim())
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Fornecedor();
            }
        }
    }
}
