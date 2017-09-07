# Building

- Download the project on your local environment using git
- The project is built with Maven
  - Is set up to automatically generate Java classes from Test Environment WSDL
  - Check cxf-codegen-plugin in the pom.xml
- Building the project can be done by executing the following Maven command

```bash
mvn package
```

The project can as well be imported into your favourite IDE. In case of Eclipse with M2E support, the following steps will guide you to import the project:

- Click File
- Import
- Existing Maven Project
- Browse to the downloaded location
- Select the project and click finish

## Note

If your favourite IDE will try to run `mvn generate-sources` every time the save button is clicked (build automatically), it might be the case that Maven will try to re-download the whole WSDL and XSDs every time making the whole process extremely slow. To avoid this, once the Java classes are generated at least once, the cxf-codegen-plugin can be disabled by setting `<phase>none</phase>` instead of `<phase>generate-sources</phase>` in the pom.xml.

# Configuration

Configuration is all done in dis-client.properties and dis-client-wss4j.properties file. This section will explain which fields need to be changed to get your sample Java client up and running. This section will assume that the certificates have already been imported into a Java keystore and the keystore is available in the classpath of the sample application.

- Open dis-client.properties
- Set `dis.url` with the Production or Test DIS URL
  - The default one is set to the Test URL
- Set `dis-client.principalId` to the provided Principal ID
- Set `dis-client.private-key.alias` to the alias of your private key
  - Alias is the name of this private key within your keystore
- Set `dis-client.private-key.password` with the private key password
- Set `dis-client.public-key.alias` with the alias of DIS public certificate
  - Alias is the name of this public key within your keystore
- Open dis-client-wss4j.properties
- Set `org.apache.wss4j.crypto.merlin.keystore.file` to the keystore
- Set `org.apache.wss4j.crypto.merlin.keystore.password` to the keystore password
  
# Running the Application

The application can be executing by running `com.marcura.dis.SampleClient` which will do the following:

- Start Spring application
- Get CXF DIS Client with all WS-Security configuration
- Generate a Portcall status info request using a ficticious principal ID and an Interface Unique Reference (IUR)
- Call DIS and print the reference number from the response on screen

The application must be updated using your principal ID and an IUR for your company before executed. 

# Application Architecture

The sample application is a Spring application where the Spring configuration can be found under `src/main/resources/spring-context.xml`. CXF is used as the Web Services library and WSS4J is used for Web Service Security. There are 6 classes configured in Spring which will be briefly explained here below:

- passwordCallback
  - This is custom class which WSS4J will use to retrieve the private key password
  - WSS4J will try to find the password by providing the alias of the key
  - This class has an Map with key-value properties of alias-password
  - The value of the map is injected through Spring properties
- usernameInterceptor
  - Custom class to add DIS principal ID to message
  - PrincipalId is injected through Spring properties
- in/outInterceptor
  - WSS4J class with DIS necessary security configurations
  - Applying Signature, Encryption and Timestamp WS-\* security features
  - passwordCallback class defined above is used to be able to access private key password
  - Requires configuration of signature and encryption key aliases
- clientFactory
  - CXF Factory class to create a DIS Client
  - Configuration includes the address and the in and out interceptors
- disClient
  - The actual CXF Client class that can be used to call DIS

## Note

Please note that this application requires setting up of certificates on DA-Desk side. Please contact DA-Desk before starting. Please also make sure that you have downloaded the test/production DIS public certificate and have this imported into your keystore.

# Other References

- http://cxf.apache.org/docs/maven-cxf-codegen-plugin-wsdl-to-java.html
- http://cxf.apache.org/docs/how-do-i-develop-a-client.html
- http://cxf.apache.org/docs/ws-security.html
- https://ws.apache.org/wss4j/using.html
- https://ws.apache.org/wss4j/config.html
