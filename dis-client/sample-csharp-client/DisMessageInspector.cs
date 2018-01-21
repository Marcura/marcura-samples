using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Marcura.Dis.Client.Sample
{
    class DisMessageInspector : IClientMessageInspector
    {
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.TextBox txtResponse;

        public DisMessageInspector(System.Windows.Forms.TextBox txtRequest, System.Windows.Forms.TextBox txtResponse)
        {
            this.txtRequest = txtRequest;
            this.txtResponse = txtResponse;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            txtResponse.Text = reply.ToString();
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            txtRequest.Text = request.ToString();
            return request;
        }
    }
}
