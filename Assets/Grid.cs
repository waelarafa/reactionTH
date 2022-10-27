using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public Vector3 smoothMousePosition;
    public Transform onMousePrefab;
    public Transform fillGridPrefab;
    public Transform newObject;

    [SerializeField]
    Transform cellPrefab;
    [SerializeField]
    int width, height;

    public Node[,] nodes;

    float x;
    float z;
    float cellScale;
    float offset = 0.0001f;

    Plane plane;

    Vector3 mousePosition;

    public void Start()
    {
        //cash coordinates and scale 
        x = transform.position.x;
        z = transform.position.z;

        cellScale = cellPrefab.transform.localScale.x * 10;

        CreateGrid();
        plane = new Plane(Vector3.up, transform.position);
    }

    void Update()
    {
    }

    void GetMousePositionOnGrid()
    {

       
    }


    public void OnButtons()
        {

            if (onMousePrefab == null)
            {
                onMousePrefab = Instantiate(fillGridPrefab, mousePosition, Quaternion.identity);
                onMousePrefab.transform.parent = transform.parent;
          
            }
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
                    
                    
                    nodes[iMatrix, jMatrix] = new Node(true, worldPosition, obj.transform.position, obj);

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
        public Vector3 localPos;
        public Transform obj;

        public Node(bool isPlaceable, Vector3 cellPosition,Vector3 localPos, Transform obj)
        {
            this.isPlaceable = isPlaceable;
            this.cellPosition = cellPosition;
            this.obj = obj;
            this.localPos = localPos;
        }
    }
