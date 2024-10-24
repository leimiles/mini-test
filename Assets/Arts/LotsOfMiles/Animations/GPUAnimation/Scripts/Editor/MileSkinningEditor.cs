using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MileSkinning))]
public class MileSkinningEditor : Editor
{
    MileSkinning mileSkinning;
    float time = 0;
    string[] clipsName = null;
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
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mileSkinningAnimationSO"));
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

        MileSkinningAnimationSO animationSO = serializedObject.FindProperty("mileSkinningAnimationSO").objectReferenceValue as MileSkinningAnimationSO;
        SerializedProperty defaultPlayingClipIndex = serializedObject.FindProperty("defaultPlayingClipIndex");
        if (clipsName == null && animationSO != null)
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < animationSO.clips.Length; i++)
            {
                strings.Add(animationSO.clips[i].name);
            }
            clipsName = strings.ToArray();
            defaultPlayingClipIndex.intValue = Mathf.Clamp(defaultPlayingClipIndex.intValue, 0, animationSO.clips.Length);
        }

        if (clipsName != null)
        {
            EditorGUI.BeginChangeCheck();
            defaultPlayingClipIndex.intValue = EditorGUILayout.Popup("Default Playing", defaultPlayingClipIndex.intValue, clipsName);
            if (EditorGUI.EndChangeCheck())
            {
                mileSkinning.MileSkinningPlayer.Play(clipsName[defaultPlayingClipIndex.intValue]);
            }
        }

        serializedObject.ApplyModifiedProperties();
    }

    void OnEnable()
    {
        Debug.Log("w");
    }
}
