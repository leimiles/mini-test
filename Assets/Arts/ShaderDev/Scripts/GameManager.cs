using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject LoginUI;
    void Start()
    {
        Instantiate(LoginUI);
        WX.ReportGameStart();
    }

}
