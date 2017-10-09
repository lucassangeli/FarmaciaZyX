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
    public class EntradaDao : EntityCrud<Entrada>
    {
        public bool Insert(Entrada item)
        {
            try
            {
                var novaEntrada = new Entrada();

                novaEntrada = item;
                using (var db = new DatabaseEntities())
                {
                    db.Entrada.Add(novaEntrada);
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

        public bool Update(Entrada item)
        {
            bool ret = false;

            try
            {
                Entrada entrada = new Entrada();

                using (var ctx = new DatabaseEntities())
                {
                    entrada = ctx.Entrada.Where(n => n.Id == item.Id).FirstOrDefault<Entrada>();
                }

                if (entrada != null)
                {
                    int id = entrada.Id;
                    entrada = item;
                    entrada.Id = id;
                    using (var dbCtx = new DatabaseEntities())
                    {
                        dbCtx.Entry(entrada).State = System.Data.Entity.EntityState.Modified;
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

        public bool Delete(Entrada item)
        {
            try
            {
                Entrada deletarEntrada;

                using (var ctx = new DatabaseEntities())
                {

                    deletarEntrada = ctx.Entrada.Where(n => n.Id == item.Id).FirstOrDefault<Entrada>();
                }

                using (var newContext = new DatabaseEntities())
                {
                    newContext.Entry(deletarEntrada).State = System.Data.Entity.EntityState.Deleted;
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

        public Entrada GetById(int id)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Entrada
                            where p.Id == id
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Entrada();
            }
        }

        public List<Entrada> GetAll()
        {
            List<Entrada> listaEntrada = new List<Entrada>();
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var blogs = from p in context.Entrada
                                select new { p };
                    foreach (var item in blogs)
                    {
                        listaEntrada.Add(item.p);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return listaEntrada;
        }

        public Entrada getByNome(string nome)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Entrada
                            where p.Fornecedor.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper())
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Entrada();
            }
        }

        public Entrada getByObject(Entrada obj)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Entrada
                            where p.Data == obj.Data && p.Fornecedor.Id.Equals(obj.Fornecedor.Id) && p.Funcionario.Id.Equals(obj.Funcionario.Id)
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Entrada();
            }
        }
    }
}
