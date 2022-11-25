using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamedToggleEvents : MonoBehaviour
{
	[System.Serializable]
	public class NamedToggle{
		public string name;
		private bool _state;
		public bool state{
			get{return _state;}set{_state = value;boolEvent.Invoke(_state);}
		}
		public BoolEvent boolEvent;
	}
	public List<NamedToggle> NamedToggles;
	
	public void InputName(string input){
		Debug.Log(input);
		NamedToggle output = NamedToggles.Find(x=>x.name==input);
		if(output!=null){
			output.boolEvent.Invoke(true);
		}
		//Debug.Log(output.name);
		//foreach(NamedToggle nt in NamedToggles){
		//	Debug.Log("-"+nt.name+"-"+input+"-");
		//	if(nt.name!=input){
		//		//nt.state = false;
		//	} else {
		//		nt.state = true;
		//	}
		//}
		//output.state = true;
	}
}
