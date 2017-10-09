using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       List<Object> atuAlList = new List<Object>() ;
        int ultimaPoziçãoy;
        Object atuAl;

        void t555_Leave(object sender, EventArgs e)
        {
            double d;
            if (!double.TryParse(this.Text, out d))
            {
                MessageBox.Show("Digite apenas numeros");
            }
        }


        public void CriarPreecherGrid<T>(List<T> obj)
        {
            DataGridView datagrid = new DataGridView();
            datagrid.DataSource = obj;

            datagrid.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top);
            datagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            panel1.Controls.Add(datagrid);
            datagrid.Dock = DockStyle.Fill;


        }
        public void VerificarCapos(Control contr)
        {
            foreach (var item in contr.Controls)
            {

                if (item is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)item).Text))
                    {
                        MessageBox.Show("Informe o campo" + ((TextBox)item).Name);
                    }
                }

                if (item is NumericUpDown)
                {
                    if ((((NumericUpDown)item).Value) >= 0)
                    {
                        MessageBox.Show("Informe o campo" + ((TextBox)item).Name);
                    }
                }


            }
        }
        public void CriarButton(string[] text)
        {

            int x = 10, y = 10;
            foreach (var item in text)
            {
                Button butn = new Button();
                butn.Text = item.ToString();
                butn.Click += butn_Click;
                butn.Location = new System.Drawing.Point(x, (ultimaPoziçãoy + 30));
                this.Controls.Add(butn);
                x += 90;

            }


            Button butns = new Button();
            butns.Text = "Exportar";
            butns.Click += butns_ClickExport; ;
            butns.Location = new System.Drawing.Point(x, (ultimaPoziçãoy + 30));
            this.Controls.Add(butns);

        }

        void butns_ClickExport(object sender, EventArgs e)
        {
            foreach (var item in panel1.Controls)
            {
                if (item is DataGridView)
                {
                    UtilLucas luc = new UtilLucas();

                    luc.gerrarExcel(((DataGridView)(item)));


                }
            }
        }

        public void CriarCampos<T>(ref T classes)
        {
            int x = 150, i = 30, xx = 10;
            atuAl = (classes);
            this.Text = classes.ToString();

            foreach (PropertyInfo item in typeof(T).GetProperties())
            {
                if (!item.Name.Trim().ToLower().Equals("id"))
                {


                    if (item.PropertyType != typeof(Boolean) && !item.PropertyType.Name.Contains("Collection"))
                    {
                        var o = item.PropertyType.ToString();
                        Label t = new Label();
                        t.Text = item.Name;
                        t.Name = item.Name;
                        //   t.Size     = new System.Drawing.Size(40, 90);
                        t.Location = new System.Drawing.Point((xx), i);
                        this.Controls.Add(t);
                    }

                    if (item.PropertyType == typeof(double))
                    {
                        TextBox t = new TextBox();
                        t.Name = item.Name;
                        t.Location = new System.Drawing.Point(x, i);
                        this.Controls.Add(t);
                        t.Leave += t555_Leave;

                    }
                    if (item.PropertyType == typeof(String))
                    {
                        if (item.Name.ToLower().Equals("cpf"))
                        {
                            MaskedTextBox masc = new MaskedTextBox();
                            masc.Name = item.Name;
                            masc.Mask = "000,000,000-0";
                            masc.Location = new System.Drawing.Point(x, i);
                            this.Controls.Add(masc);
                        }
                        else
                        {
                            if (item.Name.ToLower().Equals("rg"))
                            {
                                MaskedTextBox masc = new MaskedTextBox();
                                masc.Name = item.Name;
                                masc.Mask = "0,000,000";
                                masc.Location = new System.Drawing.Point(x, i);
                                this.Controls.Add(masc);
                            }
                            else
                            {
                                if (item.Name.ToLower().Equals("cnpj"))
                                {
                                    MaskedTextBox masc = new MaskedTextBox();
                                    masc.Name = item.Name;
                                    masc.Mask = "99.999.999/9999-99";
                                    masc.Location = new System.Drawing.Point(x, i);
                                    this.Controls.Add(masc);
                                }
                                else
                                {
                                    TextBox t = new TextBox();
                                    t.Name = item.Name;
                                    t.Location = new System.Drawing.Point(x, i);
                                    this.Controls.Add(t);
                                }
                            }
                        }

                      
                    }

                    if (item.PropertyType == typeof(int))
                    {
                        NumericUpDown t = new NumericUpDown();

                        t.Name = item.Name;
                        t.Value = 0;
                        t.Location = new System.Drawing.Point(x, i);
                        t.Leave += t_Leave;
                        this.Controls.Add(t);


                    }

                    if (item.PropertyType == typeof(bool))
                    {
                        CheckBox t = new CheckBox();
                        t.Text = item.Name;
                        t.Name = item.Name;
                        t.Checked = false;
                        t.Location = new System.Drawing.Point(x, i);
                        this.Controls.Add(t);

                    }

                    if (item.PropertyType == typeof(DateTime))
                    {
                        DateTimePicker t = new DateTimePicker();
                        t.Text = item.Name;
                        t.Name = item.Name;
                        t.Value = DateTime.Now;
                        t.Location = new System.Drawing.Point(x, i);
                        this.Controls.Add(t);

                    }



                    i += 30;
                    if (i % 30 > 9)
                    {
                        x += 60;
                        xx += 60;
                    }
                }
                
            }

            ultimaPoziçãoy = i;

        }

        void t_Leave(object sender, EventArgs e)
        {
            int o = 0;
            if (int.TryParse(((TextBox)(sender)).Text, out o))
            {
                MessageBox.Show("Apenas numeros Inteiros no campo " + ((TextBox)(sender)).Name);
            }
        }


        void butn_Click(object sender, EventArgs e)
        {
            string texto = ((Button)sender).Text;

            switch (texto.ToUpper()[0])
            {
                case 'D':
                    MessageBox.Show(texto);
                    break;
                case 'S':
                    MessageBox.Show(texto);
                    break;
                case 'I':
                    MessageBox.Show(texto);
                    break;
                default:
                    break;
            }

        }
        public void preecherClasse(Control contro)
        {
            foreach (PropertyInfo item in (atuAl).GetType().GetProperties())
            {
                foreach (PropertyInfo itemContros in contro.Controls)
                {

                    if (item.Name.Trim().Equals(itemContros.Name.Trim()))
                    {
                        item.SetValue( itemContros.GetValue());
                    }


                }
            }

        }



        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] li = { "Inserir", "Atualizar", "Deletar" };

            Cliente t = new Cliente();
            CriarCampos( ref t);
            CriarButton(li);
            CriarPreecherGrid(new ClienteDao().GetAll());
        }
    }
}
