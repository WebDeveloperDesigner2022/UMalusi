using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.ViewModel;
using Xamarin.Forms;

namespace UMelusiTrack
{
    public partial class ShopPage : ContentPage
    {
        public ShopPage()
        {
            var vm = new OrderingVM();
            InitializeComponent();
            MessagingCenter.Subscribe<OrderingVM, string>(this, "Ordering Alert", (sender, username) => {
                DisplayAlert("", username, "ok");
            });
            this.BindingContext = vm;
        }

        private void CancelBtn(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void orderBtn(object sender, EventArgs e)
        {
           /* try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("umalusi@yahoo.com");
                mail.To.Add(txtTo.Text);
                mail.Subject = txtSubject.Text;
                mail.Body = txtBody.Text;

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("asiphemiladyncombo@gmail.com", "");

                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                DisplayAlert("Faild", ex.Message, "OK");
            }
           */
        }

        private void BtnSend_Clicked(object sender, EventArgs e)
        {

        }
    }
}
