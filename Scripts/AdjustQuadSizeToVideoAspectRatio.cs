using UnityEngine;
using UnityEngine.Video;

public class AdjustQuadSizeToVideoAspectRatio : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public MeshRenderer quadRenderer;

    void Start()
    {
        if (videoPlayer != null && quadRenderer != null)
        {
            videoPlayer.prepareCompleted += OnVideoPrepared;
            videoPlayer.Prepare();
        }
        else
        {
            Debug.LogError("VideoPlayer and/or Quad MeshRenderer is not assigned in the Inspector.");
        }
    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        float videoAspectRatio = (float)source.width / (float)source.height;
        AdjustQuadSize(videoAspectRatio);
    }

    private void AdjustQuadSize(float aspectRatio)
    {
        Vector3 quadSize = quadRenderer.transform.localScale;
        quadSize.x = quadSize.y * aspectRatio;
        quadRenderer.transform.localScale = quadSize;
    }

    private void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.prepareCompleted -= OnVideoPrepared;
        }
    }
}