using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutputNamedStringEvents : MonoBehaviour
{
	[System.Serializable]
	public class NamedEvent{
		public string name;
		public UnityEvent unityEvent;
	}
	public List<NamedEvent> NamedEvents;
	
	public void FindNamedEvent(string input){
		NamedEvent output= NamedEvents.Find(x=>x.name==input);
		output.unityEvent.Invoke();
	}
}
