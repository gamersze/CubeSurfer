using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Vector3 firstPos, endPos;
    public float playerSpeed;
    Rigidbody rb;
    public float forwardSpeed;
    public bool gameStart;
    public GameManager gameManager;
    public float sensitivy;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void LateUpdate()
    {
        //gameManager.nextButton.SetActive(false);
        //print("c");

        if (gameManager.isStart)
        {
           this.transform.Translate(new Vector3(0, 0, forwardSpeed * Time.deltaTime));
           
            gameManager.fingerPoint.SetActive(false);
            gameManager.blockArrow.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
            gameManager.isStart = true;
        }
        else if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            float distanceX = endPos.x - firstPos.x;
            float XposChange = Mathf.Clamp(distanceX, -7, 7);
            //  transform.Translate(distanceX * Time.deltaTime * playerSpeed / 150, 0, 0);
            transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(transform.position.x + (Input.GetAxis("Mouse X") * sensitivy * Time.deltaTime),
                   -0.74f, 0.749f), transform.position.y, transform.position.z),.4f);

        }



        

        //if (transform.position.x > 8)
        //{
        //    transform.position = new Vector3(7, transform.position.y, transform.position.z);
        //}
        //if (transform.position.x < -8)
        //{
        //    transform.position = new Vector3(-7, transform.position.y, transform.position.z);
        //}
        //float XposChange = distanceX * Time.deltaTime * playerSpeed / 150;
        //transform.position = Vector3.Lerp(transform.position, new Vector3(XposChange, transform.position.y, transform.position.z), 0.5f);


        //float endPosX = Mathf.Clamp(XposChange, -1f, 1f);

        //if (endPos.x<-50|| endPos.x>50)
        //{
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(endPosX, transform.position.y, transform.position.z), 0.5f);
        //}

        //endPosX = 0;
        if (Input.GetMouseButtonUp(0))
        {
            //firstPos = Vector3.zero;
            //endPos = Vector3.zero;
        }


    }

   
    
}


