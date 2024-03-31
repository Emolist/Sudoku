using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GridVisualization : MonoBehaviour
{
    public GameObject grid, cell, creatingText;
    public GameObject[][] visibleTable;

    GridCreation tableSource;
    PlayerActions playerActions;
    SingleTable single;

    int[][] table;
    bool draw;

    private void Awake()
    {
        grid = GameObject.FindWithTag("Grid");
        tableSource = GameObject.FindWithTag("GameController").GetComponentInChildren<GridCreation>();
        playerActions = GameObject.FindWithTag("GameController").GetComponentInChildren<PlayerActions>();
        single = GameObject.FindWithTag("GameController").GetComponentInChildren<SingleTable>();
    }

    void Start()
    {
        
        table = new int[9][];
        for (int a = 0; a < 9; a++)
        {
            table[a] = new int[9];
        }

        visibleTable = new GameObject[9][];
        for (int b = 0; b < 9; b++)
        {
            visibleTable[b] = new GameObject[9];
        }
    }

    public void Display()
    {
        if (!draw && single.counter == 1)
        {
            draw = true;
            creatingText.SetActive(true);
            StartCoroutine(Fill());
        }
    }

    IEnumerator Fill()
    {
        yield return new WaitForSeconds(3f);

        for (int d = 0; d < 9; d++)
        {
            for (int e = 0; e < 9; e++)
            {
                table[d][e] = tableSource.table[d][e];
            }
        }

        int empty = playerActions.Check();

        int n = 0;
        int first, second;

        while (n<empty)
        {
            first = Random.Range(0, 9);
            second = Random.Range(0, 9);

            if (table[first][second] != 0)
            {
                table[first][second] = 0;
            } 
            n++;
        }

        for (int f = 0; f < 9; f++)
        {
            for (int g = 0; g < 9; g++)
            {
                GameObject newButton = Instantiate(cell, grid.transform) as GameObject;
                visibleTable[f][g] = newButton;
                if (table[f][g] != 0)
                {
                    newButton.GetComponentInChildren<TMP_Text>().text = table[f][g].ToString();
                    newButton.GetComponentInChildren<Button>().interactable = false;
                } else newButton.GetComponentInChildren<TMP_Text>().text = " ";
            }
        }
        draw = false;
        single.counter = 0;
        creatingText.SetActive(false);
    }

}
