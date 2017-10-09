using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia
{
    public class Bridge
    {

        public static void DefineType(Object obj)
        {

            try
            {
                if (obj != null)
                {
                    string nome = obj.GetType().FullName.ToLower();

                    if (nome.Trim().ToLower().Contains("cliente"))
                    {

                    }
                    else
                        if (nome.Trim().ToLower().Contains("entrada"))
                        {

                        }
                        else
                            if (nome.Trim().ToLower().Contains("fornecedor"))
                            {

                            }
                            else
                                if (nome.Trim().ToLower().Contains("funcionario"))
                                {

                                }
                                else
                                    if (nome.Trim().ToLower().Contains("itemvenda"))
                                    {

                                    }
                                    else
                                        if (nome.Trim().ToLower().Contains("itemEntrada"))
                                        {

                                        }
                                        else
                                            if (nome.Trim().ToLower().Contains("produto"))
                                            {

                                            }
                                            else
                                                if (nome.Trim().ToLower().Contains("venda"))
                                                {

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
