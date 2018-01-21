using System;
using System.Windows.Forms;
using System.Configuration;

namespace Marcura.Dis.Client.Sample
{
    public partial class MainDialog : Form
    {
        private readonly DIS.DaDeskDataExchangeClient disClient;
        Boolean error = false;

        public MainDialog()
        {
            InitializeComponent();
            txtPrincipalId.Text = ConfigurationManager.AppSettings["principalId"];

            try {
                disClient = new DIS.DaDeskDataExchangeClient();

                //This is not required in real implementations. This is there to show the XML request and response on the screen
                disClient.Endpoint.EndpointBehaviors.Add(new DisInspectorBehavior(txtRequest, txtResponse));
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }

        }

        private void btnGetPortCallStatus_Click(object sender, EventArgs e)
        {
            try {
                // call the method, based on input parameters
                var response = disClient.getPortcallStatusInfo(new DIS.getPortcallStatusInfoRequest() { principalId = txtPrincipalId.Text, interfaceUniqueReference = txtInterfaceUniqueRef.Text });

                // process the result
                MessageBox.Show(string.Format("The returned port call reference number: {0}", response.portCallRef));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreatePortCall_Click(object sender, EventArgs e)
        {

            try {
                // call the method, based on input parameters
                var request = new DIS.createPortCallRequest
                {
                    createPortCall = new DIS.CreatePortCallType
                    {
                        //please make sure you use your own ids which are mapped in DIS
                        principalId = txtPrincipalId.Text,
                        interfaceUniqueReference = txtInterfaceUniqueRef.Text,
                        company = new DIS.CpcVesselOperatingCompanyType { legalEntityId = "108" },
                        vessel = new DIS.CpcVesselType { vesselId = "178694", name = "Bertina" },
                        ServiceLocation = new DIS.CpcServiceLocationType { portCode = "104493" },
                        VesselOperatingCompanyUserId = new DIS.UserIdType { userId = "DADESK" },
                        ETA = Convert.ToDateTime("2015-05-31 12:00:00"),
                        Activity = new DIS.CpcActivityType[] {
                        new DIS.CpcActivityType
                        {
                            cargoDetails = new DIS.CpcCargoType {
                                cargoName = "Cruide Oil",
                                quantity = 10000,
                                QuantityUnit = DIS.QuantityUnitType.MetricTonnes
                            },
                            typeOfActivity = DIS.TypeOfActivityType.Discharging
                        }
                    }
                    }
                };

                var response = disClient.createPortCall(request);

                // process the result
                MessageBox.Show(String.Format("The returned port call reference number: {0}", response.portCallRef));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGetProforma_Click(object sender, EventArgs e)
        {
            try {
                var response = disClient.getProformaInvoiceOutput(new DIS.getProformaInvoiceOutputRequest() { daEvent = "APPROVED", interfaceUniqueReference = txtInterfaceUniqueRef.Text });

                // process the result, in this case let's just show the payment amount currency and value of the first invoice
                MessageBox.Show(String.Format("Invoice Value {0} {1}", response.Invoices[0].InvoiceHeader.paymentAmout[0].DAPaymentAmount.DACurrency, response.Invoices[0].InvoiceHeader.paymentAmout[0].DAPaymentAmount.Value));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainDialog_Shown(object sender, EventArgs e)
        {
            if (error)
            {
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
