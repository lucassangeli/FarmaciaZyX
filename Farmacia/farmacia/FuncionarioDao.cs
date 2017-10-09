using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia
{
    public class FuncionarioDao : EntityCrud<Funcionario>
    {
        public bool Insert(Funcionario item)
        {
            try
            {
                var novoFuncionario = new Funcionario();

                novoFuncionario = item;
                using (var db = new DatabaseEntities())
                {
                    db.Funcionario.Add(novoFuncionario);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            /*
            novoFuncionario.CPF = CPF.Text;
            novoFuncionario.RG = RG.Text;
            novoFuncionario.Nome = Nome.Text;
            novoFuncionario.Telefone = Telefone.Text;
            novoFuncionario.Email = Email.Text;
            novoFuncionario.Endereco = Endereco.Text;
            novoFuncionario.Senha = Senha.Text;
            novoFuncionario.Administrador = Convert.ToInt32(Administrador.Text);                    
            */

        }

        public bool Update(Funcionario item)
        {
            bool ret = false;

            try
            {
                Funcionario funcionario = new Funcionario();

                using (var ctx = new DatabaseEntities())
                {
                    funcionario = ctx.Funcionario.Where(n => n.Id == item.Id).FirstOrDefault<Funcionario>();
                }

                if (funcionario != null)
                {
                    funcionario = item;
                    using (var dbCtx = new DatabaseEntities())
                    {
                        dbCtx.Entry(funcionario).State = System.Data.Entity.EntityState.Modified;
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

            /*
            novoFuncionario.CPF = CPF.Text;
            novoFuncionario.RG = RG.Text;
            novoFuncionario.Nome = Nome.Text;
            novoFuncionario.Telefone = Telefone.Text;
            novoFuncionario.Email = Email.Text;
            novoFuncionario.Endereco = Endereco.Text;
            novoFuncionario.Senha = Senha.Text;
            novoFuncionario.Administrador = Convert.ToInt32(Administrador.Text);                    
            */

        }

        public bool Delete(Funcionario item)
        {
            try
            {
                Funcionario deletarFuncionario;

                using (var ctx = new DatabaseEntities())
                {
                    deletarFuncionario = ctx.Funcionario.Where(n => n.Id == item.Id).FirstOrDefault<Funcionario>();
                }

                using (var newContext = new DatabaseEntities())
                {
                    newContext.Entry(deletarFuncionario).State = System.Data.Entity.EntityState.Deleted;
                    newContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Funcionario GetById(int id)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Funcionario
                            where p.Id == id
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Funcionario();
            }
        }

        public List<Funcionario> GetAll()
        {
            List<Funcionario> listaFuncionario = new List<Funcionario>();
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var blogs = from p in context.Funcionario
                                select new {p.Id,p.Nome,p.RG,p.Telefone, p.Administrador,p.CPF,p.Email,p.Endereco,p.Entrada };
                    foreach (var item in blogs)
                    {
                        Funcionario Funcc = new Funcionario();
                        Funcc.Id = item.Id;
                        Funcc.Nome = item.Nome;
                        Funcc.RG = item.RG;
                        Funcc.Telefone = item.Telefone;
                        Funcc.Administrador = item.Administrador;
                        Funcc.CPF = item.CPF;
                        Funcc.Email = item.Email;
                        Funcc.Endereco = item.Endereco;
                        

                        listaFuncionario.Add(Funcc);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return listaFuncionario;
        }

        public Funcionario getByNome(string nome)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Funcionario
                            where p.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper())
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Funcionario();
            }
        }
    }
}
