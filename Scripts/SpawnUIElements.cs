using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUIElements : MonoBehaviour
{
	[System.Serializable]
	public class NamedUIElements{
		public string name;
		public UIElement uiElement;
	}
	[field:SerializeField]
	public Transform SpawnParent{get;set;}
	[field:SerializeField]
	public string UIParentName{get;set;}
	public ListOfNamedUIElements UIElements;
	public GameObjectEvent SpawnedObject;
	
	public void Spawn(string inputName, StringReference inputStringReference){
		UIElement ui = UIElements.List.Find((x)=>x.name==inputName).uiElement;
		Debug.Log(inputName);
		if(ui!=null){
			ui = Instantiate(ui,SpawnParent);
			if(inputName==UIParentName){
				SpawnParent = ui.transform;
			}
			ui.StringReference = inputStringReference;
			ui.InputString(inputStringReference.Value);
			SpawnedObject.Invoke(ui.gameObject);
		}
	}
	
}
