using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
public class DiscoLight : MonoBehaviour
{
    [SerializeField]
    Light directionalLight;
    [SerializeField]
    Camera mainCamera;

    Color oldColor = Color.black;
    Color randomColor;

    void Start()
    {
        if (directionalLight != null)
        {
            directionalLight.color = oldColor;
        }

        if (mainCamera != null)
        {
            mainCamera.backgroundColor = oldColor;
        }
        randomColor = UnityEngine.Random.ColorHSV();
    }
    void FixedUpdate()
    {
        if (directionalLight != null)
        {
            directionalLight.color = oldColor;
        }

        if (mainCamera != null)
        {
            mainCamera.backgroundColor = oldColor;
        }
        SetNewColor();
    }

    void SetNewColor()
    {
        if (oldColor != randomColor)
        {
            oldColor = Color.Lerp(oldColor, randomColor, math.abs(math.sin(Time.realtimeSinceStartup) * 0.25f));
        }
        else
        {
            randomColor = UnityEngine.Random.ColorHSV();
        }


    }
}
