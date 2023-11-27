using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;


public class VRHeadsetDetection : MonoBehaviour
{
	
	public BoolEvent HeadsetPresenceState;
	
	void Update(){
		//isPresent();
		HeadsetPresenceState.Invoke(isPresent());
		//HeadsetPresenceState.Invoke(XRDevice.isPresent);
	}
	
	bool isPresent()
	{
		
		List<InputDevice> devices = new List<InputDevice>();
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeadMounted, devices);
		bool isPresent = devices.Count > 0;
		return isPresent;
	}
}
