using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etc_Camera_Ratio : MonoBehaviour
{
    void Awake()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float Scale_Width;
        float Scale_Height;
        Scale_Height = ((float)Screen.width / Screen.height) / ((float)16 / 9);
        Scale_Width = 1.0f / Scale_Height;
        if (Scale_Height < 1)
        {
            rect.height = Scale_Height;
            rect.y = (1.0f - Scale_Height) / 2.0f;
        }
        else
        {
            rect.width = Scale_Width;
            rect.x = (1.0f - Scale_Width) / 2.0f;
        }
        camera.rect = rect;
    }
}
