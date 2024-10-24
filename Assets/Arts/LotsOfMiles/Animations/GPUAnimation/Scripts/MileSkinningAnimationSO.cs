using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MileSkinningAnimation", menuName = "Mini/Animation/SkinningAnimation", order = 1)]
public class MileSkinningAnimationSO : ScriptableObject
{
    public string guid = null;

    public new string name = null;

    public MileSkinningBone[] bones = null;

    public int rootBoneIndex = 0;

    public MileSkinningClip[] clips = null;

    public Bounds bounds;

    public int textureWidth = 0;

    public int textureHeight = 0;

    public float sphereRadius = 1.0f;

    public GPUSkinningAnimation gpuSkinningAnimation;

}
