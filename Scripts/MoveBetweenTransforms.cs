using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MoveBetweenTransforms : MonoBehaviour
{
	[System.Serializable]
	public class TransformPair{
		public Transform moveTarget;
		public Transform lookTarget;
	}
	public TransformPair[] targetPairs;
	public float moveSpeed = 1.0f;
	public float rotateSpeed = 5.0f;
	private int currentIndex = 0;
	public UnityEvent OnDestination;

	//void Start()
	//{
	//	StartCoroutine(MoveToNextTransform());
	//}
	
	public void MoveNext(){
		StartCoroutine(MoveToNextTransform());
	}

	IEnumerator MoveToNextTransform()
	{
		while (true)
		{
			TransformPair currentPair = targetPairs[currentIndex];
			Vector3 targetPosition = currentPair.moveTarget.position;
			

			while (transform.position != targetPosition)
			{
				Quaternion targetRotation = Quaternion.LookRotation(currentPair.lookTarget.position - transform.position);
				transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
				yield return null;
			}
			// Move to the next transform if needed
			currentIndex = (currentIndex + 1) % targetPairs.Length;
			
			OnDestination.Invoke();

			// Object has reached the target position, so break out of the loop
			yield break;

			
		}
	}
	
	void Update(){
		
	}

}
