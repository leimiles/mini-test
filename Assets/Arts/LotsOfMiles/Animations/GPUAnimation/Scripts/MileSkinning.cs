using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[DisallowMultipleComponent]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class MileSkinning : MonoBehaviour
{
    [HideInInspector][SerializeField] MileSkinningAnimationSO mileSkinningAnimationSO;
    //[SerializeField] GPUSkinningAnimation gpuSkinningAnimationSO;
    [SerializeField] Material material;
    [SerializeField] Mesh mesh;
    [SerializeField] TextAsset textAsset;
    [SerializeField] int defaultPlayingClipIndex = 0;
    [SerializeField] MileSkinningCullingMode mileSkinningCullingMode = MileSkinningCullingMode.CullUpdateTransforms;
    static MileSkinningManager mileSkinningManager = new MileSkinningManager();
    MileSkinningPlayer mileSkinningPlayer;
    public MileSkinningPlayer MileSkinningPlayer
    {
        get
        {
            return mileSkinningPlayer;
        }
    }

#if UNITY_EDITOR
    public void DeletePlayer()
    {
        mileSkinningPlayer = null;
    }
#endif

    public void Init()
    {
        if (mileSkinningPlayer != null)
        {
            return;
        }
        if (mileSkinningAnimationSO != null && material != null && mesh != null && textAsset != null)
        {
            MileSkinningData mileSkinningData = null;
            if (Application.isPlaying)
            {
                mileSkinningManager.Register(mileSkinningAnimationSO, mesh, material, textAsset, this, out mileSkinningData);
            }
            else
            {

            }

            mileSkinningPlayer.MileSkinningCullingMode = mileSkinningCullingMode;
        }
    }

}

public class MileSkinningManager
{
    private List<MileSkinningData> items = new List<MileSkinningData>();
    public void Register(MileSkinningAnimationSO animationSO, Mesh mesh, Material material, TextAsset textAsset, MileSkinning mileSkinning, out MileSkinningData mileSkinningData)
    {
        mileSkinningData = null;
        if (animationSO == null || mesh == null || material == null || textAsset == null)
        {
            return;
        }
        MileSkinningData data = null;
        int num = items.Count;
        for (int i = 0; i < num; ++i)
        {
            if (items[i].animationSO.guid == animationSO.guid)
            {
                data = items[i];
                break;
            }
        }

        if (data == null)
        {
            data = new MileSkinningData();
            items.Add(data);
        }

        if (data.animationSO == null)
        {
            data.animationSO = animationSO;
        }

        if (data.mesh == null)
        {
            data.mesh = mesh;
        }

        data.InitMaterial(material, HideFlags.None);

        if (data.texture2D == null)
        {
            data.texture2D = MileSkinningUtils.CreateTexture2D(textAsset, animationSO);
        }

        if (!data.mileSkinnings.Contains(mileSkinning))
        {
            data.mileSkinnings.Add(mileSkinning);
            data.AddCullingBounds();
        }

        mileSkinningData = data;

    }
}
