using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectFollowTransform : MonoBehaviour
{
	public Camera TargetCamera;
	[field:SerializeField]
	public Transform TransformToFollow{
		get;set;
	}
	//public Vector3 TargetPosition{
	//	get;set;
	//}
	public Vector3Event OutputVector3;
	public RectTransform RectTransform;
	
	public void Follow(){
		if(TransformToFollow==null){
			return;
		}
		Vector3 targPos = TransformToFollow.position;
		if(TargetCamera==null){
			TargetCamera = Camera.main;
		}
		Vector3 pos = TargetCamera.WorldToScreenPoint (targPos);
		//pos.y = Screen.height-pos.y;
		RectTransform.anchoredPosition = new Vector2(pos.x,pos.y);
		OutputVector3.Invoke(pos);
		
	}
}
