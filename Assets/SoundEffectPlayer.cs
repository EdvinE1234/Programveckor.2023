using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx;

    public void Start()
    {
        src.clip = sfx;
        src.Play();


    }

   




}
