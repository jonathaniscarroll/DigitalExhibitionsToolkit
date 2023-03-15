using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLoadController : MonoBehaviour
{
	public List<GameObject> GameObjects;
	void Start(){
		foreach(GameObject go in GameObjects){
			DontDestroyOnLoad(go);
		}
	}
	
	public void DoDestroy(){
		foreach(GameObject go in GameObjects){
			Destroy(go);
		}
	}
	
}
