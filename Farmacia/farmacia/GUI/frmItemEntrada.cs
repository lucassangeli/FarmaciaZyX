using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Farmacia.BLL;
using Farmacia.DTO;

namespace Farmacia.GUI
{
    public partial class frmItemEntrada : Form
    {
        public frmItemEntrada()
        {
            InitializeComponent();            
        }

        Entrada entradas = new Entrada();
        Fornecedor forn = new Fornecedor();
        
        public bool ADDgrid(Produto prod, ItemEntrada itemEnt, Double numro)
        {
            try
            {
                dataGridView1.Rows.Add(prod.Id, prod.Nome, prod.Laboratorio, itemEnt.ValorCompra, numro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar:" + ex.Message, "Erro!", MessageBoxButtons.OK);
            }
            return false;
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

            if (ids.Count > 0)
            {
                if (new EntradaBLL().preencherCompra(qtd, ids, forn, new Funcionario()))
                {
                    MessageBox.Show("A compra foi efetuada com sucesso.");
                }
            }
            else
                MessageBox.Show("Erro! Seleciona um item para comprar.");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double num = 0;
            if (comboBoxPorduto.SelectedItem != null)
            {
                Produto produt = (Produto)comboBoxPorduto.SelectedItem;
                ItemEntrada itemEnt= new ItemEntrada();
                itemEnt.Produto = (Produto)comboBoxPorduto.SelectedItem;
                if (numericVenPorduto.Value > 0)
                {
                    num = (double)numericVenPorduto.Value;
                    this.ADDgrid(produt, itemEnt, num);
                    labelVLFINAL.Text = (numericValorPorduto.Value * numericVenPorduto.Value).ToString();
                }
                else
                    MessageBox.Show("A quantidade de itens deve ser maior que zero!");
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
                labelVLFINAL.Text = (0).ToString();
                MessageBox.Show("Item excluido com sucesso!");
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

        private void maskedTextBox1_Leave_1(object sender, EventArgs e)
        {
            string textos = ((MaskedTextBox)sender).Text.ToString().Replace(".", "").Replace("-", "");
            if (textos.Length > 0)
            {
                forn = new FornecedorDao().getByCpnj(textos);
                labelNome.Text = forn.Nome.ToString().ToUpper();
                labelTelefone.Text = forn.Telefone.ToString().ToUpper();
                labelEmail.Text = forn.Email.ToString().ToUpper();
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
                MessageBox.Show("Informe um CNPJ.");
            }
        }        
    }
}
