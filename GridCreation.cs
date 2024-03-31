using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GridCreation : MonoBehaviour
{
    private int n;
    public int[][] table;

    void Start()
    {
        n = 3;
        CreateStartGrid();
    }

    private void CreateStartGrid()
    {
        table = new int[n * n][];

        for (int i = 0; i < n * n; i++)
        {
            table[i] = new int[n * n];
            for (int j = 0; j < n * n; j++)
            {
                table[i][j] = ((i * n + i / n + j) % (n * n) + 1); // i - строка, j - столбец (9*9)
            }
        }
    }

    public void Shuffle()
    {
        int shuffleCount, shuffleMethod;

        shuffleCount = Random.Range(6, 41);

        while(shuffleCount > 0) {

            shuffleMethod = Random.Range(1,4);
            ShuffleMethodDetermine(shuffleMethod);
            shuffleCount--;
        }
    }

    private void ShuffleMethodDetermine(int n)
    {
        if (n == 1)
        {
            Transport();
        } else if(n == 2)
        {
            int switchBigRow,firstSwitchSmall, secondSwitchSmall;

            switchBigRow = Random.Range( 0, 3);
            if(switchBigRow == 0)
            {
                firstSwitchSmall = Random.Range( 0, 3);
                secondSwitchSmall = Random.Range(0, 3);
                while (firstSwitchSmall == secondSwitchSmall)
                {
                    secondSwitchSmall = Random.Range(0, 3);
                }

                SwitchRows_small(firstSwitchSmall, secondSwitchSmall);
            } else if (switchBigRow == 1)
            {
                firstSwitchSmall = Random.Range(3, 6);
                secondSwitchSmall = Random.Range(3, 6);
                while (firstSwitchSmall == secondSwitchSmall)
                {
                    secondSwitchSmall = Random.Range(3, 6);
                }

                SwitchRows_small(firstSwitchSmall, secondSwitchSmall);
            }else if (switchBigRow == 2)
            {
                firstSwitchSmall = Random.Range(6, 9);
                secondSwitchSmall = Random.Range(6, 9);
                while (firstSwitchSmall == secondSwitchSmall)
                {
                    secondSwitchSmall = Random.Range(6, 9);
                }

                SwitchRows_small(firstSwitchSmall, secondSwitchSmall);
            }
        } else if(n == 3)
        {
            int firstSwitchBig, secondSwitchBig;
            firstSwitchBig = Random.Range(6, 9);
            secondSwitchBig = Random.Range(6, 9);
            while (firstSwitchBig == secondSwitchBig)
            {
                secondSwitchBig = Random.Range(6, 9);
            }

            SwitchRows_Big(firstSwitchBig, secondSwitchBig);
        }
    }

    private void Transport()
    {
        int[][] bufer;

        bufer = new int[9][];
        for (int k = 0; k < 9; k++)
        {
            bufer[k] = new int[9];
        }

        for (int l = 0;l < table.Length;l++)
        {
            for(int m = 0;m < table[l].Length; m++)
            {
                bufer[l][m] = table[l][m];
            }
        }

        for (int n = 0; n < table.Length; n++)
        {
            for (int p = 0; p < table[n].Length; p++)
            {
                table[n][p] = bufer[p][n];
            }
        }
    }

    private void SwitchRows_small(int firstRow, int secondRow)
    {
        int[] rowBufer;
        rowBufer = new int[9];

        rowBufer = table[firstRow];
        table[firstRow] = table[secondRow];
        table[secondRow] = rowBufer;

    }

    private void SwitchRows_Big(int firstRow, int secondRow)
    {

        int[][] bufer1;

        bufer1 = new int[3][];
        for (int a = 0; a < 3; a++)
        {
            bufer1[a] = new int[9];
        }

        if (firstRow == 0)
        {
            bufer1 = table[0..3];

            if (secondRow == 1)
            {
                table[3..6].CopyTo(table,0);
                bufer1.CopyTo(table,3);
            }else
            {
                table[6..9].CopyTo(table,0);
                bufer1.CopyTo(table, 6);
            }

        } else if(firstRow == 1)
        {
            bufer1 = table[3..6];

            if (secondRow == 0)
            {
                table[0..3].CopyTo(table, 3);
                bufer1.CopyTo(table, 0);
            }
            else
            {
                table[6..9].CopyTo(table, 3);
                bufer1.CopyTo(table, 6);
            }
        } else if (firstRow == 2)
        {
            bufer1 = table[6..9];

            if (secondRow == 0)
            {
                table[0..3].CopyTo(table, 6);
                bufer1.CopyTo(table, 0);
            }
            else
            {
                table[3..6].CopyTo(table, 6);
                bufer1.CopyTo(table, 3);
            }
        }
    }


}
