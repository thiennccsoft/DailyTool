using DTModels.Models;
using DTValueObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DTBLL.Controllers
{
    public class MailDTController
    {

        private UserModel udm = new UserModel();
        private ItemModel idm = new ItemModel();

        public void SendToUserNotReport()
        {
            List<vUsers> lst = udm.getUsersNotReport();
            if (lst.Count == 0)
                return;
            foreach (vUsers item in lst)
            {
                SendEmail(item, BodyUserNotReport(item, ReadHtml("MailToUser.html")));
            }
        }

        public void SendMailToAdmin()
        {
            List<vUsers> admins = udm.getAdmins();
            List<vItems> items = idm.getItemsNotFinish();
            List<vUsers> users = udm.getUsersNotReport();
            foreach (var item in admins)
            {
                SendEmail(item, BodyForAdmin(items, users, ReadHtml("MailToAdmin.html")));
            }
        }

        public void SendEmail(vUsers user, String body)
        {
            MailMessage mail = new MailMessage("quan.droidvpn@gmail.com", user.Email);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("quan.droidvpn@gmail.com", "quan1997");
            mail.IsBodyHtml = true;
            mail.Subject = "Report";
            mail.Body = body;
            client.Send(mail);
        }

        private String ReadHtml(String fileName)
        {
            try
            {
                String[] str = File.ReadAllLines("Temp/" + fileName);
                String result = "";
                foreach (String item in str)
                {
                    result += item;
                }
                return result;
            }
            catch
            {
                return "";
            }

        }

        private String BodyUserNotReport(vUsers user, String htmlTemplate)
        {
            return htmlTemplate.Replace("{{UserName}}", user.UserName);
        }

        private String BodyForAdmin(List<vItems> items, List<vUsers> users, String htmlTemplate)
        {
            String contentUserNotReport = "";
            foreach (vUsers user in users)
            {
                contentUserNotReport += ReadHtml("UserNotReportPartial.html")
                .Replace("{{UserName}}", user.UserName)
                .Replace("{{Email}}", user.Email);
            }
            String contentWorkNotFinish = "";
            foreach (vItems item in items)
            {
                contentWorkNotFinish += ReadHtml("WorkNotFinish.html")
                .Replace("{{WorkName}}", item.Title)
                .Replace("{{DateStart}}", item.Created_At.ToString("dd-MM-yyyy"))
                .Replace("{{DateEnd}}", item.Finish_At?.ToString("dd-MM-yyyy"));
            }
            return htmlTemplate.Replace("{{NowDay}}", DateTime.Now.ToString("dd-MM-yyyy"))
            .Replace("{{ContentUserNotReport}}", contentUserNotReport)
            .Replace("{{ContentWorkNotFinish}}", contentWorkNotFinish);
        }

    }
}
