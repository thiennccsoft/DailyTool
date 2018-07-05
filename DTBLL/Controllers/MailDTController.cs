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
                SendEmail(item, BodyUserNotReport(item));
            }
        }

        public void SendMailToAdmin()
        {
            List<vUsers> admins = udm.getAdmins();
            List<vItems> items = idm.getItemsNotFinish();
            List<vUsers> users = udm.getUsersNotReport();
            foreach (var item in admins)
            {
                SendEmail(item, BodyForAdmin(items, users));
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

        private String BodyUserNotReport(vUsers user)
        {
            String content = "";
            content += "<div style='text-align: center;'>" +
                       "<h1 style = 'color: red;' >---CẢNH BÁO---</h1>" +
                       "<p>Chào <strong>" + user.UserName + "</strong>!</p>" +
                       "<p> Bạn quên báo cáo ???</p>" +
                       "<p><a href = ''> Báo cáo ngay</a></p>" +
                       "</div> ";
            return content;
        }

        private String BodyForAdmin(List<vItems> items, List<vUsers> users)
        {
            String content = "";

            content += "<div style = 'text-align: center;'>" +
                       "<h1 style = 'color: red;'> Report </h1>" +
                       "<p><strong> Danh sách thành viên chưa báo cáo:</strong></p>" +
                       "<table style = 'border: 1px solid #ccc; margin: 0 auto;'>" +
                       "<tr>" +
                       "<th> UserID </th>" +
                       "<th> UserName </th>" +
                       "</tr><hr/>";
            foreach (var item in users)
            {
                content += "<tr>" +
                           "<td>" + item.UserId + "</td>" +
                           "<td>" + item.UserName + " </td>" +
                           "</tr>";
            }
            content += "</table>" +
                       "<p><strong> Danh sách công việc chưa hoàn thành:</strong></p>" +
                       "<table style = 'border: 1px solid #ccc; margin: 0 auto;' cellpadding = '5px'>" +
                       "<tr>" +
                       "<th> Công việc </th>" +
                       "<th> Ngày bắt đầu </th>" +
                       "<th> Ngày kết thúc </th>" +
                       "</tr>";
            foreach (var item in items)
            {
                content += "<tr>" +
                           "<td>" + item.Title + "</td>" +
                           "<td>" + item.Created_At.ToString("d") + "</td>" +
                           "<td>" + item.Finish_At?.ToString("dd-MM-yyyy") + "</td>" +
                           "</tr>";
            }
            content+="</table>" +
                     "</div>";

            return content;
        }

    }
}
