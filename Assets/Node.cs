using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector3 pos;
    public Quaternion rot;
    public int identity;

    public Node(Vector3 pos, Quaternion rot, int identity)
    {
        this.pos = pos;
        this.rot = rot;
        this.identity = identity;
    }
}
