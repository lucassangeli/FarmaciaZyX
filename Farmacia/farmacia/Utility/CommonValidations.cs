using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Farmacia.Utility;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Farmacia
{
    public static class CommonValidations
    {
        public static void gerarPDF(string path)
        {
            FileInfo dir = new FileInfo(path);
            StringBuilder texto = new StringBuilder();
            FileInfo fl = new FileInfo(path);
            fl.GetAccessControl();
            DirectoryInfo pir = new DirectoryInfo(fl.FullName.ToString());
            string[] lines = System.IO.File.ReadAllLines(path);
            Document doc = new Document(iTextSharp.text.PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            doc.AddCreationDate();
            string caminho = fl.FullName + ".pdf";
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
            doc.Open();
            string dados = "";
            foreach (string line in lines)
            {
                Paragraph paragrafo = new Paragraph(dados);
                paragrafo.Add(line.ToString());
                doc.Add(paragrafo);
            }
            doc.Close();
            System.Diagnostics.Process.Start(caminho);

        }

        public static bool gerarXML(DataGridView view)
        {
            string caminho = @"C:\MyDir\MySubDir\myfile.ext";
            //Server.MapPath serve para pegar o caminho completo no sistema.
            //Server.MapPath("~/contatos.xml") = c:\inetpub\wwwroot\site\contatos.xml
            string caminhoDoArquivo = Path.GetDirectoryName(caminho);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(caminhoDoArquivo); // Carregando o arquivo

            // Pegando o elemento pelo nome da TAG
            XmlNodeList xmlList = xmlDoc.GetElementsByTagName("contato");

            // Usando for para imprimir na tela
            for (int i = 0; i < xmlList.Count; i++)
            {
                string nome = xmlList[i]["nome"].InnerText;
                string email = xmlList[i]["email"].InnerText;
            }

            // Usando foreach para imprimir na tela
            foreach (XmlNode xm in xmlList)
            {
                string nome = xm["nome"].InnerText;
                string email = xm["email"].InnerText;
            }

            return true;
        }

        public static bool gerarExcel(DataGridView view)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Caminho para salvar:";
            //http://www.macoratti.net/14/06/c_svdlg1.htm
            //https://msdn.microsoft.com/pt-br/library/system.xml.serialization.xmlserializer(v=vs.110).aspx
            //https://www.google.com.br/search?q=xml+Seriali%C3%A7%C3%A3obel+C%23&oq=xml+Seriali%C3%A7%C3%A3obel++C%23&aqs=chrome..69i57j0l5.45939j0j4&sourceid=chrome&ie=UTF-8#q=xml+serializable+c%23+example
            if (save.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet ws = (Worksheet)wb.Worksheets.get_Item(1);

                for (int i = 0; i < view.Rows.Count; i++)
                {
                    for (int j = 0; j < view.Columns.Count; j++)
                    {
                        Microsoft.Office.Interop.Excel.Range ce = (ws.Cells[i + 1, j + 1] as Microsoft.Office.Interop.Excel.Range);
                        ce.Value2 = view.Rows[i].Cells[j].Value.ToString();
                    }
                }

                wb.SaveAs(save.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excel.Quit();
                MessageBox.Show(string.Format("O arquivo foi salvo com sucesso no diretório: {0} ", save.FileName));
                return true;
            }
            return false;
        }

        public static bool IsRG(string rg)
        {
            //Elimina da string os traços, pontos e virgulas,
            rg = rg.Replace("-", "").Replace(".", "").Replace(",", "");

            //Verifica se o tamanho da string é 9
            if (rg.Length == 8)
            {
                int[] n = new int[8];

                // Obtém cada um dos caracteres do rg
                n[0] = Convert.ToInt32(rg.Substring(0, 1));
                n[1] = Convert.ToInt32(rg.Substring(1, 1));
                n[2] = Convert.ToInt32(rg.Substring(2, 1));
                n[3] = Convert.ToInt32(rg.Substring(3, 1));
                n[4] = Convert.ToInt32(rg.Substring(4, 1));
                n[5] = Convert.ToInt32(rg.Substring(5, 1));
                n[6] = Convert.ToInt32(rg.Substring(6, 1));
                // n[7] = Convert.ToInt32(rg.Substring(7, 1));
                // n[8] = Convert.ToInt32(rg.Substring(8, 1));

                // Aplica a regra de validação do RG, multiplicando cada digito por valores pré-determinados
                n[0] *= 2;
                n[1] *= 3;
                n[2] *= 4;
                n[3] *= 5;
                n[4] *= 6;
                n[5] *= 7;
                n[6] *= 8;
                //  n[7] *= 9;
                // n[8] *= 100;

                // Valida o RG
                int somaFinal = n[0] + n[1] + n[2] + n[3] + n[4] + n[5] + n[6] /*+ n[7] + n[8]*/;
                if ((somaFinal % 11) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool IsCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool IsCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static bool IsEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.IsMatch(email);
        }

        public static bool IsValidString(int min, int max, string stringToBeValidated)
        {
            return stringToBeValidated.Length >= min &&
                   stringToBeValidated.Length <= max;
        }
    }
}
