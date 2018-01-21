using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Marcura.Dis.Client.Sample
{
    class DisInspectorBehavior : IEndpointBehavior
    {

        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.TextBox txtResponse;

        public DisInspectorBehavior(System.Windows.Forms.TextBox txtRequest, System.Windows.Forms.TextBox txtResponse)
        {
            this.txtRequest = txtRequest;
            this.txtResponse = txtResponse;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new DisMessageInspector(this.txtRequest, this.txtResponse));
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}
