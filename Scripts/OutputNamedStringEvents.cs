using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutputNamedStringEvents : MonoBehaviour
{
	[System.Serializable]
	public class NamedEvent{
		public string name;
		public StringEvent stringEvent;
	}
	public List<NamedEvent> NamedEvents;
	
	public void FindNamedEvent(string input,string argument){
		NamedEvent output= NamedEvents.Find(x=>x.name==input);
		if(output!=null)
		output.stringEvent.Invoke(argument);
	}
}
