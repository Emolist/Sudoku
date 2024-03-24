using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Solving : MonoBehaviour
{
    int number = 1;
    public void Insert()
    {
        this.gameObject.GetComponentInChildren<TMP_Text>().text = number.ToString();

        if (number < 9)
        {
            number++;
        }
        else number = 1;
    }
}
