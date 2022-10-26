using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int rows = 18;
    private int cols = 18;
    private float tileSize = 1;

    public List<Cell> cells;

    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Cell cell = new Cell(row, col);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public class Cell
    {
        // should contain a node to all other connected cells
        // a spawnPoint to spawn creture or obstacle
        // 
        public int RowNumber {get; set;}
        public int ColNumber {get; set;}

        

        public Cell(int rowNr, int colNr)
        {
            RowNumber = rowNr;
            ColNumber = colNr;
        }

    }
}
