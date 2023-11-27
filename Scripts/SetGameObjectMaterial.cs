using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameObjectMaterial : MonoBehaviour
{
	public Material Material;
	
	public void InputGameObject(GameObject input){
		MeshRenderer renderer;
		if(renderer = input.GetComponent<MeshRenderer>()){
			if(renderer.material!=Material)
				renderer.material = Material;
		}
	}
}
