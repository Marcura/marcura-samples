package com.marcura.manifestdesk.data.client.utils;

import java.util.List;

import org.apache.commons.lang.StringUtils;

import com.marcura.manifestdesk.data.client.data.ManifestDeskData;
import com.marcura.manifestdesk.data.resource.mappings.model.MappingsGETResponse;
import com.marcura.manifestdesk.data.resource.mappings.model.Sanction;

public class MappingUtils {
	
	public static List<Sanction> findSanctionsForHsCode(String hsCode, ManifestDeskData data){
		for (MappingsGETResponse mapping : data.getMappings()) {
			if (StringUtils.equals(hsCode, mapping.getHscode())) {
				return mapping.getSanctions();
			}
		}
		
		return null;
	}

}
