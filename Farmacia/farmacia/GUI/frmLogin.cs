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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Informe o login e a senha.");
            }
            else
            {
                try
                {
                    Funcionario funcionario = new Funcionario();
                    Criptografia criptografia = new Criptografia();
                    funcionario.Email = txtUsuario.Text;
                    string cifra = criptografia.Cifrar(txtSenha.Text);
                    funcionario.Senha = criptografia.Cifrar(txtSenha.Text);

                    if (new BLL.FuncionarioBLL().isNull(funcionario))
                    {
                        MessageBox.Show("O login foi realizado com sucesso.");

                        this.Name = "form";
                        Form form = this;
                        form.Hide();
                        frmBase frm = new frmBase();
                        frm.ShowDialog();
                        this.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Erro! Verifique o seu email e senha.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro. " + ex.Message);
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(this, new EventArgs());
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(this, new EventArgs());
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Criptografia criptografia = new Criptografia();
            criptografia.CamuflarString(txtSenha);
        }
    }
}
