using UnityEngine;

public class Trace : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private int index = 0;
    public bool ground;

    // Start is called before the first frame update
    void Start()
    {
        ground = isGrounded();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.alignment = LineAlignment.TransformZ;
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(index, new Vector3(transform.position.x, 1.01f, transform.position.z));

        lineRenderer.startWidth = 0.45f / transform.localScale.z;
        lineRenderer.endWidth = 0.45f / transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //Debug.Log(transform.GetChild(transform.childCount - 1).name);
        if (ground)
        {
            print("qq");
            index++;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(index, new Vector3(transform.position.x, 1.01f, transform.position.z));
        }
        else if (isGrounded())
        {
            index = 0;
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(index, new Vector3(transform.position.x, 1.01f, transform.position.z));
        }

        ground = isGrounded();
    }

    bool isGrounded()
    {
        if (transform.childCount >= 2)
        {
            print("12");
            //Debug.Log(transform.parent.GetChild(transform.parent.childCount - 1));
            var position = transform.GetChild(transform.childCount - 1).position.y;

        }
        return true;

    }
}
