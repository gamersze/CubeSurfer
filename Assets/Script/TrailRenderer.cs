using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRenderer : MonoBehaviour
{
    public TrailRenderer trail;
    public GameObject collecter;


    private void Start()
    {
     // collecter.transform.position = trail.transform.position;
        trail.transform.position = new Vector3(collecter.transform.position.x, collecter.transform.position.y, collecter.transform.position.z);
    }
}
