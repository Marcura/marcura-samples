package com.marcura.manifestdesk.data.client.utils;

import org.apache.commons.lang.StringUtils;

import com.marcura.manifestdesk.data.client.data.ManifestDeskData;
import com.marcura.manifestdesk.data.resource.sanctions.model.Country;
import com.marcura.manifestdesk.data.resource.sanctions.model.SanctionsGETResponse;

public class SanctionUtils {

	public static SanctionsGETResponse findSanction(String sanction, ManifestDeskData data) {

		for (SanctionsGETResponse s : data.getSanctions()) {
			if (StringUtils.equals(sanction, s.getCode())) {
				return s;
			}
		}
		
		return null;
	}
	
	public static SanctionsGETResponse findSanctionForCountry(String sanction, String country, ManifestDeskData data) {

		SanctionsGETResponse s = findSanction(sanction, data);
		
		if (s != null){
			for (Country c : s.getCountries()){
				if (StringUtils.equals(country, c.getCode())){
					return s;
				}
			}
		}
		
		return null;
	}

}
