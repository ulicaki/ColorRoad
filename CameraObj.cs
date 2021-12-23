using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CameraObj : MonoBehaviour
{
    [SerializeField] bool Point;
    [SerializeField] PathCreator PathCreat;
    float DisTraveld;
    [SerializeField] float Speed;
    // Start is called before the first frame update
    void Start()
    {
        StopMove();
        if (Point)
        {
            DisTraveld = GameObject.FindGameObjectWithTag("PlayerMain").GetComponent<Player>().DisTraveld;
            PathCreat = GameObject.FindGameObjectWithTag("Path").GetComponent<PathCreator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        DisTraveld += Speed * Time.deltaTime;
        transform.position = PathCreat.path.GetPointAtDistance(DisTraveld);
        transform.rotation = PathCreat.path.GetRotationAtDistance(DisTraveld);
    }

    public void StopMove()
    {
        Speed = 0;
    }
    public void StartMove()
    {
        Speed = 4;
    }
}
