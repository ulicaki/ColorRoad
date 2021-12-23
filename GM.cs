using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [SerializeField] GameObject StartButton;
    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip StartS;
    
    // on scene start stop player and camera movement
    public void StartGame()
    {
        GameObject.FindGameObjectWithTag("PlayerMain").GetComponent<Player>().StartMove();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Move>().StartMove();
        GameObject.FindGameObjectWithTag("Camera").GetComponent<CameraObj>().StartMove();
        StartButton.GetComponent<Animator>().Play("StartOut");
        AS.PlayOneShot(StartS);
    }

    public void Restart ()
    {
        Application.LoadLevel(0);
    }
}
