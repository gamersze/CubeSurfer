using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollecterScript : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float yukseklik;
    private CollectibleScript collectibleScript;
    public Rigidbody rb;
    public float score;
    public TextMeshProUGUI scoretext;
    public GameManager gameManager;
    public Vector3 playerStartPosition;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerStartPosition = transform.position;
    }


    void Update()
    {
        player.transform.position = new Vector3(transform.position.x, yukseklik, transform.position.z);
        this.transform.localPosition = new Vector3(0, -5 * yukseklik, 0);

        if (GameManager.makeNext)
        {
            player.transform.position = playerStartPosition;
            GetComponent<BoxCollider>().enabled = true;
        }


    }

    public void DecreasedYukseklik()
    {
        yukseklik -= 0.2f;
       // rb.velocity = new Vector3(transform.position.x, -100, transform.position.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pick" && other.gameObject.GetComponent<CollectibleScript>().isCollected == false)
        {
            yukseklik += 0.2f;
            other.gameObject.GetComponent<CollectibleScript>().MakeCollected();
            other.gameObject.GetComponent<CollectibleScript>().setIndex(yukseklik);
            other.gameObject.transform.parent = player.transform;
            other.gameObject.GetComponent<CollectibleScript>().gameManager = player.GetComponent<PlayerScript>().gameManager;
            other.gameObject.GetComponent<CollectibleScript>().collecterScript = this;




        }

        if (other.gameObject.tag == "money")
        {

            score += 1;
            scoretext.text = score.ToString();
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            other.gameObject.SetActive(false);


        }

            }

    
}
