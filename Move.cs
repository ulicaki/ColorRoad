using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    float SwipSpeed,StartMouseTouch,EndMouseTouch;
    bool TouchOn,EndLevel;
    

    // Start is called before the first frame update
    void Start()
    {
        StopMove();

        StartCoroutine(TouchSwipSpeed());
    }

    public void StopMove ()
    {
        EndLevel = true;
    }

    public void StartMove ()
    {
        EndLevel = false;
    }

    private void Update()
    {
        if (!EndLevel)
        {
        // if user touch first cheack if
        // Player swipe right: cheack if player stay in borders from right
        // Player swipe left: cheack if player stay in borders from left
        // if yes add position by swipe speed
            if (TouchOn)
                if ((SwipSpeed > 0 && gameObject.transform.localPosition.x < 0.3f) || (SwipSpeed < 0 && gameObject.transform.localPosition.x > -0.3f))
                    gameObject.transform.localPosition += new Vector3(SwipSpeed / 200, 0, 0);

// if somthing happend and player run away from borders, reset his position to right one
            if (gameObject.transform.localPosition.x > 0.3f)
                gameObject.transform.localPosition = new Vector3(0.3f, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

            if (gameObject.transform.localPosition.x < -0.3f)
                gameObject.transform.localPosition = new Vector3(-0.3f, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            TouchOn = true;
        if (Input.GetMouseButtonUp(0))
            TouchOn = false;

    }

    IEnumerator TouchSwipSpeed ()
    {
    // do a loop
        int i = 1;
        while (i > 0)
        {
        // if user touches calc speed of swip in x axis
            while (TouchOn)
            {
                StartMouseTouch = Input.mousePosition.x;
                yield return new WaitForSeconds(0.01f);
                EndMouseTouch = Input.mousePosition.x;
                SwipSpeed = EndMouseTouch - StartMouseTouch;
            }
            i++;
            yield return null;
        }
    }

}
