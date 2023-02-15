using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip start, quit;

    public void Start()
    {
        src.clip = start;
        src.Play();


    }

   




}
