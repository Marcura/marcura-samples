package com.marcura.manifestdesk.data.client.data;

import java.util.List;

import com.marcura.manifestdesk.data.api.ManifestDeskDataClient;
import com.marcura.manifestdesk.data.resource.countries.model.CountriesGETQueryParam;
import com.marcura.manifestdesk.data.resource.countries.model.CountriesGETResponse;
import com.marcura.manifestdesk.data.resource.hscodes.model.HscodesGETQueryParam;
import com.marcura.manifestdesk.data.resource.hscodes.model.HscodesGETResponse;
import com.marcura.manifestdesk.data.resource.mappings.model.MappingsGETQueryParam;
import com.marcura.manifestdesk.data.resource.mappings.model.MappingsGETResponse;
import com.marcura.manifestdesk.data.resource.sanctions.model.SanctionsGETQueryParam;
import com.marcura.manifestdesk.data.resource.sanctions.model.SanctionsGETResponse;
import com.marcura.manifestdesk.data.resource.users.userId.sessions.model.SessionsPOSTBody;
import com.marcura.manifestdesk.data.resource.users.userId.sessions.model.SessionsPOSTResponse;

public class ManifestDeskData {
	
	private String username;
	private String password;
	
	protected ManifestDeskDataClient client;
	
	private List<CountriesGETResponse> countries;
	private List<SanctionsGETResponse> sanctions;
	private List<HscodesGETResponse> hsCodes;
	private List<MappingsGETResponse> mappings;
	
	public ManifestDeskData(String username, String password, String url) {
		super();
		this.username = username;
		this.password = password;
		
		client = ManifestDeskDataClient.create(url);
	}

	public void download(String hsCodeType){

		// Login to get a token
		SessionsPOSTResponse session = client.users.userId(username).sessions
				.post(new SessionsPOSTBody(username, password));

		// Get and list of countries from API
		countries = client.countries
				.get(new CountriesGETQueryParam(session.getToken()));

		// Get sanctions from API
		sanctions = client.sanctions
				.get(new SanctionsGETQueryParam(session.getToken()));

		// Get HS Codes from API
		hsCodes = client.hscodes
				.get(new HscodesGETQueryParam(hsCodeType, session.getToken()));

		// Get Mappings from API
		mappings = client.mappings
				.get(new MappingsGETQueryParam(hsCodeType, session.getToken()));
	}

	public List<CountriesGETResponse> getCountries() {
		return countries;
	}

	public void setCountries(List<CountriesGETResponse> countries) {
		this.countries = countries;
	}

	public List<SanctionsGETResponse> getSanctions() {
		return sanctions;
	}

	public void setSanctions(List<SanctionsGETResponse> sanctions) {
		this.sanctions = sanctions;
	}

	public List<HscodesGETResponse> getHsCodes() {
		return hsCodes;
	}

	public void setHsCodes(List<HscodesGETResponse> hsCodes) {
		this.hsCodes = hsCodes;
	}

	public List<MappingsGETResponse> getMappings() {
		return mappings;
	}

	public void setMappings(List<MappingsGETResponse> mappings) {
		this.mappings = mappings;
	}

}
