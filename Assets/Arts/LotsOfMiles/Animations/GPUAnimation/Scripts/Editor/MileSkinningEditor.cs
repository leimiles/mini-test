using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MileSkinning))]
public class MileSkinningEditor : Editor
{
    MileSkinning mileSkinning;
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        if (mileSkinning == null)
        {
            mileSkinning = target as MileSkinning;
        }
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("material"));
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
            mileSkinning.DeletePlayer();
            mileSkinning.Init();
        }

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mesh"));
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
            mileSkinning.DeletePlayer();
            mileSkinning.Init();
        }

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("textAsset"));
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
            mileSkinning.DeletePlayer();
            mileSkinning.Init();
        }

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("gpuSkinningAnimationSO"));
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
            mileSkinning.DeletePlayer();
            mileSkinning.Init();
        }

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mileSkinningCullingMode"));
        if (EditorGUI.EndChangeCheck())
        {
            if (Application.isPlaying)
            {
                mileSkinning.MileSkinningPlayer.MileSkinningCullingMode =
                    serializedObject.FindProperty("mileSkinningCullingMode").enumValueIndex == 0 ? MileSkinningCullingMode.AlwaysAnimate :
                    serializedObject.FindProperty("mileSkinningCullingMode").enumValueIndex == 1 ? MileSkinningCullingMode.CullUpdateTransforms : MileSkinningCullingMode.CullCompletely;
            }
        }

        serializedObject.ApplyModifiedProperties();
    }

    void OnEnable()
    {
        Debug.Log("w");
    }
}
