using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{

    public static StackManager instance;

    [SerializeField] private float distanceBetweenObject;
    [SerializeField] public Transform prevObject;
    [SerializeField] public Transform parent;
    public GameObject parentObject;
    public bool hittingObstacle;
    public GameObject obstacle;
    public List<GameObject> pickedObjectList;
    public bool detachChild;
    public GameObject detachedObject;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
    }

    void Start()
    {

        distanceBetweenObject = prevObject.localScale.y;

    }

    public void PickUp(bool downOrup, GameObject pickedObject, bool needTag = false, string tag = null)
    {
        if (needTag)
        {
            pickedObject.tag = tag;
        }

        pickedObject.transform.parent = parent;
        Vector3 desPosition = prevObject.localPosition;
        desPosition.y += downOrup ? distanceBetweenObject : -distanceBetweenObject;

        pickedObject.transform.localPosition = desPosition;
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.21f, transform.position.z);
        prevObject = pickedObject.transform;

        pickedObjectList.Add(pickedObject);

        if (pickedObjectList.Remove(pickedObject))
        {
            prevObject = pickedObjectList[pickedObjectList.Count - 1].transform;
        }
    }

    void Update()
    {
        if (detachChild)
        {
            prevObject.transform.parent = null;

            /* for (int i = 0; i < pickedObjectList.Count; i++)
             {
                 Destroy(pickedObjectList[i]);
             }
            */

        }

        if (hittingObstacle)
        {
            detachChild = true;
            
        }



    }
}
