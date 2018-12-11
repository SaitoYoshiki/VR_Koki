using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Test_AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource punchSE;

    [SerializeField]
    AudioSource kickSE;

    [SerializeField]
    AudioSource bgm;


    private void Start()
    {

    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            punchSE.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            kickSE.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bgm.Play();
            AudioManager.Instance.Fade(bgm, 0.0f, bgm.volume, 2.0f);
        }
    }
}
