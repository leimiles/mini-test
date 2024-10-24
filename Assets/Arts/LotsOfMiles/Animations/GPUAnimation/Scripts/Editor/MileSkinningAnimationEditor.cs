using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MileSkinningAnimationSO))]
public class MileSkinningAnimationEditor : Editor
{
    MileSkinningAnimationSO mileSkinningAnimationSO;
    public override void OnInspectorGUI()
    {
        if (mileSkinningAnimationSO == null)
        {
            mileSkinningAnimationSO = target as MileSkinningAnimationSO;
        }
        base.OnInspectorGUI();
    }


}
