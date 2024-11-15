using UnityEngine;

public class QuadAspectRatio : MonoBehaviour
{
	public Renderer renderer;

	public void AdjustQuadAspectRatio(Texture2D tex)
	{
		float width = tex.width;
		float height = tex.height;
		float aspectRatio = width / height;

		// Adjust the scale of the quad to match the aspect ratio of the texture
		transform.localScale = new Vector3(aspectRatio, 1.0f, 1.0f);

		if (renderer != null)
		{
			renderer.material.mainTexture = tex;
		}

		Debug.Log("Quad aspect ratio adjusted to match the texture.");
	}
}
