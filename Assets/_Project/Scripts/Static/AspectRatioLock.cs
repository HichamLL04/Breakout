using UnityEngine;

public class AspectRatioLock : MonoBehaviour
{
    float targetAspect = 4f / 5f;

    void Update()
    {
        float currentAspect = (float)Screen.width / Screen.height;

        if (currentAspect > targetAspect)
        {
            int newHeight = (int)(Screen.width / targetAspect);
            Screen.SetResolution(Screen.width, newHeight, false);
        }
        else if (currentAspect < targetAspect)
        {
            int newWidth = (int)(Screen.height * targetAspect);
            Screen.SetResolution(newWidth, Screen.height, false);
        }
    }
}