using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorEvent : MonoBehaviour
{
	public UnityEvent EventToDo;
	public void OutputEvent(){
		EventToDo.Invoke();
	}
}
