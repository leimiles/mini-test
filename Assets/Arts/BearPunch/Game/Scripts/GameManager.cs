using System;
using UnityEngine;
using WeChatWASM;

[DisallowMultipleComponent]
[RequireComponent(typeof(GameInputManager))]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameStatus gameStatus;
    bool IsGameValidated = false;
    void Start()
    {
        Validate();
        WX.ReportGameStart();
    }

    void Update()
    {
        if (!IsGameValidated)
        {
            return;
        }
    }

    void FixedUpdate()
    {
        if (!IsGameValidated)
        {
            return;
        }

    }

    void Validate()
    {
        IsGameValidated = true;
    }

}

[Serializable]
public class GameStatus
{
    [SerializeField]
    public GameStage gameStage = GameStage.login;
}

public enum GameStage
{
    login,
    gameLoop_normal,
}
