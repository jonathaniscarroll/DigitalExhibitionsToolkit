using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ListOfNamedUIElements : ScriptableObject
{
	[System.Serializable]
	public class NamedUIElements{
		public string name;
		public UIElement uiElement;
	}
	public List<NamedUIElements> List;
}
