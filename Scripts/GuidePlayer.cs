using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class GuidePlayer : MonoBehaviour
{
	[System.Serializable]
	public struct AudioWaypoint
	{
		public Transform transform;
		public AudioClip audioClip;
	}

	public List<AudioWaypoint> waypoints;
	public float transitionTime = 3f;
	public float orbitRadius = 2f;

	private AudioSource audioSource;
	private Transform currentWaypoint;
	private int waypointIndex = 0;
	private int currentChild = 0;
	private float timer = 0f;

	private List<Transform> childTransforms;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
        
		//if(waypoints.Count > 0)
		//{
		//	SetNextWaypoint();
		//}
		StartCoroutine(DelayedStart());
	}
	
	IEnumerator DelayedStart(){
		yield return new WaitForSeconds(1);
		if(waypoints.Count > 0)
		{
			SetNextWaypoint();
		}
	}

	void Update()
	{
		if (currentWaypoint != null)
		{
			timer += Time.deltaTime;

			// Calculate time per child
			float timePerChild = waypoints[waypointIndex].audioClip.length / childTransforms.Count;

			// Orbit around current child
			Vector3 newPos = currentWaypoint.position;
			newPos.x += Mathf.Sin(timer / timePerChild * 2 * Mathf.PI) * orbitRadius;
			newPos.z += Mathf.Cos(timer / timePerChild * 2 * Mathf.PI) * orbitRadius;
			StartCoroutine(MoveToPosition(transform, newPos, transitionTime));

			// Check if it's time to move to the next child or waypoint
			if (timer > timePerChild)
			{
				timer = 0f;
				currentChild++;
				if (currentChild >= childTransforms.Count)
				{
					SetNextWaypoint();
				}
				else
				{
					currentWaypoint = childTransforms[currentChild];
				}
			}
		}
	}

	IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
	{
		
		Vector3 currentPos = transform.position;
		float t = 0f;
		while (t < 1)
		{
			t += Time.deltaTime / timeToMove;

			// Lerp position
			transform.position = Vector3.Lerp(currentPos, position, t);

			// Look at current waypoint
			Vector3 direction = currentWaypoint.position - transform.position;
			if(direction.magnitude > 0.01f) // Avoid LookRotation viewing vector is zero error
			{
				Quaternion toRotation = Quaternion.LookRotation(direction);
				transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime);
			}

			yield return null;
		}
	}

	public UnityEvent onLoop;
	void SetNextWaypoint()
	{
		// Populate childTransforms list
		childTransforms = new List<Transform>();
		foreach (Transform child in waypoints[waypointIndex].transform)
		{
			childTransforms.Add(child);
		}

		currentChild = 0;
		currentWaypoint = childTransforms[currentChild];
		audioSource.clip = waypoints[waypointIndex].audioClip;
		audioSource.Play();

		waypointIndex = (waypointIndex + 1) % waypoints.Count;
		if (waypointIndex == 0)
		{
			onLoop.Invoke();
		}
	}
}
