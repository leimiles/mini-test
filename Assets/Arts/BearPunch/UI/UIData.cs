using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIData : ScriptableObject
{
    protected List<GameObject> spawnedUIs;
    protected bool IsValidated { get; set; }
    protected abstract void Validate();
    protected abstract void OnEnable();
    public abstract void SpawnUIs(Canvas canvas);
    public void UnloadSpawnedUIs()
    {
        if (spawnedUIs != null)
        {
            for (int i = 0; i < spawnedUIs.Count; i++)
            {
                Destroy(spawnedUIs[i]);
            }
            spawnedUIs.Clear();
        }
    }

    public bool UISpawned()
    {
        if (spawnedUIs != null && spawnedUIs.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void AddButtonFunction(Button button, UnityEngine.Events.UnityAction callback)
    {
        button.onClick.AddListener(callback);
    }
}
