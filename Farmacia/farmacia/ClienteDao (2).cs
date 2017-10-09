using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia
{
    public class ClienteDao : EntityCrud<Cliente>
    {
        public bool Delete(Cliente item)
        {
       

            try
            {
                Cliente deletarPessoa;

                using (var ctx = new DataBeseEntities1())
                {
                    deletarPessoa = ctx.Cliente.Where(n => n.Id == item.Id).FirstOrDefault<Cliente>();
                }

                using (var newContext = new DataBeseEntities1())
                {
                    newContext.Entry(deletarPessoa).State = System.Data.Entity.EntityState.Deleted;
                    newContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Cliente> GetAll()
        {

            List<Cliente> listcli = new List<Cliente>();
            try
            {             

                using (var context = new DataBeseEntities1())
                {
                    var blogs = from p in context.Cliente
                                select new { p };
                    foreach (var item in blogs)
                    {
                        listcli.Add(item.p);
                    }
                }
                
            }
            catch (Exception ex)
            {

               
            }
            return listcli;
        }

        public Cliente GetById(int id)
        {
            using (var context = new DataBeseEntities1())
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

        public Cliente getByNome(string nome)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Cliente item)
        {
            try
            {
                var novaCliente = new Cliente();

                novaCliente = item;
                using (var db = new DataBeseEntities1())
                {
                    db.Cliente.Add(novaCliente);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
           
            
        }

        public bool Update(Cliente item)
        {
            bool ret = false;

            try
            {
                Cliente cliente = new Cliente();

                using (var ctx = new DataBeseEntities1())
                {
                    cliente = ctx.Cliente.Where(n => n.Id == item.Id).FirstOrDefault<Cliente>();
                }

                if (cliente != null)
                {
                    cliente = item;
                    using (var dbCtx = new DataBeseEntities1())
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

                ret =  false;
            }
            return ret;
        }

        public Cliente getByCpf(string cpf)
        {
            using (var context = new DataBeseEntities1())
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
