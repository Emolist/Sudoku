using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SudokuChecker : MonoBehaviour
{
    GridCreation gridCreation;
    public GameObject grid;
    GameObject[][] gridToNumber;

    int[][] currentTable;
    int n = 0;

    private void Start()
    {
        gridCreation = GameObject.FindGameObjectWithTag("GameController").GetComponent<GridCreation>();

        currentTable = new int[9][];
        for (int k = 0; k < currentTable.Length; k++)
        {
            currentTable[k] = new int[9];
        }
    }


    private void Update()
    {
        
    }

    public void Check()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                n++;
                GameObject Cell = grid.GetComponentInChildren<GameObject>();
                gridToNumber[i][j] = Cell;
            }
        }
        n = 0;

        for (int l = 0; l < 9; l++)
        {
            for (int m = 0; m < 9; m++)
            {
                if (currentTable[l][m] != gridCreation.table[l][m])
                {
                    Debug.Log("Error" + l + m);
                }
                else Debug.Log("Correct answer");
            }
        }
    }
}
