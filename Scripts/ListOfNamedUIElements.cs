using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ListOfNamedUIElements : ScriptableObject
{
	[System.Serializable]
	public class NamedUIElement{
		public string name;
		public UIElement uiElement;
	}
	public List<NamedUIElement> List;
	public StringListEvent OutputNamesEvent;
	public void OutputListOfNames(){
		List<string> output = new List<string>();
		foreach(NamedUIElement uiElement in List){
			output.Add(uiElement.name);
		}
		OutputNamesEvent.Invoke(output);
	}
}
