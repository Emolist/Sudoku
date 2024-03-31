using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTable : MonoBehaviour
{
    public int counter;

    private void Start()
    {
        counter = 0;
    }

    public void Switch()
    {
        counter++;
    }
}
