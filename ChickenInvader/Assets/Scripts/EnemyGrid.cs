using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : Matrix
{
    public List<List<GameObject>> enemyGrid=new List<List<GameObject>>();

    public delegate void CellIsCreated();
    public CellIsCreated cellCreated;
    public delegate void LineIndicator(int indicatorValue);
    public LineIndicator indicator;
    int numberOfRows;
    int numberOfColumns;
    GameObject prefab;


   public EnemyGrid(int NumberOfRows,int NumberOfColumns) : base(NumberOfRows, NumberOfColumns)
    {
        numberOfRows = NumberOfRows;
        numberOfColumns = NumberOfColumns;
    }

    public void GridInitializer()
    {
        for (int row = 0; row < numberOfRows; row++)
        {
            enemyGrid.Add(new List<GameObject>());
            for (int col = 0; col < numberOfColumns; col++)
            {
                cellCreated?.Invoke();
            }
        }
        indicator?. Invoke(0);
    }

 
}
