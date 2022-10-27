using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Grid grid;
    public bool isOnGrid;
    public float speedModifier = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<Grid>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = Vector3Int.RoundToInt(new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z + touch.deltaPosition.y * speedModifier));
            }
        }

    }
}
