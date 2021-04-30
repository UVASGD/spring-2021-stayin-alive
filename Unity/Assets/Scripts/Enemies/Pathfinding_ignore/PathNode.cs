using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    public PathGrid<PathNode> grid;
    public int x;
    public int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public bool isWalkable;
    public PathNode cameFromNode;

    public PathNode(PathGrid<PathNode> grid, int x, int y){
        this.grid = grid;
        this.x = x;
        this.y = y;
        isWalkable = true; //gonna have to manipulate this with collision stuff to get the true thing
    }

    public void CalculateFCost(){
        fCost = hCost + gCost;
    }

    public override string ToString() {
        return x + "," + y;
    }
}
