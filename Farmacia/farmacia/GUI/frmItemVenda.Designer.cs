namespace Farmacia.GUI
{
    partial class frmItemSaida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxEmail = new System.Windows.Forms.CheckBox();
            this.numericVenPorduto = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LABORATORIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTIDADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxPorduto = new System.Windows.Forms.ComboBox();
            this.buttonEnviarEmailXml = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxObj = new System.Windows.Forms.TextBox();
            this.checkBoxXML = new System.Windows.Forms.CheckBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxFormaDePagamento = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.labelVLFINAL = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelPontos = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.labelTelefone = new System.Windows.Forms.Label();
            this.labelRg = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.labelDescontos = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericVenPorduto)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxEmail
            // 
            this.checkBoxEmail.AutoSize = true;
            this.checkBoxEmail.Location = new System.Drawing.Point(33, 54);
            this.checkBoxEmail.Name = "checkBoxEmail";
            this.checkBoxEmail.Size = new System.Drawing.Size(81, 17);
            this.checkBoxEmail.TabIndex = 0;
            this.checkBoxEmail.Text = "Enviar XML";
            this.checkBoxEmail.UseVisualStyleBackColor = true;
            this.checkBoxEmail.Visible = false;
            // 
            // numericVenPorduto
            // 
            this.numericVenPorduto.Location = new System.Drawing.Point(88, 124);
            this.numericVenPorduto.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericVenPorduto.Name = "numericVenPorduto";
            this.numericVenPorduto.Size = new System.Drawing.Size(153, 20);
            this.numericVenPorduto.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Produto:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(88, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Adicionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Location = new System.Drawing.Point(253, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(521, 341);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NOME,
            this.LABORATORIO,
            this.Preco,
            this.QUANTIDADE});
            this.dataGridView1.Location = new System.Drawing.Point(3, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(515, 334);
            this.dataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "Id";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // NOME
            // 
            this.NOME.HeaderText = "Nome";
            this.NOME.Name = "NOME";
            this.NOME.ReadOnly = true;
            // 
            // LABORATORIO
            // 
            this.LABORATORIO.HeaderText = "Laboratório";
            this.LABORATORIO.Name = "LABORATORIO";
            this.LABORATORIO.ReadOnly = true;
            // 
            // Preco
            // 
            this.Preco.HeaderText = "Preço";
            this.Preco.Name = "Preco";
            this.Preco.ReadOnly = true;
            // 
            // QUANTIDADE
            // 
            this.QUANTIDADE.HeaderText = "Quantidade";
            this.QUANTIDADE.Name = "QUANTIDADE";
            this.QUANTIDADE.ReadOnly = true;
            // 
            // comboBoxPorduto
            // 
            this.comboBoxPorduto.FormattingEnabled = true;
            this.comboBoxPorduto.Location = new System.Drawing.Point(88, 89);
            this.comboBoxPorduto.Name = "comboBoxPorduto";
            this.comboBoxPorduto.Size = new System.Drawing.Size(153, 21);
            this.comboBoxPorduto.TabIndex = 0;
            // 
            // buttonEnviarEmailXml
            // 
            this.buttonEnviarEmailXml.Enabled = false;
            this.buttonEnviarEmailXml.Location = new System.Drawing.Point(36, 164);
            this.buttonEnviarEmailXml.Name = "buttonEnviarEmailXml";
            this.buttonEnviarEmailXml.Size = new System.Drawing.Size(91, 23);
            this.buttonEnviarEmailXml.TabIndex = 6;
            this.buttonEnviarEmailXml.Text = "Gerra/Enviar";
            this.buttonEnviarEmailXml.UseVisualStyleBackColor = true;
            this.buttonEnviarEmailXml.Click += new System.EventHandler(this.buttonEnviarEmailXml_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "OBJ:";
            this.label2.Visible = false;
            // 
            // textBoxObj
            // 
            this.textBoxObj.Location = new System.Drawing.Point(290, 52);
            this.textBoxObj.Multiline = true;
            this.textBoxObj.Name = "textBoxObj";
            this.textBoxObj.Size = new System.Drawing.Size(447, 276);
            this.textBoxObj.TabIndex = 4;
            this.textBoxObj.Visible = false;
            // 
            // checkBoxXML
            // 
            this.checkBoxXML.AutoSize = true;
            this.checkBoxXML.Location = new System.Drawing.Point(33, 20);
            this.checkBoxXML.Name = "checkBoxXML";
            this.checkBoxXML.Size = new System.Drawing.Size(77, 17);
            this.checkBoxXML.TabIndex = 3;
            this.checkBoxXML.Text = "Gerra XML";
            this.checkBoxXML.UseVisualStyleBackColor = true;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(36, 122);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(203, 20);
            this.textBoxEmail.TabIndex = 2;
            this.textBoxEmail.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email Destinatario:";
            this.label1.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(88, 215);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Remover";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 621);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.numericVenPorduto);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.comboBoxPorduto);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(780, 353);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Produtos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 126);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Quantidade:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.comboBoxFormaDePagamento);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.labelVLFINAL);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.labelPontos);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.labelTelefone);
            this.panel1.Controls.Add(this.labelRg);
            this.panel1.Controls.Add(this.labelNome);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.maskedTextBox1);
            this.panel1.Controls.Add(this.labelDescontos);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 205);
            this.panel1.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(199, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Pontos:";
            // 
            // comboBoxFormaDePagamento
            // 
            this.comboBoxFormaDePagamento.FormattingEnabled = true;
            this.comboBoxFormaDePagamento.Location = new System.Drawing.Point(198, 24);
            this.comboBoxFormaDePagamento.Name = "comboBoxFormaDePagamento";
            this.comboBoxFormaDePagamento.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFormaDePagamento.TabIndex = 27;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(567, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 69);
            this.button2.TabIndex = 24;
            this.button2.Text = "Concluir Venda";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // labelVLFINAL
            // 
            this.labelVLFINAL.AutoSize = true;
            this.labelVLFINAL.Font = new System.Drawing.Font("Microsoft Tai Le", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVLFINAL.Location = new System.Drawing.Point(715, 56);
            this.labelVLFINAL.Name = "labelVLFINAL";
            this.labelVLFINAL.Size = new System.Drawing.Size(43, 49);
            this.labelVLFINAL.TabIndex = 23;
            this.labelVLFINAL.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(699, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Valor Final:";
            // 
            // labelPontos
            // 
            this.labelPontos.AutoSize = true;
            this.labelPontos.Location = new System.Drawing.Point(92, 169);
            this.labelPontos.Name = "labelPontos";
            this.labelPontos.Size = new System.Drawing.Size(0, 13);
            this.labelPontos.TabIndex = 21;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(32, 169);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(43, 13);
            this.label.TabIndex = 20;
            this.label.Text = "Pontos:";
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Location = new System.Drawing.Point(92, 129);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(0, 13);
            this.labelTelefone.TabIndex = 19;
            // 
            // labelRg
            // 
            this.labelRg.AutoSize = true;
            this.labelRg.Location = new System.Drawing.Point(92, 92);
            this.labelRg.Name = "labelRg";
            this.labelRg.Size = new System.Drawing.Size(0, 13);
            this.labelRg.TabIndex = 18;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(92, 56);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(0, 13);
            this.labelNome.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Telefone:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "RG:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Nome:";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(34, 24);
            this.maskedTextBox1.Mask = "000,000,000-00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(87, 20);
            this.maskedTextBox1.TabIndex = 12;
            this.maskedTextBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress_1);
            this.maskedTextBox1.Leave += new System.EventHandler(this.maskedTextBox1_Leave_1);
            // 
            // labelDescontos
            // 
            this.labelDescontos.AutoSize = true;
            this.labelDescontos.Font = new System.Drawing.Font("Microsoft Tai Le", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescontos.Location = new System.Drawing.Point(601, 56);
            this.labelDescontos.Name = "labelDescontos";
            this.labelDescontos.Size = new System.Drawing.Size(43, 49);
            this.labelDescontos.TabIndex = 11;
            this.labelDescontos.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(582, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Descontos(Pontos):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(505, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 49);
            this.label6.TabIndex = 9;
            this.label6.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(511, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cliente";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonEnviarEmailXml);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.textBoxObj);
            this.tabPage2.Controls.Add(this.checkBoxXML);
            this.tabPage2.Controls.Add(this.textBoxEmail);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.checkBoxEmail);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(780, 353);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Email";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 379);
            this.tabControl1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(3, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 408);
            this.panel2.TabIndex = 4;
            // 
            // frmItemSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 621);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmItemSaida";
            this.Text = "frmItemSaida";
            this.Load += new System.EventHandler(this.frmItemSaida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericVenPorduto)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxEmail;
        private System.Windows.Forms.NumericUpDown numericVenPorduto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxPorduto;
        private System.Windows.Forms.Button buttonEnviarEmailXml;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxObj;
        private System.Windows.Forms.CheckBox checkBoxXML;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelVLFINAL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelPontos;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelTelefone;
        private System.Windows.Forms.Label labelRg;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label labelDescontos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LABORATORIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preco;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTIDADE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxFormaDePagamento;
        private System.Windows.Forms.Label label14;
    }
}