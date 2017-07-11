using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float aspectX = 9.0f;
    [SerializeField]
    private float aspectY = 16.0f;

    void Awake()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = CalcAspectRatio(aspectX, aspectY);
        camera.rect = rect;
    }

    private Rect CalcAspectRatio(float width, float height)
    {
        float targetAspect = width / height;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float heightScale = windowAspect / targetAspect;
        var rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);

        if (1.0f > heightScale)
        {
            rect.x = 0;
            rect.y = (1.0f - heightScale) / 2.0f;
            rect.width = 1.0f;
            rect.height = heightScale;
        }
        else
        {
            float scale_width = 1.0f / heightScale;
            rect.x = (1.0f - scale_width) / 2.0f;
            rect.y = 0.0f;
            rect.width = scale_width;
            rect.height = 1.0f;
        }
        return rect;
    }
}