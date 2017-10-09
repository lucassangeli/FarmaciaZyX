using Farmacia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Farmacia.Utility
{
    public static class XMLCreator
    {
        public static string MyEmail = @"farmcsharp@gmail.com";
        public static string MySenha = @"FARMACIAFODA";

        public static string Creat(Venda venda)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    venda = context.Venda.OrderBy(x => x.Id == venda.Id).First();



                    using (SaveFileDialog save = new SaveFileDialog())
                    {
                        save.Filter = "xml | *.xml";
                        save.DefaultExt = "xml";
                        if (DialogResult.OK == save.ShowDialog())
                            using (XmlTextWriter writer = new XmlTextWriter((save.FileName).ToString(), null))
                            {
                                writer.WriteStartDocument();
                                writer.Formatting = Formatting.Indented;
                                writer.WriteStartElement("Venda");
                                foreach (var item in venda.ItemVenda)
                                {
                                    writer.WriteAttributeString("Item", item.Produto.ValorVenda.ToString());
                                    writer.WriteAttributeString("Quantidade", item.Quantidade.ToString());
                                }

                                writer.WriteEndElement();
                            }
                        return save.FileName;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao criar XML:" + ex.Message);
            }
            return string.Empty;
        }


        public static bool Enviar(string caminho, StringBuilder obj, string email, string nomeDest)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.To.Add(new MailAddress(email, nomeDest));
                    mail.Priority = MailPriority.High;
                    mail.Subject = string.Format("Compra dia {0}", DateTime.Now);
                    if (!string.IsNullOrWhiteSpace(obj.ToString()))
                        mail.Body = obj.ToString();

                    System.Net.Mail.Attachment attachment;
                    if (!String.IsNullOrWhiteSpace(caminho))
                    {
                        attachment = new System.Net.Mail.Attachment(caminho);
                        mail.Attachments.Add(attachment);
                    }

                    mail.From = new MailAddress(MyEmail);
                    SmtpClient SmtpServer = new SmtpClient("smtp.outlook.com");
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(MyEmail, MySenha);
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    return true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return false;
        }
    }
}

