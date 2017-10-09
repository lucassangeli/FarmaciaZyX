using Farmacia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmacia.Utility;

namespace Farmacia.BLL
{
    public class EntradaBLL : BaseValidator<Entrada>, EntityCrud<Entrada>
    {
        public override bool Validate(Entrada item)
        {
            bool b = true;
            if (item.IdFuncionario < 0)
            {
                AddError("O Id do funcionário não pode ser menor que zero.");
                b = false;
            }

            if (item.IdFornecedor < 0)
            {
                AddError("O Id do fornecedor não pode ser menor que zero.");
                b = false;
            }

            if (DateTime.Now.Day - item.Data.Day < 0)
            {
                AddError("A data não é válida.");
                b = false;
            }

            base.Validate(item);
            return b;
        }

        public bool Insert(Entrada item)
        {
            if (Validate(item))
                return (new EntradaDao().Insert(item));
            return false;
        }

        public bool Update(Entrada item)
        {
            if (Validate(item))
                return (new EntradaDao().Update(item));
            return false;
        }

        public bool Delete(Entrada item)
        {
            return (new EntradaDao().Delete(item));
        }

        public Entrada GetById(int id)
        {
            Entrada entrada = new EntradaDao().GetById(id);
            if (entrada == null)
            {
                throw new Exception("Entrada não encontrada!");
            }
            return entrada;
        }

        public List<Entrada> GetAll()
        {
            return new EntradaDao().GetAll();
        }

        public Entrada getByNome(string nome)
        {
            Entrada entrada = new EntradaDao().getByNome(nome);
            if (entrada == null)
            {
                throw new Exception("Entrada não encontrada!");
            }
            return entrada;
        }

        public bool preencherCompra(List<double> valor, List<int> ids, Fornecedor forne, Funcionario fun)
        {
            try
            {                
                ProdutoDao pro = new ProdutoDao();
                Entrada entrada = new Entrada();
                entrada.Fornecedor = forne;
                Funcionario funcio = new Funcionario();
                funcio.Email = StaticUser.Email;
                funcio.Senha = StaticUser.Senha;
                entrada.Funcionario = new FuncionarioDao().GetUsuarioPorLoginSenha(funcio);
                entrada.Data = DateTime.Now;                
                for (int i = 0; i < valor.Count; i++)
                {
                    ItemEntrada item = new ItemEntrada();
                    item.Produto = pro.GetById(ids[i]);
                    item.Quantidade = (int)valor[i];
                    entrada.ItemEntrada.Add(item);
                    item.Produto.Quantidade += item.Quantidade;
                    pro.Update(item.Produto);
                }
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao gerar a compra: " + ex.Message);
                return false;
            }            

            return true;
        }
    }
}
