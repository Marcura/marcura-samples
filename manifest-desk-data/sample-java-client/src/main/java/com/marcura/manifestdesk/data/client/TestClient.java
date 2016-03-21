package com.marcura.manifestdesk.data.client;

import java.util.ArrayList;
import java.util.List;

import com.marcura.manifestdesk.data.client.data.ManifestDeskData;
import com.marcura.manifestdesk.data.client.utils.HsCodeUtils;
import com.marcura.manifestdesk.data.client.utils.MappingUtils;
import com.marcura.manifestdesk.data.client.utils.SanctionUtils;
import com.marcura.manifestdesk.data.resource.hscodes.model.HscodesGETResponse;
import com.marcura.manifestdesk.data.resource.mappings.model.Sanction;
import com.marcura.manifestdesk.data.resource.sanctions.model.SanctionsGETResponse;

public class TestClient {

	public static void main(String[] args) {

		String HSCODE = "020725";
		String COUNTRY = "RU";
		String URL = "http://mocksvc.mulesoft.com/mocks/d8faf736-3ec9-43d3-95dc-15d704796463";

		//download the data from the API
		ManifestDeskData data = new ManifestDeskData("testUser", "testPassword", URL);
		data.download("UN");

		/**
		 * At this point, you can simply insert this data into your own database.
		 * For this example, we will keep everything in array lists.
		 * This is of course not efficient because we have to loop every time we need to find something, 
		 * but works well for an example.
		 * 
		 * If you download this data and store it in database, then you only need to perform
		 * that action once a day and not every time a check needs to be made.
		 */
		
		// lets find information for HS Code 020725
		HscodesGETResponse hsCode = HsCodeUtils.findHsCode(HSCODE, data);
		System.out.println("Description for HS Code " + HSCODE + ": " + hsCode.getDescription());

		// lets check the mappings for any sanctions for this HS Code
		List<Sanction> sanctionsForHsCode = MappingUtils.findSanctionsForHsCode(HSCODE, data);
		System.out.println("Sanction found: " + sanctionsForHsCode);

		// lets get the information on the sanctions and check if they match the country Russia
		List<SanctionsGETResponse> sanctionsMatch = new ArrayList<SanctionsGETResponse>();
		if (sanctionsForHsCode != null) {
			for (Sanction sanctionForHsCode : sanctionsForHsCode) {
				SanctionsGETResponse sanction = SanctionUtils.findSanctionForCountry(sanctionForHsCode.getCode(), COUNTRY, data);
				sanctionsMatch.add(sanction);
				System.out.println("Sanction description: \n\tcode: "
						+ sanction.getCode() + " \n\tname: "
						+ sanction.getName() + " \n\ttype: "
						+ sanction.getTypes() + " \n\tcountries:"
						+ sanction.getCountries());
			}
		}

		//If there is a match, print the following notice
		if (sanctionsMatch.size() > 0) {
			System.out.println("HSCODE-Country match found!!");
		}
	}
}
