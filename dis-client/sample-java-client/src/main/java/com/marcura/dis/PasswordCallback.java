package com.marcura.dis;

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

import javax.security.auth.callback.Callback;
import javax.security.auth.callback.CallbackHandler;
import javax.security.auth.callback.UnsupportedCallbackException;

import org.apache.wss4j.common.ext.WSPasswordCallback;

/**
 * Callback class used by WSS4J to retrieve passwords for private keys.
 * Passwords are configurable via the passwords map.
 *
 */
public class PasswordCallback implements CallbackHandler {

	private Map<String, String> passwords = new HashMap<String, String>();

	public void handle(Callback[] callbacks) throws IOException, UnsupportedCallbackException {
		for (int i = 0; i < callbacks.length; i++) {
			WSPasswordCallback pc = (WSPasswordCallback) callbacks[i];
			pc.setPassword(passwords.get(pc.getIdentifier()));
		}
	}

	public Map<String, String> getPasswords() {
		return passwords;
	}

	public void setPasswords(Map<String, String> passwords) {
		this.passwords = passwords;
	}
}
