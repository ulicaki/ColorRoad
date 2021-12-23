using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Player : MonoBehaviour
{
    [Header("General")]

    [SerializeField] Animator PlayerAnimator;
    [SerializeField] GameObject PlayerBall;
    [SerializeField] PathCreator PathCreat;
    [SerializeField] float Speed;
    [SerializeField] float MSpeed;
   
    [HideInInspector]public float DisTraveld;

    


    [Header("Audio")]
    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip JumpSound;
    // Start is called before the first frame update

// on level start dont move until level starts
    private void Start()
    {
        StopMove();
    }
    
    // play jump animation when player hit SmallJumper
    public void SmallJump ()
    {
        AS.PlayOneShot(JumpSound);
        
        PlayerAnimator.Play("SmallJump");
    }

    // move and rotate player along path
    void Update()
    {
        DisTraveld += Speed * Time.deltaTime;
        transform.position = PathCreat.path.GetPointAtDistance(DisTraveld);
      transform.rotation = PathCreat.path.GetRotationAtDistance(DisTraveld);
    }


    public void StopMove ()
    {
        Speed = 0;
    }

    public void StartMove()
    {
        Speed = 4;
    }







}
