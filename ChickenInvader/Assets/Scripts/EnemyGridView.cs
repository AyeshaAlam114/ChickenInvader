using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGridView : MonoBehaviour
{
    public int numberOfRows, numberOfCol;
    // public GameObject cellPrefab;
    GameObject prefab;
    public Transform SpawnPosition;
    public Transform InitialPosition;
    public float horizontalGap, verticalGap, nextLineIndicator=0;
    



    // Start is called before the first frame update
    void Start()
    {
        //InitialPosition = SpawnPosition;
        //Debug.Log(SpawnPosition.position);
        //Debug.Log(InitialPosition.position);
        // Initializer();

    }

    public void ResetSpawnPosition()
    {
        SpawnPosition.position = InitialPosition.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initializer(int numberOfRows,int numberOfCol,GameObject prefab)
    {

        //CellView CellToSpawn = new CellView();
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
                //Debug.Log("1--------");
                //Debug.Log(nextLineIndicator);
                nextLineIndicator++;
                
                return HorizontalShift();
            }
            //if (nextLineIndicator > numberOfCol - 1)
              
            else
            {
                //Debug.Log("2--------");
                //Debug.Log(nextLineIndicator);
                Vector3 yPos= VerticalShift();
                
                //nextLineIndicator++;
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
        //Debug.Log("ss");
        Instantiate(prefab, PositionSetter(), Quaternion.identity,SpawnPosition);

        //cellView.SetCell(cell);
        //SpawnPosition.position = cellView.transform.position;
    }
    public void SetIndicatorToZero(int valueToindicator)
    {
        nextLineIndicator = valueToindicator;
    }
}
