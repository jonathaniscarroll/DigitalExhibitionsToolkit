using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class VRDetection : MonoBehaviour
{
	//public WebXR.WebXRManager WebXRManager;
	// Start is called before the first frame update
	public BoolEvent VRDetected;
    void Start()
	{
		bool isVR = false;
	    if (XRGeneralSettings.Instance.Manager.activeLoader != null) {
		    // XR device detected/loaded
		    isVR = true;
	    }
		VRDetected.Invoke(isVR);
		Debug.Log("VR: "+isVR);
    }

}
