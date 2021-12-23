using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniamtionEvents : MonoBehaviour
{
   public void AnimationEnd ()
    {
        gameObject.GetComponent<Animator>().enabled = false;
    }
}
