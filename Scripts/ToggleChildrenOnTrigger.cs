using UnityEngine;

public class ToggleChildrenOnTrigger : MonoBehaviour
{
	public string playerTag = "Player";
	
	void Start(){
		SetChildrenActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(playerTag))
		{
			SetChildrenActive(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag(playerTag))
		{
			SetChildrenActive(false);
		}
	}

	private void SetChildrenActive(bool active)
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).gameObject.SetActive(active);
		}
	}
}