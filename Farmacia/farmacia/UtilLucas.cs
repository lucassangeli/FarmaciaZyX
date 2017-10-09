using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia
{
     public  class UtilLucas
    {


        public bool gerrarExcel(DataGridView view)
        {

            SaveFileDialog SAVE = new SaveFileDialog();
            SAVE.Title = "Caminho para Salvar!";
            //http://www.macoratti.net/14/06/c_svdlg1.htm
            //https://msdn.microsoft.com/pt-br/library/system.xml.serialization.xmlserializer(v=vs.110).aspx
            //https://www.google.com.br/search?q=xml+Seriali%C3%A7%C3%A3obel+C%23&oq=xml+Seriali%C3%A7%C3%A3obel++C%23&aqs=chrome..69i57j0l5.45939j0j4&sourceid=chrome&ie=UTF-8#q=xml+serializable+c%23+example
            if (SAVE.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet ws = (Worksheet)wb.Worksheets.get_Item(1);

                ws.Name = "Nome da Pasta";
                for (int i = 0; i < view.Rows.Count; i++)
                {
                    for (int j = 0; j < view.Columns.Count; j++)
                    {
                        Microsoft.Office.Interop.Excel.Range ce = (ws.Cells[i + 1, j + 1] as Microsoft.Office.Interop.Excel.Range);

                        ce.Value2 = view.Rows[i].Cells[j].Value.ToString();
                    }

                }
                wb.SaveAs(SAVE.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                excel.Quit();
                return true;
            }
            return false;

        }

    }
}
