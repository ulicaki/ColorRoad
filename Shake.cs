using System.Collections;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public bool start = false;
    public float time;
    public GameObject Post;

    public void ShakeCam()
    {
            StartCoroutine(Shaking());
        
    }

// On ball collect do some feedback
    IEnumerator Shaking()
    {
        Post.SetActive(true);
        yield return new WaitForSeconds(time);
        Post.SetActive(false);
    }
}
