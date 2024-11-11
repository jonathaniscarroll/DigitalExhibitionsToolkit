using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPositions : MonoBehaviour
{
	[field:SerializeField]
	public Vector3 Position1{get;set;}
	[field:SerializeField]
	public Vector3 Position2{get;set;}
	[field:SerializeField]
	public Transform Target{get;set;}
	
	public void MoveToPosition(int position){
		if(position==1){
			Target.position = Position2;
		} else {
			Target.position = Position1;
		}
	}

}
