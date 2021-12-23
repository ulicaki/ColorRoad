using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip InS;
    [SerializeField] AudioClip OutS;
    public void  End ()
    {
        gameObject.SetActive(false);
    }

    public void InAudio ()
    {
        AS.PlayOneShot(InS);
    }

    public void OutAudio()
    {
        AS.PlayOneShot(OutS);
    }
}
