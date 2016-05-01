using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{
    public partial class frmDispClient : Form
    {
        private NotificationPoller.userType user;
        private NotificationPoller.NotificationPollerClient disNotificationClient = new NotificationPoller.NotificationPollerClient();

        public frmDispClient()
        {
            InitializeComponent(); 
        }

        //Simple method to convert notifications to XML for display purposes
        private String convertToXml(NotificationPoller.DaDeskEventNotificationsType notifications)
        {
            StringWriter textWriter = new StringWriter();
            XmlSerializer serialiser = new XmlSerializer(notifications.GetType());
            serialiser.Serialize(textWriter, notifications);
            return textWriter.ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Login and save user details
            user = disNotificationClient.login(new NotificationPoller.loginType { username = txtUsername.Text, password = txtPassword.Text });
            txtConsole.Text += (user.token + "\n");
            btnPoll.Enabled = true;
        }

        private void btnPoll_Click(object sender, EventArgs e)
        {
            using (new OperationContextScope(disNotificationClient.InnerChannel))
            {
                //Adding token to HTTP Request
                var tokenProperty = new HttpRequestMessageProperty();
                tokenProperty.Headers["token"] = user.token;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = tokenProperty;

                //poll for notifications
                NotificationPoller.DaDeskEventNotificationsType notifications = disNotificationClient.poll(txtPrincipalId.Text);
                //Converting notifications to XML ONLY for display purposes. Here you can work with the .net objects directly
                txtConsole.Text += (convertToXml(notifications) + "\n");
            }

        }
    }
}
