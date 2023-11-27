using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseHoverRaycast : MonoBehaviour
{
	public Camera camera;
	RaycastHit hit;
	Ray ray;
	public StringEvent OnHover;
	public UnityEvent OffHover;
	public GameObjectEvent OnGameObjectHover;
	public GameObjectEvent OffGameObjectHover;
	[TagSelector]
	public string Tag;
	private bool isHovered;
	private GameObject objectHit;
	
	// Update is called once per frame
	void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit))
		{
			if(hit.transform.tag==Tag){
				objectHit = hit.transform.gameObject;
				// Do something with the object that was hit by the raycast.
				//Debug.Log("Mouse is over: " + objectHit.name);	
				OnHover.Invoke(Tag);
				isHovered = true;
				OnGameObjectHover.Invoke(objectHit);
			} else {
				OffHover.Invoke();
				OffGameObjectHover.Invoke(objectHit);
			}
			
		} else {
			isHovered = false;
			OffHover.Invoke();
			OffGameObjectHover.Invoke(objectHit);
		}
	}
}