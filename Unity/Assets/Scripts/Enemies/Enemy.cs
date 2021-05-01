using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Destructible
{
    public float speed = .1f;
    public float aggroRange = 5f;
    public float meleeRange = 1.5f;
    public float closeRange = .5f;

    public float damage;
    public float swingTimer;
    public float lastSwing = 0;

    private Rigidbody2D enemyRb;
    public GameObject player;
    public GameManager gm;
    public AudioClip[] clips = new AudioClip[6]; //[0-3] are attacks, [4-5] are death noises 
    public AudioSource[] source; //[0-2 are creation noises]

    //private float pathFindingTimer;
    //private int currentPathIndex;
    //private List<Vector2> pathVectorList;

    

    // Start is called before the first frame update
    void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        source = this.gameObject.GetComponents<AudioSource>();
        //source[Random.Range(0,3)].Play();
        //AudioSource.PlayClipAtPoint(clips[Random.Range(4,6)], transform.position);
        enemyRb.constraints = RigidbodyConstraints2D.FreezeRotation;
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
        if (Vector2.Distance(currentPosition, targetPosition) > closeRange){
            Vector2 moveDir = (targetPosition - currentPosition).normalized;
            transform.Translate(moveDir * speed * Time.deltaTime);
        } 
        if (Vector2.Distance(currentPosition, targetPosition) <= meleeRange) {
            Attack(target.GetComponent<Destructible>());
        }
    }

    private void Attack(Destructible target){
        if (lastSwing >= swingTimer){
            //source[Random.Range(0,4)].PlayClipAtPoint();
            AudioSource.PlayClipAtPoint(clips[Random.Range(0,4)], transform.position);
            target.TakeDamage(damage);
            lastSwing = 0;
        }
    }

    public override void Die(){
        //source[Random.Range(7,9)].Play();
        AudioSource.PlayClipAtPoint(clips[Random.Range(4,6)], transform.position);
        Destroy(gameObject);
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