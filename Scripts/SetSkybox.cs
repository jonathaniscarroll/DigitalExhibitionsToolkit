using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkybox : MonoBehaviour
{
	public Material skyboxMaterial;
	public void Set(){
		RenderSettings.skybox = skyboxMaterial;
	}
}
