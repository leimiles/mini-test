using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GameInputManager : MonoBehaviour
{
    static UIData currentUIData;
    public void SetUIData(UIData uIData)
    {
        currentUIData = uIData;
    }
}
