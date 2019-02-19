using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    private void Start()
    {
    }
    
    private void Update()
    {
    }

    public void Play()
    {
        audioSource.Play();
    }
}
