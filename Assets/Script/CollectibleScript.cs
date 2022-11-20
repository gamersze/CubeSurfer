using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleScript : MonoBehaviour
{
    public bool isCollected;
    float index;
    public CollecterScript collecterScript;
    public GameManager gameManager;
    public float value = 20f;
    public Rigidbody rb;
    public float stopSpeed = 0f;
    


    public void Start()
    {
        isCollected = false;

    }

    void Update()
    {
        if (isCollected == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index * 5, 0);

                if (GameManager.makeNext)
                {
                    transform.parent = null;
                    Destroy(gameObject);
                }
            }
            else
            {
                if (GameManager.makeNext)
                {
                    
                    Destroy(gameObject);
                }
            }
        }

    }

    public bool GetisCollected()
    {
        return isCollected;
    }
    public void MakeCollected()
    {
        isCollected = true;
    }
    public void setIndex(float index)
    {
        this.index = index;

    }


    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "obstacle")
        {

            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            collecterScript.DecreasedYukseklik();
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;

        }

        if (other.gameObject.tag == "scoring")
        {

            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            //this.transform.Translate(new Vector3(0, 0, stopSpeed * Time.deltaTime));
        }

        if (other.gameObject.tag == "finished")
        {
            collecterScript.player.GetComponent<BoxCollider>().enabled = false;
            gameManager.finishedGoblet.SetActive(true);
            gameManager.nextButton.SetActive(true);
           // gameManager.index += 1;

            //replayButton.SetActive(true); 
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Time.timeScale = 0f;

            

            

        }

    }


}
