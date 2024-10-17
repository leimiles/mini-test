using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Canvas))]
public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameInputManager gameInputManager;
    // this is the default ui for game running, should be loaded by default;
    [SerializeField] LoginUIData loginUI;
    static Canvas canvas;
    void Start()
    {
        canvas = GetComponent<Canvas>();
        loginUI.SpawnUIs(canvas);
    }

}
