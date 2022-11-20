using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTrigger : MonoBehaviour
{


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
}
