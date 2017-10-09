using Farmacia.BLL;
using Farmacia.DTO;
using Farmacia.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia.GUI
{
    public partial class frmItemSaida : Form
    {
        public frmItemSaida()
        {
            InitializeComponent();
        }

        Venda vendas = new Venda();
        Cliente cli = new Cliente();        

        public bool ADDgrid(Produto prod, Double numro)
        {
            try
            {
                dataGridView1.Rows.Add(prod.Id, prod.Nome, prod.Laboratorio, prod.ValorVenda, numro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar:" + ex.Message, "ERRO!!", MessageBoxButtons.OK);
            }
            return false;
        }        

        public StringBuilder GetObj()
        {
            StringBuilder obj = new StringBuilder();

            foreach (string item in textBoxObj.Lines)
            {
                obj.Append(item);
            }
            return obj;
        }        

        private void button2_Click_1(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            List<double> qtd = new List<double>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                int aux;
                if (int.TryParse((item.Cells["Id"].Value).ToString(), out aux))
                    ids.Add(aux);
            }
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                int aux;
                if (int.TryParse((item.Cells["Quantidade"].Value).ToString(), out aux))
                    qtd.Add(aux);
            }

            double desc = (cli.Pontos > 9) ? 10 : 0;
            if (!string.IsNullOrWhiteSpace(comboBoxFormaDePagamento.SelectedItem.ToString()))
            {
                if (ids.Count > 0)
                {
                    if (new VendaBLL().preecherVenda(qtd, ids, cli, new Funcionario(), desc, comboBoxFormaDePagamento.SelectedItem.ToString()))
                    {
                        MessageBox.Show("A venda foi efetuada com sucesso.");
                        vendas = new VendaBLL().selecionerUltima();
                        if (vendas.Id > 0)
                            buttonEnviarEmailXml.Enabled = true;
                    }
                }
                else
                    MessageBox.Show("Erro! Seleciona um item para vender.");
            }
            else
                MessageBox.Show("É obrigatório selecionar uma forma de pagamento.");
        }

        private void maskedTextBox1_Leave_1(object sender, EventArgs e)
        {
            string textos = ((MaskedTextBox)sender).Text.ToString().Replace(".", "").Replace("-", "");
            if (textos.Length > 0)
            {
                cli = new ClienteDao().getByCpf(textos);
                labelNome.Text = cli.Nome.ToString().ToUpper();
                labelRg.Text = cli.RG.ToString().ToUpper();
                labelTelefone.Text = cli.Telefone.ToString().ToUpper();
                labelDescontos.Text = (cli.Pontos).ToString().ToUpper();
                labelPontos.Text = (cli.Pontos).ToString();
                textBoxEmail.Text = cli.Email.ToString();
                List<Produto> PRODUT = new ProdutoBLL().GetAll();
                if (PRODUT.Count(x => x.ativo > 0) > 0)
                {
                    comboBoxPorduto.Items.AddRange(PRODUT.Where(x => x.ativo > 0).ToArray());
                    comboBoxPorduto.DisplayMember = "Nome";
                }
                else
                    MessageBox.Show("Não há produtos ativos. Favor cadastrar!", "Ateção!");
            }
            else
            {
                labelPontos.Text = "0";
                labelDescontos.Text = "0";
                MessageBox.Show(("Informe um CPF."));
            }
        }

        private void maskedTextBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            double pu = 0;
            string textos = e.KeyChar.ToString().Replace(".", "").Replace("-", "");

            if (!double.TryParse(textos, out pu))
            {
                e.KeyChar = '\0';
                MessageBox.Show("São permitidos apenas números.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double num = 0;
            if (comboBoxPorduto.SelectedItem != null)
            {
                Produto produt = (Produto)comboBoxPorduto.SelectedItem;
                if (numericVenPorduto.Value > 0)
                {
                    num = (double)numericVenPorduto.Value;
                    this.ADDgrid(produt, num);
                    label6.Text = (Convert.ToInt32(label6.Text) + (produt.ValorVenda * Convert.ToDouble(numericVenPorduto.Value))).ToString();
                    if (cli.Pontos > 9)
                        labelVLFINAL.Text = (Convert.ToInt32(label6.Text) * 0.9).ToString();
                    else
                        labelVLFINAL.Text = label6.Text;                   
                }
                else
                    MessageBox.Show("A quantidade de itens deve ser maior que zero.");
            }
            else
                MessageBox.Show("Selecione um produto!");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            double num = 0;
            int i = dataGridView1.CurrentRow.Index;
            DataGridViewRow rowss = dataGridView1.CurrentRow;
            if (i > -1)
            {
                dataGridView1.Rows.Remove(rowss);
                label6.Text = (Convert.ToInt32(label6.Text) - num).ToString();
                MessageBox.Show("Item excluido com sucesso!");
            }
        }

        private void buttonEnviarEmailXml_Click(object sender, EventArgs e)
        {
            string caminho = string.Empty;
            if (checkBoxXML.Checked && vendas != null)
            {
                caminho = Utility.XMLCreator.Creat(vendas);
                using (var context = new DatabaseEntities())
                {
                    vendas = context.Venda.OrderByDescending(x => x.Id == vendas.Id).First();




                    if (checkBoxEmail.Checked)
                        if (XMLCreator.Enviar(caminho, this.GetObj(), textBoxEmail.Text, vendas.Cliente.Nome))
                            MessageBox.Show("Email enviado");
                }
            }
            //string caminho, StringBuilder obj, string email, string nomeDest
        }        

        private void frmItemSaida_Load(object sender, EventArgs e)
        {
            string[] formaDPagamento = new string[] { "", "Avista", "Credito", "Debito" };
            comboBoxFormaDePagamento.DataSource = formaDPagamento;
        }
    }
}
