using Farmacia.BLL;
using Farmacia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia.Utility
{
    public class Bridge
    {
        public static void AtualizarGrid(Object obj, DataGridView view)
        {
            try
            {
                view.DataSource = null;
                view.Rows.Clear();
                if (obj != null)
                {
                    string nome = obj.GetType().FullName.ToLower();

                    if (nome.Trim().ToLower().Contains("cliente"))
                        view.DataSource = new ClienteBLL().GetAll();

                    else
                        if (nome.Trim().ToLower().Contains("fornecedor"))
                            view.DataSource = new FornecedorBLL().GetAll();

                        else
                            if (nome.Trim().ToLower().Contains("funcionario"))
                                new FuncionarioBLL().GetAll();

                            else
                                if (nome.Trim().ToLower().Contains("produto"))
                                    view.DataSource = new ProdutoBLL().GetAll();

                                else
                                    if (nome.Trim().ToLower().Contains("itemVenda"))
                                        view.DataSource = new ItemVendaBLL().GetAll();

                                    else
                                        if (nome.Trim().ToLower().Contains("itemEntrada"))
                                            view.DataSource = new ItemEntradaBLL().GetAll();

                                        else
                                            if (nome.Trim().ToLower().Contains("entrada"))
                                                view.DataSource = new EntradaBLL().GetAll();

                                            else
                                                if (nome.Trim().ToLower().Contains("venda"))
                                                    view.DataSource = new VendaBLL().GetAll();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message); ;
            }
        }

        public static void DefineType(Object obj, string command)
        {
            try
            {
                if (obj != null)
                {
                    string nome = obj.GetType().FullName.ToLower();

                    if (nome.Trim().ToLower().Contains("cliente"))
                    {
                        Cliente cliente = new Cliente();
                        cliente = (Cliente)obj;

                        ClienteBLL clienteBLL = new ClienteBLL();

                        switch (command.ToUpper()[0])
                        {
                            case 'A':
                                clienteBLL.Update(cliente);
                                System.Windows.Forms.MessageBox.Show("O registro foi atualizado com sucesso!");
                                break;
                            case 'D':
                                clienteBLL.Delete(cliente);
                                System.Windows.Forms.MessageBox.Show("O registro foi deletado com sucesso!");
                                break;
                            case 'I':
                                clienteBLL.Insert(cliente);
                                System.Windows.Forms.MessageBox.Show("O registro foi inserido com sucesso!");
                                break;
                            default:
                                break;
                        }
                    }
                    else
                        if (nome.Trim().ToLower().Contains("fornecedor"))
                        {
                            Fornecedor fornecedor = new Fornecedor();
                            fornecedor = (Fornecedor)obj;

                            FornecedorBLL fornecedorBLL = new FornecedorBLL();

                            switch (command.ToUpper()[0])
                            {
                                case 'A':
                                    fornecedorBLL.Update(fornecedor);
                                    System.Windows.Forms.MessageBox.Show("O registro foi atualizado com sucesso!");
                                    break;
                                case 'D':
                                    fornecedorBLL.Delete(fornecedor);
                                    System.Windows.Forms.MessageBox.Show("O registro foi deletado com sucesso!");
                                    break;
                                case 'I':
                                    fornecedorBLL.Insert(fornecedor);
                                    System.Windows.Forms.MessageBox.Show("O registro foi inserido com sucesso!");
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                            if (nome.Trim().ToLower().Contains("funcionario"))
                            {
                                Funcionario funcionario = new Funcionario();
                                funcionario = (Funcionario)obj;

                                FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

                                switch (command.ToUpper()[0])
                                {
                                    case 'A':
                                        funcionarioBLL.Update(funcionario);
                                        System.Windows.Forms.MessageBox.Show("O registro foi atualizado com sucesso!");
                                        break;
                                    case 'D':
                                        funcionarioBLL.Delete(funcionario);
                                        System.Windows.Forms.MessageBox.Show("O registro foi deletado com sucesso!");
                                        break;
                                    case 'I':
                                        funcionarioBLL.Insert(funcionario);
                                        System.Windows.Forms.MessageBox.Show("O registro foi inserido com sucesso!");
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                                if (nome.Trim().ToLower().Contains("produto"))
                                {
                                    Produto produto = new Produto();
                                    produto = (Produto)obj;

                                    ProdutoBLL produtoBLL = new ProdutoBLL();

                                    switch (command.ToUpper()[0])
                                    {
                                        case 'A':
                                            produtoBLL.Update(produto);
                                            System.Windows.Forms.MessageBox.Show("O registro foi atualizado com sucesso!");
                                            break;
                                        case 'D':
                                            produtoBLL.Delete(produto);
                                            System.Windows.Forms.MessageBox.Show("O registro foi deletado com sucesso!");
                                            break;
                                        case 'I':
                                            produtoBLL.Insert(produto);
                                            System.Windows.Forms.MessageBox.Show("O registro foi inserido com sucesso!");
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                    if (nome.Trim().ToLower().Contains("itemVenda"))
                                    {
                                        ItemVenda itemVenda = new ItemVenda();
                                        itemVenda = (ItemVenda)obj;

                                        ItemVendaBLL itemVendaBLL = new ItemVendaBLL();

                                        switch (command.ToUpper()[0])
                                        {
                                            case 'A':
                                                itemVendaBLL.Update(itemVenda);
                                                System.Windows.Forms.MessageBox.Show("O registro foi atualizado com sucesso!");
                                                break;
                                            case 'D':
                                                itemVendaBLL.Delete(itemVenda);
                                                System.Windows.Forms.MessageBox.Show("O registro foi deletado com sucesso!");
                                                break;
                                            case 'I':
                                                itemVendaBLL.Insert(itemVenda);
                                                System.Windows.Forms.MessageBox.Show("O registro foi inserido com sucesso!");
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                        if (nome.Trim().ToLower().Contains("itemEntrada"))
                                        {
                                            ItemEntrada itemEntrada = new ItemEntrada();
                                            itemEntrada = (ItemEntrada)obj;

                                            ItemEntradaBLL itemEntradaBLL = new ItemEntradaBLL();

                                            switch (command.ToUpper()[0])
                                            {
                                                case 'A':
                                                    itemEntradaBLL.Update(itemEntrada);
                                                    System.Windows.Forms.MessageBox.Show("O registro foi atualizado com sucesso!");
                                                    break;
                                                case 'D':
                                                    itemEntradaBLL.Delete(itemEntrada);
                                                    System.Windows.Forms.MessageBox.Show("O registro foi deletado com sucesso!");
                                                    break;
                                                case 'I':
                                                    itemEntradaBLL.Insert(itemEntrada);
                                                    System.Windows.Forms.MessageBox.Show("O registro foi inserido com sucesso!");
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        else
                                            if (nome.Trim().ToLower().Contains("entrada"))
                                            {
                                                Entrada entrada = new Entrada();
                                                entrada = (Entrada)obj;

                                                EntradaBLL entradaBLL = new EntradaBLL();

                                                switch (command.ToUpper()[0])
                                                {
                                                    case 'A':
                                                        entradaBLL.Update(entrada);
                                                        System.Windows.Forms.MessageBox.Show("O registro foi atualizado com sucesso!");
                                                        break;
                                                    case 'D':
                                                        entradaBLL.Delete(entrada);
                                                        System.Windows.Forms.MessageBox.Show("O registro foi deletado com sucesso!");
                                                        break;
                                                    case 'I':
                                                        entradaBLL.Insert(entrada);
                                                        System.Windows.Forms.MessageBox.Show("O registro foi inserido com sucesso!");
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                            else
                                                if (nome.Trim().ToLower().Contains("venda"))
                                                {
                                                    Venda venda = new Venda();
                                                    venda = (Venda)obj;

                                                    VendaBLL vendaBLL = new VendaBLL();

                                                    switch (command.ToUpper()[0])
                                                    {
                                                        case 'A':
                                                            vendaBLL.Update(venda);
                                                            System.Windows.Forms.MessageBox.Show("O registro foi atualizado com sucesso!");
                                                            break;
                                                        case 'D':
                                                            vendaBLL.Delete(venda);
                                                            System.Windows.Forms.MessageBox.Show("O registro foi deletado com sucesso!");
                                                            break;
                                                        case 'I':
                                                            vendaBLL.Insert(venda);
                                                            System.Windows.Forms.MessageBox.Show("O registro foi inserido com sucesso!");
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message); ;
            }
        }
    }
}
