using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    public void Clean()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}
