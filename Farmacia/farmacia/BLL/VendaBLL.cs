using Farmacia.DTO;
using Farmacia.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.BLL
{
    public class VendaBLL : BaseValidator<Venda>, EntityCrud<Venda>
    {
        public override bool Validate(Venda item)
        {
            bool b = true;
            if (item.IdCliente < 0)
            {
                AddError("O Id do cliente não pode ser menor que zero.");
                b = false;
            }

            if (item.IdFuncionario < 0)
            {
                AddError("O Id do funcionário não pode ser menor que zero.");
                b = false;
            }

            if (DateTime.Now.Day - item.Data.Day < 0)
            {
                AddError("A data não é válida.");
                b = false;
            }

            if (string.IsNullOrWhiteSpace(item.FormaPagamento))
            {
                AddError("A forma de pagamento deve ser informada.");
                b = false;
            }
            else if (!CommonValidations.IsValidString(1, 50, item.FormaPagamento))
            {
                AddError("A forma de pagamento deve ter entre 1 e 50 caracteres.");
                b = false;
            }

            ItemVenda itemVenda = new ItemVenda();

            if (item.Desconto < 0 || item.Desconto > 100)
            {
                AddError("O desconto não pode ser menor que 0 ou maior que 100.");
                b = false;

            }
            else if (item.Desconto == 0)
            {
                itemVenda.ValorVenda = itemVenda.ValorVenda * 1;
                b = false;
            }
            else
            {
                itemVenda.ValorVenda = itemVenda.ValorVenda * (item.Desconto / 100);
            }

            base.Validate(item);
            return b;
        }

        public bool Insert(Venda item)
        {
            if (Validate(item))
                return (new VendaDao().Insert(item));
            return false;
        }

        public bool Update(Venda item)
        {
            if (Validate(item))
                return (new VendaDao().Update(item));
            return false;
        }

        public bool Delete(Venda item)
        {
            return (new VendaDao().Delete(item));
        }

        public Venda GetById(int id)
        {
            Venda venda = new VendaDao().GetById(id);
            if (venda == null)
            {
                throw new Exception("Venda não encontrada!");
            }
            return venda;
        }

        public List<Venda> GetAll()
        {
            return new VendaDao().GetAll();
        }

        public Venda getByNome(string nome)
        {
            Venda venda = new VendaDao().getByNome(nome);
            if (venda == null)
            {
                throw new Exception("Venda não encontrada!");
            }
            return venda;
        }

        public bool preecherVenda(List<double> valor, List<int> ids, Cliente cli, Funcionario fun, double Descontos, string formadepagamento)
        {
            try
            {
                int pontosNovos = 0;
                ProdutoDao pro = new ProdutoDao();
                Venda venda = new Venda();
                venda.Cliente = cli;
                venda.FormaPagamento = formadepagamento;
                Funcionario funcio = new Funcionario();
                funcio.Email = StaticUser.Email;
                funcio.Senha = StaticUser.Senha;
                venda.Funcionario = new FuncionarioDao().GetUsuarioPorLoginSenha(funcio);
                venda.Data = DateTime.Now;
                venda.Desconto = Descontos;
                for (int i = 0; i < valor.Count; i++)
                {
                    ItemVenda item = new ItemVenda();
                    item.Produto = pro.GetById(ids[i]);
                    item.Quantidade = (int)valor[i];
                    item.ValorVenda = item.Produto.ValorVenda * item.Quantidade;

                    venda.ItemVenda.Add(item);
                }
                foreach (ItemVenda item in venda.ItemVenda)
                {
                    pontosNovos += Convert.ToInt32(Math.Round(item.ValorVenda, 0));
                }

                cli.Pontos = (Descontos > 9) ? (cli.Pontos - 10) : (cli.Pontos + (int)(pontosNovos / 10));
                if (new ClienteBLL().Update(cli))
                    return (this.Insert(venda));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao gerar a venda: " + ex.Message);
            }
            return false;
        }
       
        public Venda selecionerUltima()
        {
            using (var context = new DatabaseEntities())
            {
                return context.Venda.OrderByDescending(x => x.Data).First();
            }
        }
    }
}

