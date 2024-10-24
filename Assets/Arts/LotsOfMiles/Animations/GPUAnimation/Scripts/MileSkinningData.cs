using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MileSkinningData
{

    public MileSkinningAnimationSO animationSO;
    //public GPUSkinningAnimation animationSO;
    public Mesh mesh;
    public Texture2D texture2D;
    public List<MileSkinning> mileSkinnings = new List<MileSkinning>();
    CullingGroup cullingGroup = null;
    MileSkinningList<BoundingSphere> cullingBounds = new MileSkinningList<BoundingSphere>(100);
    MileSkinningMaterial[] mileSkinningMaterials;
    private float time = 0;
    public float Time
    {
        get
        {
            return time;
        }
        set
        {
            time = value;
        }
    }
    static int shaderPropID_GPUSkinning_TextureMatrix = -1;
    static int shaderPropID_GPUSkinning_TextureSize_NumPixelsPerFrame = 0;
    public MileSkinningData()
    {
        if (shaderPropID_GPUSkinning_TextureMatrix == -1)
        {
            shaderPropID_GPUSkinning_TextureMatrix = Shader.PropertyToID("_GPUSkinning_TextureMatrix");
            shaderPropID_GPUSkinning_TextureSize_NumPixelsPerFrame = Shader.PropertyToID("_GPUSkinning_TextureSize_NumPixelsPerFrame");
        }
    }

    public void InitMaterial(Material material, HideFlags hideFlags)
    {
        if (mileSkinningMaterials != null)
        {
            return;
        }

        mileSkinningMaterials = new MileSkinningMaterial[1];
        mileSkinningMaterials[0] = new MileSkinningMaterial() { Material = new Material(material) };
        mileSkinningMaterials[0].Material.name = "wawa";
        mileSkinningMaterials[0].Material.hideFlags = hideFlags;
        mileSkinningMaterials[0].Material.enableInstancing = true;
    }

    public void AddCullingBounds()
    {
        if (cullingGroup == null)
        {
            cullingGroup = new CullingGroup();
            cullingGroup.targetCamera = Camera.main;
            //cullingGroup.SetBoundingDistances(animationSO.lodDistances)
            cullingGroup.SetDistanceReferencePoint(Camera.main.transform);
        }

        cullingBounds.Add(new BoundingSphere());
        cullingGroup.SetBoundingSpheres(cullingBounds.buffer);
        cullingGroup.SetBoundingSphereCount(mileSkinnings.Count);
    }

}

public class MileSkinningMaterial
{
    Material material = null;
    public Material Material
    {
        get;
        set;
    }

    public MilesSkinningExecuteOncePerFrame executeOncePerFrame = new MilesSkinningExecuteOncePerFrame();
    public void Destroy()
    {
        if (material != null)
        {
            Object.Destroy(material);
            material = null;
        }
    }
}

public class MilesSkinningExecuteOncePerFrame
{
    private int frameCount = -1;

    public bool CanBeExecute()
    {
        if (Application.isPlaying)
        {
            return frameCount != Time.frameCount;
        }
        else
        {
            return true;
        }
    }

    public void MarkAsExecuted()
    {
        if (Application.isPlaying)
        {
            frameCount = Time.frameCount;
        }
    }
}

public enum MileSkinningCullingMode
{
    AlwaysAnimate,
    CullUpdateTransforms,
    CullCompletely
}