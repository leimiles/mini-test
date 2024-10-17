using UnityEngine;
using UnityEngine.Rendering.Universal;

[DisallowMultipleComponent]
public class CameraDebug : MonoBehaviour
{
    Camera mainCamera;
    UniversalAdditionalCameraData universalAdditionalCameraData;
    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera != null)
        {
            universalAdditionalCameraData = mainCamera.GetUniversalAdditionalCameraData();
        }

    }
    public void DebugCameraShadow()
    {
        if (universalAdditionalCameraData != null)
        {
            if (universalAdditionalCameraData.renderShadows == true)
            {
                universalAdditionalCameraData.renderShadows = false;
            }
            else
            {
                universalAdditionalCameraData.renderShadows = true;
            }
        }
    }

}
