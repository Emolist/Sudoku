using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    public TMP_InputField inputField;
    public int emptySlots;

    void Start()
    {
        inputField.contentType = TMP_InputField.ContentType.DecimalNumber;
    }

    public int Check()
    {
        emptySlots = int.Parse(inputField.text);
        return emptySlots;
    }

}
