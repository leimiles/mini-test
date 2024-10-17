using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LoginUIData", menuName = "Mini/UI/LoginUIData", order = 1)]
public class LoginUIData : UIData, ISerializationCallbackReceiver
{
    [SerializeField] GameObject backgroundImage_Pannel;
    [SerializeField] GameObject playerName_InputField;
    [SerializeField] GameObject start_Button;
    [SerializeField] GameObject option_Button;

    public void OnAfterDeserialize()
    {
    }

    public void OnBeforeSerialize()
    {
    }

    protected override void OnEnable()
    {
        Validate();
    }

    protected override void Validate()
    {
        if (backgroundImage_Pannel == null)
        {
            IsValidated = false;
            Debug.LogError("loginUI needs backgroundImage_Pannel");
            return;
        }
        if (playerName_InputField == null)
        {
            IsValidated = false;
            Debug.LogError("loginUI needs playerName_InputField");
            return;
        }
        if (start_Button == null)
        {
            IsValidated = false;
            Debug.LogError("loginUI needs start_Button");
            return;
        }
        if (option_Button == null)
        {
            IsValidated = false;
            Debug.LogError("loginUI needs option_Button");
            return;
        }
        if (spawnedUIs == null)
        {
            spawnedUIs = new List<GameObject>();
        }
        else
        {
            spawnedUIs.Clear();
        }
        IsValidated = true;
    }

    public override void SpawnUIs(Canvas canvas)
    {
        if (IsValidated && !UISpawned())
        {
            spawnedUIs.Add(Instantiate(backgroundImage_Pannel, canvas.transform));
            spawnedUIs.Add(Instantiate(playerName_InputField, canvas.transform));
            GameObject btn1 = Instantiate(start_Button, canvas.transform);
            AddButtonFunction(btn1.GetComponent<Button>(), Temp);
            spawnedUIs.Add(btn1);
            spawnedUIs.Add(Instantiate(option_Button, canvas.transform));
        }
    }

    void Temp()
    {
        Debug.Log("wawa");
    }
}