using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotateToward : MonoBehaviour
{
	public Transform target{get;set;}
	public float speed;
	public RectTransform rectTransform;

    // Update is called once per frame
    void Update()
	{
		if(target==null){
			return;
		}
		Vector3 targ = target.position;
		targ.z = 0;
		Vector3 objectPos = rectTransform.anchoredPosition;
	    targ.x = targ.x - objectPos.x;
	    targ.y = targ.y - objectPos.y;
 
	    float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
	    rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
