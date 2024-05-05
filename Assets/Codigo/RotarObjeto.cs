using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarObjeto : MonoBehaviour
{
    public bool x;
    public bool y;
    public bool z;
    // Update is called once per frame
    void Update()
    {
        if (x == true)
            transform.Rotate(1, 0, 0);
        else if (y == true)
            transform.Rotate(0, 1, 0);
        else if (z == true)
            transform.Rotate(0, 0, 1);
    }
}
