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
	public Transform SpawnParent;
	public ListOfNamedUIElements UIElements;
	
	public void Spawn(string inputName, string inputContent){
		UIElement ui = UIElements.List.Find((x)=>x.name==inputName).uiElement;
		Debug.Log(inputName);
		if(ui!=null){
			ui = Instantiate(ui,SpawnParent);
			ui.InputString(inputContent);
		}
	}
	
}
