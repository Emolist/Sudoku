using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SudokuChecker : MonoBehaviour
{
    GridCreation gridCreation;
    public GridVisualization gridVisualization;
    public GameObject grid;
    GameObject[][] gridToNumber;

    int[][] currentTable;
    public List<int> row, col, val;
    int n = 0, m = 0;

    private void Start()
    {
        gridCreation = GameObject.FindGameObjectWithTag("GameController").GetComponent<GridCreation>();
        gridVisualization = GameObject.FindGameObjectWithTag("GameController").GetComponent<GridVisualization>();

        currentTable = new int[9][];
        gridToNumber = new GameObject[9][];
        for (int k = 0; k < currentTable.Length; k++)
        {
            currentTable[k] = new int[9];
            gridToNumber[k] = new GameObject[9];
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
                gridToNumber[i][j] = gridVisualization.visibleTable[i][j];
            }
        }
        n = 0;

        for (int l = 0; l < 9; l++)
        {
            for (int m = 0; m < 9; m++)
            {
                if (int.Parse(gridToNumber[l][m].GetComponentInChildren<TMP_Text>().text) != gridCreation.table[l][m])
                {
                    gridToNumber[l][m].GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, 0.8f);
                    row.Add(l); col.Add(m); val.Add(int.Parse(gridToNumber[l][m].GetComponentInChildren<TMP_Text>().text));
                }
                else
                {
                    gridToNumber[l][m].GetComponent<Image>().color = Color.white;
                    gridToNumber[l][m].GetComponentInChildren<Button>().interactable = false;
                }
            }
        }

        foreach (int item in val)
        {
            int r = row[m];
            int c = col[m];

            for (int i = 0; i < 9; i++)
            {
                if(int.Parse(gridToNumber[r][i].GetComponentInChildren<TMP_Text>().text) == item && !gridToNumber[r][i].GetComponentInChildren<Button>().interactable)
                {
                    gridToNumber[r][i].GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, 0.6f);
                }
            }

            for (int j = 0; j < 9; j++)
            {
                if (int.Parse(gridToNumber[j][c].GetComponentInChildren<TMP_Text>().text) == item && !gridToNumber[j][c].GetComponentInChildren<Button>().interactable)
                {
                    gridToNumber[j][c].GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, 0.6f);
                }
            }
            m++;
        }

        row.Clear();
        col.Clear();
        val.Clear();
        m = 0;
    }
}
