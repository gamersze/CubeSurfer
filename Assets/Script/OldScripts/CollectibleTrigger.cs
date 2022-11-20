using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class CollectibleTrigger : MonoBehaviour
{
    //bool iscollected;
    //int index;

    //public void start()
    //{
    //    iscollected = false;
    //}
    //public bool getıscollected()
    //{
    //    return iscollected;
    //}
    //public void makecollected()
    //{
    //    iscollected = true;
    //}
    //public void setındex(int index)
    //{
    //    this.index = index;

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pick")
        {
            StackManager.instance.detachChild = false;
            StackManager.instance.hittingObstacle = false;
            StackManager.instance.PickUp(false, other.gameObject, true, "Untagged");
            transform.parent = StackManager.instance.parentObject.transform;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            // other.GetComponent<BoxCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.parent = null;
            transform.GetComponent<Rigidbody>().isKinematic = true;

            StackManager.instance.detachChild = true;
            // StackManager.instance.detachedObject = gameObject;
            StackManager.instance.hittingObstacle = true;
            StackManager.instance.transform.position = new Vector3(StackManager.instance.transform.position.x, StackManager.instance.transform.position.y - 0.21f, StackManager.instance.transform.position.z);

            // transform.parent = StackManager.instance.transform.parent;

            StackManager.instance.pickedObjectList.Remove(gameObject);
            
            //  StackManager.instance.prevObject = StackManager.instance.pickedObjectList[StackManager.instance.pickedObjectList.Count - 1].transform;

        }

        
    }
  
}