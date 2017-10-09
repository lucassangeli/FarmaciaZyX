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
        List<Object> atuAlList = new List<Object>();
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
           List< DataGridViewColumn> remover = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn item in datagrid.Columns)
            {
              string s =   item.ValueType.FullName.ToString();
              if (item.ValueType.FullName.ToString().ToUpper().Contains("ICOLLECTION"))
                {
                    remover.Add(item);
                }

            }
            foreach (DataGridViewColumn item in remover)
            {
                datagrid.Columns.Remove(item);
            }
             
            datagrid.CellClick += datagrid_CellClick;      
            datagrid.Dock = DockStyle.Fill;


        }

        void datagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linha = ((DataGridView)(sender)).CurrentRow;


            preecherCampos(linha);

        }

        public void preecherCampos(DataGridViewRow row)
        {

            for (int i = 0; i < row.Cells.Count; i++)		
            {
                foreach (Control itemContros in this.Controls)
                {
                    if(!(itemContros is Label ))
                    {
                    if ( row.Cells[i].OwningColumn.Name.ToString().Trim().ToUpper().Equals(itemContros.Name.ToUpper().Trim())  )
                    {

                       
                        
                            if (itemContros is TextBox)
                            {
                                ((TextBox)(itemContros)).Text = ((row.Cells[i].Value != null)?row.Cells[i].Value:"").ToString();
                            }
                            if (itemContros is MaskedTextBox)
                            {
                                ((MaskedTextBox)(itemContros)).Text = ((row.Cells[i].Value != null) ? row.Cells[i].Value : "").ToString();
                            }
                            if (itemContros is NumericUpDown)
                            {
                              ((NumericUpDown)(itemContros)).Value = Convert.ToInt32(row.Cells[i].Value.ToString()); 
                            }
                            if (itemContros is CheckBox)
                            {
                                ((CheckBox)(itemContros)).Checked = Convert.ToBoolean(row.Cells[i].Value);
                            }
                            
                            if (itemContros is DateTimePicker)
                            {
                                ((DateTimePicker)(itemContros)).Value = Convert.ToDateTime(row.Cells[i].Value.ToString());
                            }
                        
                    }
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
                butn.Location = new System.Drawing.Point(x, (ultimaPoziçãoy + 10));
                this.Controls.Add(butn);
                x += 90;
            }
            
            Button butns = new Button();
            butns.Text = "Exportar";
            butns.Click += butns_ClickExport; ;
            butns.Location = new System.Drawing.Point(x, (ultimaPoziçãoy + 10));
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
                        t.KeyPress += t_KeyPress;

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

        void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            double numero;
            string textos= string.Empty;          
                textos = (((TextBox)(sender)).Text.ToString());         
            
                if (!double.TryParse(textos, out numero))
                {
                    e.KeyChar = '\0';
                    MessageBox.Show("Digite apenas numeros ex: 0,1,2,3,4,5,6,7,8,9");
                }        
         }

        void t_Leave(object sender, EventArgs e)
        {
            int o = 0;
            if (!int.TryParse(((NumericUpDown)(sender)).Text, out o))
            {
                MessageBox.Show("Apenas numeros Inteiros no campo " + ((NumericUpDown)(sender)).Name);
            }
        }


        void butn_Click(object sender, EventArgs e)
        {
            string texto = ((Button)sender).Text;

            switch (texto.ToUpper()[0])
            {
                case 'S':
                    preecherClasse(atuAl);
                  
                    break;
                case 'D':
                    preecherClasse(atuAl);
                    FormClear(atuAl);
                   
                    break;
                case 'I':
                    preecherClasse(atuAl);

                  

                    break;
                default:
                    break;
            }
            Bridge.DefineType(atuAl);

        }
        public void preecherClasse(Object a)
        {

            Type myType = a.GetType();
            string s =  a.GetType().FullName;
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                foreach (Control itemContros in this.Controls)
                {

                    if (prop.Name.Trim().Equals(itemContros.Name))
                    {
                        if (itemContros is TextBox )
                        {
                            prop.SetValue(a,((TextBox)(itemContros)).Text);
                        }
                        if (itemContros is MaskedTextBox)
                        {
                            prop.SetValue(a, ((MaskedTextBox)(itemContros)).Text);
                        }
                        if (itemContros is NumericUpDown)
                        {
                            prop.SetValue(a,(int) ((NumericUpDown)(itemContros)).Value);
                        }
                        if (itemContros is CheckBox)
                        {
                            prop.SetValue(a,(bool) ((CheckBox)(itemContros)).Checked);
                        }
                        if (itemContros is CheckBox)
                        {
                            prop.SetValue(a, ((CheckBox)(itemContros)).Checked);
                        }
                        if (itemContros is DateTimePicker)
                        {
                            prop.SetValue(a,(DateTime) ((DateTimePicker)(itemContros)).Value.Date);
                        }
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

            if (atuAl != null)
            {
                FormClear(atuAl);
                atuAl = null;
            }
               
            Cliente t = new Cliente();
            CriarCampos(ref t);
            CriarButton(li);
            CriarPreecherGrid(new ClienteDao().GetAll());

        }


        private void FormClear(Object obs)
        {
                       
            Type myType = obs.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                foreach (Control itemContros in this.Controls)
                {
                    if (!(itemContros is MenuStrip && itemContros is Panel))
                    {
                        this.Controls.RemoveByKey(prop.Name.ToUpper());     
                    }
                    if (itemContros is Button)
                    {
                        this.Controls.Remove(itemContros);
                    }
                                  
                }
            }
            panel1.Controls.Clear();

        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] li = { "Inserir", "Atualizar", "Deletar" };

            if (atuAl != null)
            {
                FormClear(atuAl);
                atuAl = null;
            }

            Funcionario t = new Funcionario();
            CriarCampos(ref t);
            CriarButton(li);
            CriarPreecherGrid(new FuncionarioDao().GetAll());
        }


    }
}
