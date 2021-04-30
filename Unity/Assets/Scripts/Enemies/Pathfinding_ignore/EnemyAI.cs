using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
/*
    private Vector2 startingPosition;
    private Vector2 roamPosition;
    public Enemy pathFindingMovement;
    
    void Awaken(){
        pathFindingMovement = GetComponentInChildren<Enemy>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = new Vector2(transform.position.x, transform.position.y);
        roamPosition = GetRoamingPosition();
    }

    // Update is called once per frame
    void Update()
    {
        pathFindingMovement.MoveTo(roamPosition);
        if(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), roamPosition) <= 1f){
            roamPosition = GetRoamingPosition();

        }
    }

    private Vector2 GetRoamingPosition(){
        return startingPosition + (new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f,1f)).normalized) * Random.Range(4f, 8f); //distance itll roam
    }
*/
}
