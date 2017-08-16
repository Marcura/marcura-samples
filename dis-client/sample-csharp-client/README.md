# Import

- Download the project on your local environment using git
- Open the .csproj using Visual Studio
- At this point the project will not build as it is required to generate the client classes from the WSDL
- In the solution explorer, open "Service References", DIS should appear
- Right click on DIS and choose "Update Service Reference"
- This should start the process of going to the WSDL externally and generate the client classes
- Rebuild the project by clicking Build, Rebuild Marcura.Dis.Client.Sample

# Configuration

Configuration is all done in App.config file. This section will explain which fields need to be changed to get your sample C# client up and running. This section will assume that the certificates have already been imported into Windows using certmgr.msc application.

- Open App.config
- Change &lt;add key="principalId" value="50001" /&gt; with the principal identifier that was given to you
- Update &lt;clientCertificate&gt; by changing the subject of the x509 certificate
  - This is the private key
- Update &lt;defaultCertificate&gt; by changing the serial number of DIS public key
  - This will change depending on whether you are connecting to test or production environment
  - The one set up in GitHub is the test certificate
  - This can be changed to look up by subject but make sure that only either test or production certificate is available in your certificate manager otherwise it will fail due to finding both
-  Update &lt;wsse:Username&gt;50001&lt;/wsse:Username&gt; with the principal identifier that was given to you
- The endpoint by default it is set to the CUAT test environment address="http://disweb.cuat.da-desk.com/disweb/1.0/spring-ws/" inside the tag &lt;endpoint&gt;
  - Update this as necessary to point to test or production environment
  
  ## Note
  
  Please note that this application requires setting up of certificates on DA-Desk side. Please contact DA-Desk before starting.
  Please also make sure that you have downloaded the test/production DIS public certificate and have this imported into your Windows system.
