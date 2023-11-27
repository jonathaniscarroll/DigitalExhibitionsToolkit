using UnityEngine;

public class IsCameraLookingAtCollider : MonoBehaviour
{
	public Collider targetCollider;
	[field:SerializeField]
	public Camera mainCamera{get;set;}
	public BoolEvent OutputResult;

	void Start()
	{
		if (mainCamera == null)
		{
			mainCamera = Camera.main;
		}
	}

	void Update()
	{
		IsCameraLookingAt();


	}

	void IsCameraLookingAt()
	{
		bool output;
		// Compute the screen position of the collider's bounds center
		Vector3 screenPoint = mainCamera.WorldToViewportPoint(targetCollider.bounds.center);

		// Check if the screen point is within the viewport bounds
		if (screenPoint.x >= 0 && screenPoint.x <= 1 &&
			screenPoint.y >= 0 && screenPoint.y <= 1 &&
			screenPoint.z > 0)
		{
			// Perform a raycast from the camera to the collider's bounds center
			RaycastHit hit;
			Vector3 rayDirection = targetCollider.bounds.center - mainCamera.transform.position;
			if (Physics.Raycast(mainCamera.transform.position, rayDirection, out hit))
			{
				// Check if the raycast hit the target collider
				if (hit.collider == GetComponent<Collider>())
				{
					output =  true;
					OutputResult.Invoke(output);
				}
			}
		}

		output = false;
		OutputResult.Invoke(output);
		
	}
}