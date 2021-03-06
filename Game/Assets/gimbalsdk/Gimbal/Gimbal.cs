﻿using UnityEngine;
using System.Runtime.InteropServices;
using System.Globalization;
using System;

public class Gimbal {
	public static void SetApiKey(string apiKey) {
		setApiKey(apiKey);
	}

	public static void StartBeaconManager() {
		startBeaconManager();
	}

	public static void StopBeaconManager() {
		stopBeaconManager();
	}

	public static void StartPlaceManager() {
		startPlaceManager();
	}

	public static void StopPlaceManager() {
		stopPlaceManager();
	}

	public static bool IsMoitoring() {
		return isMonitoring();
	}

	public static DateTime ConvertJsonDate(string dateString) {
		if (dateString == null || dateString == "N/A") return new DateTime();

		return DateTime.ParseExact(dateString, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);;
	}

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	private static extern void setApiKey(string apiKey);

	[DllImport ("__Internal")]
	private static extern void startBeaconManager();

	[DllImport ("__Internal")]
	private static extern void stopBeaconManager();

	[DllImport ("__Internal")]
	private static extern void startPlaceManager();

	[DllImport ("__Internal")]
	private static extern void stopPlaceManager();
		
	[DllImport ("__Internal")]
	private static extern bool isMonitoring();
#elif UNITY_ANDROID
	[DllImport("gimbalunitybridge")]
	private static extern void setApiKey(string apiKey);
	
	[DllImport("gimbalunitybridge")]
	private static extern void startBeaconManager();
	
	[DllImport("gimbalunitybridge")]
	private static extern void stopBeaconManager();
	
	[DllImport("gimbalunitybridge")]
	private static extern void startPlaceManager();
	
	[DllImport("gimbalunitybridge")]
	private static extern void stopPlaceManager();

	[DllImport("gimbalunitybridge")]
	private static extern bool isMonitoring();
#endif
}
