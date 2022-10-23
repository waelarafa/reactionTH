using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    Transform cellPrefab;
    [SerializeField]
    int width, height;



    Node[,] nodes;

    float x;
    float z;
    float cellScale;
    float offset = 0.0001f;



    public void Start()
    {
        //cash coordinates and scale 
        x = transform.position.x;
        z = transform.position.z;

        cellScale = cellPrefab.transform.localScale.x;

        CreateGrid();
    }


    void CreateGrid()
    {
        nodes = new Node[width, height];

        int name = 0;
        int jMatrix = 0;
        for (float i = x; i < ((width * cellScale + x) - offset); i += cellScale)
        {
            int iMatrix = 0;
            for (float j = z; j < ((height * cellScale + z) - offset); j += cellScale)
            {
                Vector3 worldPosition = new Vector3(i, transform.position.y, j);
                Transform obj = Instantiate(cellPrefab, worldPosition, Quaternion.identity);

                obj.parent = transform;
                obj.name = "Cell" + name;

                nodes[iMatrix, jMatrix] = new Node(true, worldPosition, obj);

                name++;
                iMatrix++;
            }

            jMatrix++;
        }
    }




}


public class Node
{
    public bool isPlaceable;
    public Vector3 cellPosition;
    public Transform obj;

    public Node(bool isPlaceable, Vector3 cellPosition, Transform obj)
    {
        this.isPlaceable = isPlaceable;
        this.cellPosition = cellPosition;
        this.obj = obj;

    }
}