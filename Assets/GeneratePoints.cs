using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePoints : MonoBehaviour
{
    Mesh mesh;
    SphereCollider sc;
    Vector3[] vertices;

    public GameObject plc;

    [SerializeField]
    private int horSegments;
    [SerializeField]
    private int vertSegments;

    public Transform nodeParent;

    private float curAngle;

    //List<Node> nodes = new List<Node> ();

    private Node[,] testList;

    public int[,] data
    {
        get; private set;
    }

    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SphereCollider>();

        testList = new Node[horSegments, vertSegments];
        

        data = FromDimensions(horSegments, vertSegments);

        CreatePoints(horSegments, vertSegments);


        // WORK ON BOUNDS FOR MAZE SPOTS


        for (int i = 0; i < vertSegments - 1; i++)
        {
            for (int j = 0; j < horSegments; j++)
            {
                if (testList[j, i].identity == 1)
                {
                    GameObject cube = Instantiate(plc, testList[j, i].pos, testList[j, i].rot);
                    cube.transform.parent = nodeParent;
                    cube.tag = "Node";
                }
                
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 surfAngle(Vector3 data)
    {
        RaycastHit hit;

        Vector3 dir = (data - this.transform.position).normalized;
        Physics.Raycast(data, dir, out hit);
        return hit.normal;
    }

    private void CreatePoints(int h, int v)
    {
        
        for (int i = 0; i < v - 1; i++)
        {
            Vector3 cap = new Vector3(this.transform.position.x, sc.radius - ((2 * sc.radius) / v) * (i + 1), this.transform.position.z);

            for (int j = 0; j < h; j++)
            {
                float rad = 2 * Mathf.PI / h * j;

                float vert = Mathf.Sin(rad);
                float hor = Mathf.Cos(rad);

                Vector3 spawn = new Vector3(hor, 0, vert);

                float newRadius = Mathf.Sqrt(Mathf.Pow(sc.radius, 2) - Mathf.Pow(cap.y, 2));

                Vector3 spawnPos = cap + spawn * newRadius;

                //nodes.Add(new Node(spawnPos, Quaternion.Euler(surfAngle(spawnPos))));

                

                testList[j, i] = new Node(spawnPos, Quaternion.Euler(surfAngle(spawnPos)), data[j,i]);
                //NodeSetting(j, i);

            }
        }

        //foreach(Node node in nodes)
        //{
        //    GameObject cube = Instantiate(plc, node.pos, node.rot);
        //    cube.transform.parent = nodeParent;
        //    cube.tag = "Node";
        //}

        
    }

    //public void NodeSetting(int h, int v)
    //{
    //    int rMax = testList.GetUpperBound(0);
    //    int cMax = testList.GetUpperBound(1);

    //    if (h == 0 || v == cMax)
    //        testList[h, v].identity = 1;
    //    else if (h % 2 == 0 && v % 2 == 0 && Random.value > .2f)
    //    {
    //        testList[h, v].identity = 1;

    //        int a = Random.value < .5 ? 0 : (Random.value < .5 ? -1 : 1);
    //        int b = a != 0 ? 0 : (Random.value < .5 ? -1 : 1);
    //        testList[h + a, v + b].identity = 1;
    //    }
    //}

    public int[,] FromDimensions(int sizeRows, int sizeCols)
    {
        int[,] maze = new int[sizeRows, sizeCols];

        int rMax = maze.GetUpperBound(0);
        int cMax = maze.GetUpperBound(1);

        for (int i = 0; i <= rMax; i++)
            for (int j = 0; j <= cMax; j++)
                if (i == 0 || j == 0 || i == rMax || j == cMax)
                    maze[i, j] = 1;
                else if (i % 2 == 0 && j % 2 == 0 && Random.value > .2f)
                {
                    maze[i, j] = 1;

                    int a = Random.value < .5 ? 0 : (Random.value < .5 ? -1 : 1);
                    int b = a != 0 ? 0 : (Random.value < .5 ? -1 : 1);
                    maze[i + a, j + b] = 1;
                }

        return maze;
    }

}


