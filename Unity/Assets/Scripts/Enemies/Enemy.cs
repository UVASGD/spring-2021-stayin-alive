using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Destructible
{
    public float speed = .1f;
    public float aggroRange = 5f;
    public float meleeRange = 1.5f;

    public float damage;
    public float swingTimer;
    public float lastSwing = 0;

    private Rigidbody2D enemyRb;
    public GameObject player;
    public GameManager gm;


    //private float pathFindingTimer;
    //private int currentPathIndex;
    //private List<Vector2> pathVectorList;

    

    // Start is called before the first frame update
    void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.isActive){
            if(GetDistance(player) <= aggroRange){
                MoveTowards(player);
            }
            lastSwing += Time.deltaTime;
        }
        

        // Vector2 lookDirection = player.transform.position - transform.position;
        // enemyRb.AddForce(lookDirection * speed, ForceMode2D.Impulse);
        // enemyRb.MovePosition(player.transform.position);
    }


    private float GetDistance(GameObject target){
        return Vector3.Distance(target.transform.position, transform.position);
    }

    private void MoveTowards(GameObject target){
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 targetPosition = new Vector2(target.transform.position.x, target.transform.position.y);
        if (Vector2.Distance(currentPosition, targetPosition) > meleeRange){
            Vector2 moveDir = (targetPosition - currentPosition).normalized;
            transform.position = new Vector3(currentPosition.x + moveDir.x * speed * Time.deltaTime, currentPosition.y + moveDir.y * speed * Time.deltaTime, 0);
        } else{
            Attack(target.GetComponent<Destructible>());
        }
    }

    private void Attack(Destructible target){
        if (lastSwing >= swingTimer){
            target.TakeDamage(damage);
            lastSwing = 0;
        }
    }
}











/* remnants of me trying to be cool scripting used from: https://www.youtube.com/watch?v=db0KWYaWfeM
    private void HandleMovement(){
        if (pathVectorList != null){
            Vector2 targetPosition = pathVectorList[currentPathIndex];
            Vector2 currentPosition = GetPosition();
            if (Vector2.Distance(currentPosition, targetPosition) > 1f){   //decides how close to the thing we wanna go
                Vector2 moveDir = (targetPosition - currentPosition).normalized;

                float distanceBefore = Vector2.Distance(currentPosition, targetPosition);
                transform.position = new Vector3(currentPosition.x + moveDir.x * speed * Time.deltaTime, currentPosition.y + moveDir.y * speed * Time.deltaTime, 0);
            } else{
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count){
                    StopMoving();
                }
            }
        }
    }

    public void MoveTo(Vector2 targetPosition){
        SetTargetPosition(targetPosition);
    }


    private void StopMoving(){
        pathVectorList = null;
    }

    public void SetTargetPosition(Vector2 targetPosition){
        currentPathIndex = 0;
        pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPosition);
        if (pathVectorList != null && pathVectorList.Count > 1){
            pathVectorList.RemoveAt(0);
        }
    }

    public Vector2 GetPosition(){
        return new Vector2(transform.position.x, transform.position.y);
    }

}
*/