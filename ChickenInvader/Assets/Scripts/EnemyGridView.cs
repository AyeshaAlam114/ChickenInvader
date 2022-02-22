using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGridView : MonoBehaviour
{
    public int numberOfRows, numberOfCol;
    GameObject prefab;
    public Transform SpawnPosition;
    public Transform InitialPosition;
    public float horizontalGap, verticalGap, nextLineIndicator=0;
    




    public void ResetSpawnPosition()
    {
        SpawnPosition.position = InitialPosition.position;
    }
   

    public void Initializer(int numberOfRows,int numberOfCol,GameObject prefab)
    {

        EnemyGrid grid = new EnemyGrid(numberOfRows, numberOfCol);
        this.numberOfCol = numberOfCol;
        this.numberOfRows = numberOfRows;
        this.prefab = prefab;
        grid.cellCreated += CellCreator;
        grid.indicator += SetIndicatorToZero;
        grid.GridInitializer();


    }

    Vector3 PositionSetter()
    {
        if (SpawnPosition.childCount > 0)
        {
            if (nextLineIndicator < numberOfCol-1)
            {
                nextLineIndicator++;
                
                return HorizontalShift();
            }
              
            else
            {
                Vector3 yPos= VerticalShift();
                nextLineIndicator = 0;
                return yPos;
            }
        }
        return SpawnPosition.position;
    }

    private Vector3 VerticalShift()
    {
        
        float incrementX = -8.4f;
        float incrementY = SpawnPosition.GetChild(SpawnPosition.childCount - 1).position.y - verticalGap;
        return new Vector3(incrementX, incrementY, SpawnPosition.GetChild(SpawnPosition.childCount - 1).position.z);
    }

    private Vector3 HorizontalShift()
    {
        float increment = SpawnPosition.GetChild(SpawnPosition.childCount-1).position.x + horizontalGap;
        return new Vector3(increment, SpawnPosition.GetChild(SpawnPosition.childCount - 1).position.y, SpawnPosition.GetChild(SpawnPosition.childCount - 1).position.z);
    }

    public void CellCreator()
    {
        Instantiate(prefab, PositionSetter(), Quaternion.identity,SpawnPosition);
    }
    public void SetIndicatorToZero(int valueToindicator)
    {
        nextLineIndicator = valueToindicator;
    }
}
