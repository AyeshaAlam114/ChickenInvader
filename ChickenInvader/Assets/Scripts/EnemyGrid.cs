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

   // Cell.Status currentTurn = Cell.Status.cross;

   public EnemyGrid(int NumberOfRows,int NumberOfColumns) : base(NumberOfRows, NumberOfColumns)
    {
        //GridInitializer(numberOfRows, numberOfColumns);
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
                //GameObject tempCell =new GameObject();
                //enemyGrid[row].Add(tempCell);
                cellCreated?.Invoke();
               // tempCell.cellStatusUpdate += GridCellStatus;
            }
        }
        indicator?. Invoke(0);
    }

    //public void GridCellStatus(int row,int col)
    //{
    //    if (enemyGrid[row][col].GetStatus() == Cell.Status.none)
    //    {
    //        enemyGrid[row][col].SetStatus(currentTurn);
    //        SetSingleElementAtIndex(row, col, (int)currentTurn);
    //        ChangeTurn(currentTurn);
    //        CheckWin(row,col);
    //    }
        
    //}

    //public void ChangeTurn(Cell.Status currentTurn)
    //{
    //    switch (currentTurn)
    //    {
    //        case Cell.Status.cross:
    //            SwitchToCircle();
    //            break;
    //        case Cell.Status.circle:
    //            SwitchToCross();
    //            break;
    //    }
    //}

    //private void SwitchToCross()
    //{
    //    currentTurn = Cell.Status.cross;
    //}

    //private void SwitchToCircle()
    //{
    //    currentTurn= Cell.Status.circle;
    //}

    //public void CheckWin(int row,int col)
    //{
    //    if (IsRowSame(row))
    //    {
    //        SetRowOfMatrixTo(row,(int)Cell.Status.win);
    //        enemyGrid[row][col].SetStatus(GetSingleElementOfIndex(row, col));
    //        PrintMatrix();
    //    }
    //}

}
