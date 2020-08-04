package com.marcura.dis;

import java.io.ByteArrayOutputStream;
import java.io.StringReader;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.bind.Unmarshaller;
import javax.xml.namespace.QName;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.ApplicationContext;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.dadesk.dis.schema.DaDeskDataExchange;
import com.dadesk.dis.schema.GetPortcallStatusInfoRequest;
import com.dadesk.dis.schema.PortcallStatusInfoResponseType;

public class SampleClient {
	
	private static Logger log = LoggerFactory.getLogger(SampleClient.class);

	/**
	 * Creates and sends a request based on the assumption that developer will be
	 * working fully in Java and constructing all the objects in Java. All the SOAP,
	 * XML and WS-Security will be handled by the framework and the developer will
	 * not have to deal with any of that.
	 * 
	 * @param disClient
	 */
	public static void javaSample(DaDeskDataExchange disClient) {
		// Create new portcall status request
		GetPortcallStatusInfoRequest portcallStatusRequest = new GetPortcallStatusInfoRequest();
		portcallStatusRequest.setInterfaceUniqueReference("PTO-170001");
		portcallStatusRequest.setPrincipalId("50001");

		// Call portcall status info
		PortcallStatusInfoResponseType portcallStatusResponse = disClient.getPortcallStatusInfo(portcallStatusRequest);

		// Print the portcall reference number from the response
		log.info("Reference number: " + portcallStatusResponse.getPortCallRef());
		log.info("Vessel: " + portcallStatusResponse.getVessel().getName());
	}

	/**
	 * Creates and sends a request based on the assumption that the developer will
	 * be having the request already in XML and simply requires the framework to
	 * deal with the additional information for SOAP and WS-Security.
	 * 
	 * @param disClient
	 * @throws JAXBException
	 */
	public static void xmlSample(DaDeskDataExchange disClient) throws JAXBException {
		// initialise the JAXB marshaller and unmarshaller
		JAXBContext jaxbContext = JAXBContext.newInstance("com.dadesk.dis.schema");
		Unmarshaller unmarshaller = jaxbContext.createUnmarshaller();
		Marshaller marshaller = jaxbContext.createMarshaller();

		String xmlRequest = "<sch:getPortcallStatusInfoRequest xmlns:sch=\"http://www.dadesk.com/dis/schema\">\r\n"
				+ "	<sch:principalId>50001</sch:principalId>\r\n"
				+ "	<sch:interfaceUniqueReference>PTO-170001</sch:interfaceUniqueReference>\r\n"
				+ "</sch:getPortcallStatusInfoRequest>";

		// Read request from XML file and convert to Java object
		GetPortcallStatusInfoRequest portcallStatusRequest = (GetPortcallStatusInfoRequest) unmarshaller
				.unmarshal(new StringReader(xmlRequest));

		// Call portcall status info
		PortcallStatusInfoResponseType portcallStatusResponse = disClient.getPortcallStatusInfo(portcallStatusRequest);

		// Convert the response into XML
		ByteArrayOutputStream baos = new ByteArrayOutputStream();
		marshaller.marshal(new JAXBElement<PortcallStatusInfoResponseType>(
				new QName("http://www.dadesk.com/dis/schema", "getPortcallStatusInfoResponse"),
				PortcallStatusInfoResponseType.class, portcallStatusResponse), baos);
		log.info(baos.toString());

	}

	public static void main(String[] args) throws Exception {

		// Start Spring
		ApplicationContext context = new ClassPathXmlApplicationContext("spring-context.xml");

		// Get the CXF client
		DaDeskDataExchange disClient = (DaDeskDataExchange) context.getBean("disClient");

		log.info("Running Java Sample");
		javaSample(disClient);
		log.info("Running XML Sample");
		xmlSample(disClient);

		// Close Spring
		((ConfigurableApplicationContext) context).close();
	}

}
