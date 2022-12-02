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
	public ListOfNamedUIElements UIElements;
	public GameObjectEvent SpawnedObject;
	
	public void Spawn(string inputName, string inputContent){
		UIElement ui = UIElements.List.Find((x)=>x.name==inputName).uiElement;
		Debug.Log(inputName);
		if(ui!=null){
			ui = Instantiate(ui,SpawnParent);
			ui.InputString(inputContent);
			SpawnedObject.Invoke(ui.gameObject);
		}
	}
	
}
