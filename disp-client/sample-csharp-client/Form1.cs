using System;
using System.IO;
using System.Net;
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

            //force the application to use TLSv1.2 for HTTPS connection as TLSv1.0 is the default for .NET 4.5 and below
            //DIS Poller does not support SSL, TLSv1 and TLSv1.1 anymore. TLSv1.2 is the minimun requirement
            //more information on TLS setup for .NET framework available here: https://blogs.perficient.com/2016/04/28/tls-1-2-and-net-support
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
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
