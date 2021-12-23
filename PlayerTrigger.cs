using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;

public class PlayerTrigger : MonoBehaviour
{
    int mode = 1;               // 1 - green 2 - yellow 3 - red
    [Header("General")]
    bool IsCombo;
    float ComboTimer,PithValue;
    [SerializeField] Animator PointsTextAnimator;
    [SerializeField] Text PointsText;
    [SerializeField] GameObject DeadPost;
    [SerializeField] GameObject DeadUI;
    [SerializeField] GameObject CameraObj;
    [SerializeField] GameObject WinUI;
    [SerializeField] Text WinText;
    int points = 0,AddedPoints;

    [Header("Colors")]
    [SerializeField] Material Red;
    [SerializeField] Material Yellow;
    [SerializeField] Material Green;
    [SerializeField] Material SceneGreen;
    [SerializeField] Material SceneYellow;
    [SerializeField] Material SceneRed;
    [SerializeField] Material SkyGreen;
    [SerializeField] Material SkyYellow;
    [SerializeField] Material SkyRed;
    [SerializeField] Color FogGreen;
    [SerializeField] Color FogYellow;
    [SerializeField] Color FogRed;

    [Header("Effects")]
    [SerializeField] GameObject RedSelectEffect;
    [SerializeField] GameObject GreenSelectEffect;
    [SerializeField] GameObject YellowSelectEffect;

    [Header("Audio")]
    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip SelectAudio;
    [SerializeField] AudioClip LoseAudio;

    private void Start()
    {
        CheackColor();
    }

    private void Update()
    {
         if(ComboTimer > 0)
        {
            IsCombo = true;
            ComboTimer -= Time.deltaTime;
        }
         else
        {
            IsCombo = false;
            AddedPoints = 0;
            PithValue = 1;
            AS.pitch = PithValue;
        }
        


    }

    void CheackCombo ()
    {
        if (IsCombo)
        {
            PithValue += 0.15f;
            
            AS.pitch = PithValue;
        }
    }
       
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "SmallJumper")
        {

            GameObject.FindGameObjectWithTag("PlayerMain").GetComponent<Player>().SmallJump();
            mode = other.gameObject.GetComponent<SmallJump>().mode;
            CheackColor();
        }

        if (other.gameObject.tag == "WinTrigger")
        {
            GameObject.FindGameObjectWithTag("PlayerMain").GetComponent<Player>().StopMove();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Move>().StopMove();
            GameObject.FindGameObjectWithTag("Camera").GetComponent<CameraObj>().StopMove();
            DeadPost.SetActive(true);
            WinUI.SetActive(true);
            WinText.text = "" + points;
            AS.pitch = 1;
            AS.PlayOneShot(LoseAudio);

        }

        if (other.gameObject.tag == "PointRed")
        {
            if (mode != 3)
            {
                GameObject.FindGameObjectWithTag("PlayerMain").GetComponent<Player>().StopMove();
                CameraObj.GetComponent<CameraObj>().StopMove();
                gameObject.GetComponent<Move>().StopMove();
                AS.pitch = 1;
                AS.PlayOneShot(LoseAudio);
                DeadPost.SetActive(true);
                DeadUI.SetActive(true);


            }
            else
            {
                Debug.Log("red");
                points++;
                AddedPoints++;
                CameraObj.GetComponent<Shake>().ShakeCam();
                PointsText.text = "" + points;
                PointsTextAnimator.Play("PointsText");               
                ComboTimer = 2;              
                AS.PlayOneShot(SelectAudio);
                Instantiate(RedSelectEffect, other.transform.position, Quaternion.identity);
                CheackCombo();
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.tag == "PointYellow")
        {
            if (mode != 2)
            {
                GameObject.FindGameObjectWithTag("PlayerMain").GetComponent<Player>().StopMove();
                CameraObj.GetComponent<CameraObj>().StopMove();
                gameObject.GetComponent<Move>().StopMove();
                AS.pitch = 1;
                AS.PlayOneShot(LoseAudio);
                DeadPost.SetActive(true);
                DeadUI.SetActive(true);
            }
            else
            {
                points++;
                PointsText.text = "" + points;
                PointsTextAnimator.Play("PointsText");
                CameraObj.GetComponent<Shake>().ShakeCam();
                ComboTimer = 2;
                AS.PlayOneShot(SelectAudio);
                Instantiate(YellowSelectEffect, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.tag == "PointGreen")
        {
            if (mode != 1)
            {
                GameObject.FindGameObjectWithTag("PlayerMain").GetComponent<Player>().StopMove();
                CameraObj.GetComponent<CameraObj>().StopMove();
                gameObject.GetComponent<Move>().StopMove();
                AS.pitch = 1;
                AS.PlayOneShot(LoseAudio);
                DeadPost.SetActive(true);
                DeadUI.SetActive(true);
            }
            else
            {
                points++;
                PointsText.text = "" + points;
                PointsTextAnimator.Play("PointsText");
                CameraObj.GetComponent<Shake>().ShakeCam();
                ComboTimer = 2;
                AS.PlayOneShot(SelectAudio);
                Instantiate(GreenSelectEffect, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }
    }
        void CheackColor()
        {
            switch (mode)
            {
                case 1:
                    gameObject.GetComponent<Renderer>().material = Green;
                    GameObject[] ObjectsScene = GameObject.FindGameObjectsWithTag("ObjectsScene");
                    foreach (GameObject obj in ObjectsScene)
                        obj.GetComponent<Renderer>().material = SceneGreen;
                    RenderSettings.skybox = SkyGreen;
                    break;
                case 2:
                    gameObject.GetComponent<Renderer>().material = Yellow;
                    GameObject[] ObjectsScene2 = GameObject.FindGameObjectsWithTag("ObjectsScene");
                    foreach (GameObject obj in ObjectsScene2)
                        obj.GetComponent<Renderer>().material = SceneYellow;
                    RenderSettings.skybox = SkyYellow;
                    break;
                case 3:
                    gameObject.GetComponent<Renderer>().material = Red;
                    GameObject[] ObjectsScene3 = GameObject.FindGameObjectsWithTag("ObjectsScene");
                    foreach (GameObject obj in ObjectsScene3)
                        obj.GetComponent<Renderer>().material = SceneRed;
                    RenderSettings.skybox = SkyRed;
                    break;
            }
        }
    }

