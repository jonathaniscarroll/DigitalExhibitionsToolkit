using UnityEngine;

public class BasicMovement : MonoBehaviour
{
	[Tooltip("Target GameObject to be moved.")]
	public Transform target;

	[field:SerializeField]
	public Transform reference{get;set;}

	[Tooltip("Movement speed of the target GameObject.")]
	public float moveSpeed = 5f;

	private void Update()
	{
		if (target == null || reference == null)
		{
			Debug.LogWarning("Please assign target and reference GameObjects in the DirectedMovement script.");
			return;
		}

		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		Vector3 moveDirection = reference.TransformDirection(new Vector3(horizontalInput, 0, verticalInput));
		target.position += moveDirection * moveSpeed * Time.deltaTime;
	}
}