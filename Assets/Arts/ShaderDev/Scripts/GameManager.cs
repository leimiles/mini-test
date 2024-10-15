using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WX.ReportGameStart();
    }

}
