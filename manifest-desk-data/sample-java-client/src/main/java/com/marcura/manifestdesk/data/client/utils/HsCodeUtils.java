package com.marcura.manifestdesk.data.client.utils;

import org.apache.commons.lang.StringUtils;

import com.marcura.manifestdesk.data.client.data.ManifestDeskData;
import com.marcura.manifestdesk.data.resource.hscodes.model.HscodesGETResponse;

public class HsCodeUtils {

	/**
	 * Find and return the given HsCode in the Manifest Desk Data
	 * 
	 * @param hsCode
	 * @param data
	 * @return
	 */
	public static HscodesGETResponse findHsCode(String hsCode, ManifestDeskData data) {
		for (HscodesGETResponse h : data.getHsCodes()) {
			if (StringUtils.equals(hsCode, h.getCode())) {
				return h;
			}
		}

		return null;
	}

}
