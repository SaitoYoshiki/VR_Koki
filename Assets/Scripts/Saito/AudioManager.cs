using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    private class FadeData
    {
        public AudioSource audioSource;
        public float fadeTime;
        public float startVolume;
        public float endVolume;

        public float time;
    }
    private List<FadeData> fadeDatas = new List<FadeData>();
    
    
    private void Update()
    {
        //音量の更新
        //
        foreach(var fade in fadeDatas)
        {
            if(fade.audioSource == null)
            {
                continue;
            }

            fade.time += Time.deltaTime;
            fade.audioSource.volume = Mathf.Lerp(fade.startVolume, fade.endVolume, Mathf.Clamp01(fade.time / fade.fadeTime));
        }


        //削除
        //
        fadeDatas.RemoveAll((x) => {
            //対象が存在しなかったら削除
            if(x.audioSource == null)
            {
                return true;
            }
            //時間が越えていたら削除
            if(x.time >= x.fadeTime)
            {
                return true;
            }
            return false;
        });

    }

    public void Fade(AudioSource audioSource, float startVolume, float endVolume, float fadeTime)
    {
        if (audioSource == null) return;
        var fadeData = new FadeData { audioSource = audioSource, fadeTime=fadeTime, startVolume=startVolume, endVolume=endVolume, time=0.0f};
        fadeDatas.Add(fadeData);
    }
    public void Fade(AudioSource audioSource, float endVolume, float fadeTime)
    {
        if (audioSource == null) return;
        var fadeData = new FadeData { audioSource = audioSource, fadeTime = fadeTime, startVolume = audioSource.volume, endVolume = endVolume, time = 0.0f };
        fadeDatas.Add(fadeData);
    }



    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogWarning("AudioManagerのインスタンスを取得します");
                instance = FindObjectOfType<AudioManager>();
            }
            return instance;
        }
    }
}
