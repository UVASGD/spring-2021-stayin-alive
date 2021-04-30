using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGrid<TGridObject>
{
    private int width;
    private int height;
    private float cellSize;
    private Vector2 originPosition;

    private TGridObject[,] gridArray;

    public PathGrid(int width, int height, float cellSize, Vector2 originPosition, Func<PathGrid<TGridObject>, int, int, TGridObject> createGridObject){
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
    

        gridArray = new TGridObject[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++){
            for (int y = 0; y< gridArray.GetLength(1); y++){
                gridArray[x,y] = createGridObject(this, x, y);
            }
        }
    }

    public Vector2 GetWorldPosition(int x, int y){
        return new Vector2(x,y) * cellSize + originPosition;
    }

    public void GetXY(Vector2 worldPosition, out int x, out int y){
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetGridObject(int x, int y, TGridObject value){
        if (x >= 0 && y >= 0 && x < width && y < height){
            gridArray[x,y] = value;
        } 
    }

    public void SetGridObject(Vector2 worldPosition, TGridObject value){
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetGridObject(x, y, value);
    }

    public TGridObject GetGridObject(int x, int y){
        if (x >= 0 && y >= 0 && x < width && y < height){
            return gridArray[x,y];
        } 
        return default(TGridObject);
    }

    public TGridObject GetGridObject(Vector2 worldPosition){
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetGridObject(x,y);
    }

    public float GetCellSize(){
        return cellSize;
    }

    public int GetWidth(){
        return width;
    }

    public int GetHeight(){
        return height;
    }

}
