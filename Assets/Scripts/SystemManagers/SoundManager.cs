using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource buttonSounds;
    public AudioClip hover;
    public AudioClip click;

    public void Hover()
    {
        buttonSounds.PlayOneShot(hover);
    }

    public void Click()
    {
        buttonSounds.PlayOneShot(click);
    }
}
