using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public Vector3 startPosition;
    public GameManager gameManager;

    public void Start()
    {
        startPosition = transform.position;
        
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime);

        if (GameManager.makeNext)
        {
            this.transform.position = startPosition;
        }
    }
}
