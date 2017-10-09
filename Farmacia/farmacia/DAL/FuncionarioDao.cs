using Farmacia.DTO;
using Farmacia.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
                Criptografia criptografia = new Criptografia();

                novoFuncionario = item;
                novoFuncionario.Senha = criptografia.Cifrar(item.Senha);

                using (var db = new DatabaseEntities())
                {
                    db.Funcionario.Add(novoFuncionario);
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
                    int id = funcionario.Id;
                    funcionario = item;
                    funcionario.Id = id;
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
        }

        public bool Delete(Funcionario item)
        {
            try
            {
                Funcionario deletarFuncionario;

                using (var ctx = new DatabaseEntities())
                {
                    string cpf = item.CPF.Replace(".", "").Replace("-", "");
                    deletarFuncionario = this.getByCpf(cpf);
                }

                using (var newContext = new DatabaseEntities())
                {
                    newContext.Entry(deletarFuncionario).State = System.Data.Entity.EntityState.Deleted;
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
                                select new { p };
                    foreach (var item in blogs)
                    {
                        listaFuncionario.Add(item.p);
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

        public Funcionario getByCpf(string cpf)
        {
            using (var context = new DatabaseEntities())
            {
                var blogs = from p in context.Funcionario
                            where p.CPF.Trim().Equals(cpf.Trim())
                            select new { p };

                foreach (var item in blogs)
                {
                    return item.p;
                }
                return new Funcionario();
            }
        }

        public Funcionario GetUsuarioPorLoginSenha(Funcionario registro)
        {
            using (var usuario = new DatabaseEntities())
            {
                return usuario.Funcionario.FirstOrDefault(u => u.Email == registro.Email && u.Senha == registro.Senha);
            }
        }
    }
}
