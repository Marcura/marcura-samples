package com.marcura.dis;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.xml.namespace.QName;

import org.apache.cxf.binding.soap.SoapMessage;
import org.apache.cxf.binding.soap.interceptor.AbstractSoapInterceptor;
import org.apache.cxf.headers.Header;
import org.apache.cxf.interceptor.Fault;
import org.apache.cxf.jaxb.JAXBDataBinding;
import org.apache.cxf.phase.Phase;
import org.springframework.util.StringUtils;

import jakarta.xml.bind.JAXBException;
import jakarta.xml.bind.annotation.XmlElement;

/**
 * SOAP Interceptor to add the DIS Principal ID to the request. Header will look
 * like the following:
 * 
 * <wsse:UsernameToken xmlns:wsse="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd">
 * 	<wsse:Username>50001</wsse:Username> 
 * </wsse:UsernameToken>
 *
 */
public class DisUsernameOutInterceptor extends AbstractSoapInterceptor {

	private String principalId;

	private static final String PREFIX = "wsse";
	private static final String NAMESPACE = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
	private static final String USERNAME_TOKEN = "UsernameToken";
	private static final String USERNAME = "Username";

	private JAXBDataBinding dataBinding;

	/**
	 * Username Token class for Principal ID. Principal ID will be populated in
	 * the Username field.
	 *
	 */
	public static class UsernameToken {

		private String Username;

		public UsernameToken() {
			super();
		}

		public UsernameToken(String username) {
			super();
			Username = username;
		}

		@XmlElement(name = USERNAME, namespace = NAMESPACE)
		public String getUsername() {
			return Username;
		}

		public void setUsername(String username) {
			Username = username;
		}
	}

	/**
	 * Initialise data binding object with namespace and prefix
	 * 
	 * @throws JAXBException
	 */
	public DisUsernameOutInterceptor() throws JAXBException {
		super(Phase.POST_LOGICAL);

		Map<String, String> namespaceMap = new HashMap<String, String>();
		namespaceMap.put(NAMESPACE, PREFIX);
		dataBinding = new JAXBDataBinding(UsernameToken.class);
		dataBinding.setNamespaceMap(namespaceMap);
	}

	/**
	 * Add the header to the soap message
	 */
	@Override
	public void handleMessage(SoapMessage message) throws Fault {
		if (StringUtils.isEmpty(principalId)) {
			throw new Fault(new Exception("Principal ID cannot be empty"));
		}

		List<Header> headers = message.getHeaders();

		Header header = new Header(new QName(NAMESPACE, USERNAME_TOKEN, PREFIX), new UsernameToken(principalId),
				dataBinding);
		message.getHeaders().add(header);
		message.put(Header.HEADER_LIST, headers);

	}

	public String getPrincipalId() {
		return principalId;
	}

	public void setPrincipalId(String principalId) {
		this.principalId = principalId;
	}

}
