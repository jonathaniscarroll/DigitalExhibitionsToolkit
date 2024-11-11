using UnityEngine;

public class ToggleCursorVisibility : MonoBehaviour
{
	public KeyCode toggleKey = KeyCode.Escape;

	private bool cursorVisible = true;

	void Start()
	{
		SetCursorVisibility(cursorVisible);
	}

	void Update()
	{
		if (Input.GetKeyDown(toggleKey))
		{
			cursorVisible = !cursorVisible;
			SetCursorVisibility(cursorVisible);
		}
	}

	public void SetCursorVisibility(bool visible)
	{
		Cursor.visible = visible;
		Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
	}
}
