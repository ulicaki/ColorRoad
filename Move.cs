using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    float ScreenSize, x3;
    float SwipSpeed,StartMouseTouch,EndMouseTouch;
    bool TouchOn,EndLevel;
    

    // Start is called before the first frame update
    void Start()
    {
        StopMove();
           x3 = Screen.width / 3;
             rb = GetComponent<Rigidbody>();
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
            if (TouchOn)
                if ((SwipSpeed > 0 && gameObject.transform.localPosition.x < 0.3f) || (SwipSpeed < 0 && gameObject.transform.localPosition.x > -0.3f))
                    gameObject.transform.localPosition += new Vector3(SwipSpeed / 200, 0, 0);


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
        int i = 1;
        while (i > 0)
        {
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
