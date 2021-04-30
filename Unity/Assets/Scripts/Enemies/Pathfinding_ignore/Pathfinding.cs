using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
/*
    //scripting from https://www.youtube.com/watch?v=alU04hvz6L4

    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    public static Pathfinding Instance { get; private set;}

    private PathGrid<PathNode> grid;
    private List<PathNode> openList;
    private List<PathNode> closedList;


    public Pathfinding(int width, int height){
        grid = new PathGrid<PathNode>(width, height, 1f, Vector2.zero, (PathGrid<PathNode> g, int x, int y) => new PathNode(g, x, y));
        Instance = this;
    }

    public List<Vector2> FindPath(Vector2 startWorldPosition, Vector2 endWorldPosition){
        grid.GetXY(startWorldPosition, out int startX, out int startY);
        grid.GetXY(endWorldPosition, out int endX, out int endY);

        List<PathNode> path = FindPath(startX, startY, endX, endY);
        if (path == null){
            return null;
        } else{
            List<Vector2> vectorPath = new List<Vector2>();
            foreach (PathNode pathNode in path){
                vectorPath.Add(new Vector2(pathNode.x, pathNode.y) * grid.GetCellSize() + Vector2.one * grid.GetCellSize() * .5f);
            }
            return vectorPath;
        }
    }

    public List<PathNode> FindPath(int startX, int startY, int endX, int endY){
        PathNode startNode = grid.GetGridObject(startX, startY);
        PathNode endNode = grid.GetGridObject(endX, endY);
        
        openList = new List<PathNode>{ startNode };
        closedList = new List<PathNode>();

        for (int x = 0; x < grid.GetWidth(); x++) {
            for (int y = 0; y < grid.GetHeight(); y++){
                PathNode pathNode = grid.GetGridObject(x,y);
                pathNode.gCost = int.MaxValue;
                pathNode.CalculateFCost();
                pathNode.cameFromNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while (openList.Count > 0){
            PathNode currentNode = GetLowestFCostNode(openList);
            if(currentNode == endNode){
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (PathNode neighborNode in GetNeighborList(currentNode)){
                if(closedList.Contains(neighborNode)) continue;
                if (!neighborNode.isWalkable){
                    closedList.Add(neighborNode);
                    continue;
                }
                int tentativeGcost = currentNode.gCost + CalculateDistanceCost(currentNode, neighborNode);
                if (tentativeGcost < neighborNode.gCost){
                    neighborNode.cameFromNode = currentNode;
                    neighborNode.gCost = tentativeGcost;
                    neighborNode.hCost = CalculateDistanceCost(neighborNode, endNode);
                    neighborNode.CalculateFCost();

                    if(!openList.Contains(neighborNode)){
                        openList.Add(neighborNode);
                    }
                }
            }

        }

        //out of nodes on openList
        return null;

    }

    private List<PathNode> GetNeighborList(PathNode currentNode){
        List<PathNode> neighborList = new List<PathNode>();

        if (currentNode.x - 1 >= 0){
            //Left
            neighborList.Add(GetNode(currentNode.x - 1, currentNode.y));
            //left down
            if (currentNode.y - 1 >= 0) neighborList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));
            //left up
            if (currentNode.y + 1 < grid.GetHeight()) neighborList.Add(GetNode(currentNode.x - 1, currentNode.y + 1));
        }
        if (currentNode.x + 1 < grid.GetWidth()){
            //Right
            neighborList.Add(GetNode(currentNode.x + 1, currentNode.y));
            //Right down
            if (currentNode.y - 1 >= 0) neighborList.Add(GetNode(currentNode.x + 1, currentNode.y - 1));
            //Right up
            if (currentNode.y + 1 < grid.GetHeight()) neighborList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));
        }
        //down
        if (currentNode.y - 1 >= 0) neighborList.Add(GetNode(currentNode.x, currentNode.y - 1));
        //up
        if (currentNode.y + 1 < grid.GetHeight()) neighborList.Add(GetNode(currentNode.x, currentNode.y + 1));

        return neighborList;
    }

    private PathNode GetNode(int x, int y){
        return grid.GetGridObject(x,y);
    }

    private List<PathNode> CalculatePath(PathNode endNode){
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        PathNode currentNode = endNode;
        while (currentNode.cameFromNode != null){
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }
        path.Reverse();
        return path;
    }

    private int CalculateDistanceCost(PathNode a, PathNode b){
        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);
        int remaining = Mathf.Abs(xDistance - yDistance);
        return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    }

    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList){
        PathNode lowestFCostNode = pathNodeList[0];
        for (int i = 1; i < pathNodeList.Count; i++){
            if (pathNodeList[i].fCost < lowestFCostNode.fCost){
                lowestFCostNode = pathNodeList[i];
            }
        }
        return lowestFCostNode;
    }
*/
}
