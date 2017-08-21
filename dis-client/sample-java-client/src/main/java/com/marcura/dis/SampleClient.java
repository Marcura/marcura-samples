package com.marcura.dis;
import org.springframework.context.ApplicationContext;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.dadesk.dis.schema.DaDeskDataExchange;
import com.dadesk.dis.schema.GetPortcallStatusInfoRequest;
import com.dadesk.dis.schema.PortcallStatusInfoResponseType;

public class SampleClient {
	
	public static void main(String[] args){
		
		//Start Spring
		ApplicationContext context = new ClassPathXmlApplicationContext("spring-context.xml");
		
		//Get the CXF client
		DaDeskDataExchange disClient = (DaDeskDataExchange) context.getBean("disClient");
		
		//Create new portcall status request
		GetPortcallStatusInfoRequest portcallStatusRequest = new GetPortcallStatusInfoRequest();
		portcallStatusRequest.setInterfaceUniqueReference("PTO-170001");
		portcallStatusRequest.setPrincipalId("50001");
		
		//Call portcall status info
		PortcallStatusInfoResponseType portcallStatusResponse = disClient.getPortcallStatusInfo(portcallStatusRequest);
		
		//Print the porcall reference number from the response
		System.out.println("Reference number: " + portcallStatusResponse.getPortCallRef());
		
		//Close Spring
		((ConfigurableApplicationContext)context).close();
	}

}
