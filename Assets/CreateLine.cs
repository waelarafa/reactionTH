using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateLine : MonoBehaviour
{

    public LineRenderer lr;
    public float vertexCount = 6;
    public Camera camera;


    [SerializeField]
    private GameObject LineRenderer;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject crossHair;
    [SerializeField]
    private float maxDistance;


    private bool heldOn;
    // Start is called before the first frame update
    void Start()
    {
        lr = LineRenderer.GetComponent<LineRenderer>();

        crossHair.transform.position = new Vector3(Screen.width / 2, Screen.height / 8, Camera.main.nearClipPlane);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 8, Camera.main.nearClipPlane));
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "interactable")
            {
                Transform objectHit = hit.transform;

                // Do something with the object that was hit by the raycast.
                target = objectHit.gameObject;

                //if we are pressing button
                if (LongPress.Instance.heldOn)
                {   
                    //here we are trying to make the pointer 
                    Vector3 Point1 = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 8, Camera.main.nearClipPlane));
                    var Point2 = target.transform.position;
                    var middle = new Vector3((Point1.x + Point2.x) / 2, 0.1f, (Point1.z + Point2.z) / 2);

                    var pointList = new List<Vector3>(); ;

                    for (float i = 0; i <= 1; i += 1 / vertexCount)
                    {
                        var tangent1 = Vector3.Lerp(Point1, middle, i);
                        var tangent2 = Vector3.Lerp(middle, Point2, i);
                        var curve = Vector3.Lerp(tangent1, tangent2, i);
                        pointList.Add(curve);
                    }

                    lr.positionCount = pointList.Count;
                    lr.SetPositions(pointList.ToArray());

                    //here we are linking the object to the camera so we can move it 
                    target.transform.parent.gameObject.transform.parent = camera.transform;
                }
                else
                {   //else we free the object from the camera and we delet the pointer
                    target.transform.parent.gameObject.transform.parent = null;
                    lr.positionCount = 0;

                }

            }
            else
                return;

            


        }

    }

    
   
}
