using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Canvas))]
public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    // this is the default ui for game running, should be loaded by default;
    [SerializeField] LoginUIData loginUI;
    static List<GameObject> spawnedUIs = new List<GameObject>();
    static Canvas canvas;
    void Start()
    {
        canvas = GetComponent<Canvas>();
        if (gameManager.gameStage == GameStage.login)
        {
            loginUI.SpawnUIs(canvas);
        }
    }


    void FixedUpdate()
    {
        switch (gameManager.gameStage)
        {
            case GameStage.login:
                //Debug.Log("login");
                break;
            case GameStage.gameLoop_normal:
                //Debug.Log("game loop");
                break;
            default:
                break;
        }
    }
}
