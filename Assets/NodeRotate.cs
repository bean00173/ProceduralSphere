using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeRotate : MonoBehaviour
{

    private bool rotateStart;
    private GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateStart)
        {
            transform.RotateAround(go.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }

    public void Rotate(GameObject sphere)
    {
        rotateStart = true;
        go = sphere;
    }

}
