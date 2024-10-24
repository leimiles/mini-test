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
    float time = 0;
    float timeDiff = 0;
    MileSkinningClip currentClip;
    MileSkinningClip lastPlayedClip;
    MileSkinningClip lastPlayingClip;
    float lastPlayedTime = 0;
    int rootMotionFrameIndex = -1;
    public MileSkinningWrapMode WrapMode
    {
        get
        {
            return currentClip == null ? MileSkinningWrapMode.Once : currentClip.wrapMode;
        }
    }

    private bool isPlaying = false;
    public bool IsPlaying
    {
        get
        {
            return isPlaying;
        }
    }
    public bool IsTimeAtTheEndOfLoop
    {
        get
        {
            if (currentClip == null)
            {
                return false;
            }
            else
            {
                return GetFrameIndex() == ((int)(currentClip.length * currentClip.fps) - 1);
            }
        }
    }
    private int GetFrameIndex()
    {
        float time = GetCurrentTime();
        if (currentClip.length == time)
        {
            return GetTheLastFrameIndex_WrapMode_Once(currentClip);
        }
        else
        {
            return GetFrameIndex_WrapMode_Loop(currentClip, time);
        }
    }

    private int GetTheLastFrameIndex_WrapMode_Once(MileSkinningClip clip)
    {
        return (int)(clip.length * clip.fps) - 1;
    }

    private int GetFrameIndex_WrapMode_Loop(MileSkinningClip clip, float time)
    {
        return (int)(time * clip.fps) % (int)(clip.length * clip.fps);
    }


    private float GetCurrentTime()
    {
        float time = 0;
        if (WrapMode == MileSkinningWrapMode.Once)
        {
            time = this.time;
        }
        else if (WrapMode == MileSkinningWrapMode.Loop)
        {
            time = mileSkinningData.Time + (currentClip.individualDifferenceEnabled ? this.timeDiff : 0);
        }
        else
        {
            throw new System.NotImplementedException();
        }
        return time;
    }

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

    private void SetNewPlayingClip(MileSkinningClip clip)
    {
        lastPlayedClip = currentClip;
        lastPlayedTime = GetCurrentTime();

        isPlaying = true;
        currentClip = clip;
        rootMotionFrameIndex = -1;
        time = 0;
        timeDiff = Random.Range(0, currentClip.length);
    }

    public void Play(string clipName)
    {
        MileSkinningClip[] clips = mileSkinningData.animationSO.clips;
        int numClips = clips == null ? 0 : clips.Length;
        for (int i = 0; i < numClips; ++i)
        {
            if (clips[i].name == clipName)
            {
                if (currentClip != clips[i] || (currentClip != null && currentClip.wrapMode == MileSkinningWrapMode.Once && IsTimeAtTheEndOfLoop) || (currentClip != null && !isPlaying))
                {
                    SetNewPlayingClip(clips[i]);
                }
                return;
            }
        }
    }

}
