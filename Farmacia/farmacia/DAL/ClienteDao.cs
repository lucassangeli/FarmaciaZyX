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
    public class ClienteDao : EntityCrud<Cliente>
    {
        public bool Insert(Cliente item)
        {
            try
            {
                var novoCliente = new Cliente();

                novoCliente = item;
                using (var db = new DatabaseEntities())
                {
                    db.Cliente.Add(novoCliente);
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

        public bool Update(Cliente item)
        {
            bool ret = false;

            try
            {
                Cliente cliente = new Cliente();

                using (var ctx = new DatabaseEntities())
                {
                    cliente = ctx.Cliente.Where(n => n.Id == item.Id).FirstOrDefault<Cliente>();
                }

                if (cliente != null)
                {
                    int id = cliente.Id;
                    cliente = item;
                    cliente.Id = id;
                    using (var dbCtx = new DatabaseEntities())
                    {
                        dbCtx.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
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

        public bool Delete(Cliente item)
        {
            try
            {
                Cliente deletarCliente;

                using (var ctx = new DatabaseEntities())
                {
                    string cpf = item.CPF.Replace(".", "").Replace("-", "");
                    deletarCliente = this.getByCpf(cpf);
                }

                using (var newContext = new DatabaseEntities())
                {
                    newContext.Entry(deletarCliente).State = System.Data.Entity.EntityState.Deleted;
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

        public Cliente GetById(int id)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Cliente
                            where p.Id == id
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Cliente();
            }
        }

        public List<Cliente> GetAll()
        {
            List<Cliente> listaCliente = new List<Cliente>();
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var blogs = from p in context.Cliente
                                select new { p };
                    foreach (var item in blogs)
                    {
                        listaCliente.Add(item.p);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return listaCliente;
        }

        public Cliente getByNome(string nome)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Cliente
                            where p.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper())
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Cliente();
            }
        }

        public Cliente getByCpf(string cpf)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Cliente
                            where p.CPF.Trim().Equals(cpf.Trim())
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Cliente();
            }
        }
    }
}
