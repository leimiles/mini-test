using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MileSkinningPlayer
{
    GameObject gameObject;
    Transform transform;
    MileSkinningData mileSkinningData;
    MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    MileSkinningCullingMode mileSkinningCullingMode = MileSkinningCullingMode.CullUpdateTransforms;
    public MileSkinningCullingMode MileSkinningCullingMode
    {
        get
        {
            return Application.isPlaying ? mileSkinningCullingMode : MileSkinningCullingMode.AlwaysAnimate;
        }
        set
        {
            mileSkinningCullingMode = value;
        }
    }
    public MileSkinningPlayer(GameObject gameObject, MileSkinningData data)
    {
        this.gameObject = gameObject;
        this.transform = this.gameObject.transform;
        mileSkinningData = data;
        meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        meshFilter = this.gameObject.GetComponent<MeshFilter>();

    }

}
