using UnityEngine;
using WeChatWASM;

[DisallowMultipleComponent]
[RequireComponent(typeof(GameInputManager))]
public class GameManager : MonoBehaviour
{
    public GameStage gameStage = GameStage.login;
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

public enum GameStage
{
    login,
    gameLoop_normal,
}
