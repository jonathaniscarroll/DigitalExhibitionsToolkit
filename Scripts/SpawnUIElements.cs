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
	public List<NamedUIElements> UIElements;
	
	public void Spawn(string inputName, string inputContent){
		UIElement ui = UIElements.Find((x)=>x.name==inputName).uiElement;
		if(ui!=null){
			ui = Instantiate(ui,SpawnParent);
			ui.InputString(inputContent);
		}
	}
	
}
