using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemyBody;

    private HealthSystem enemyHealth;
    public float Speed = 1.2f;
    public float MoveVertical = 0f;
    public float MoveHorziontal = 0f;

    public GameObject target;
    public bool isDying = false;
    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        enemyHealth = GetComponent<HealthSystem>();
        target = GameObject.Find("Player");
    }

    void FixedUpdate(){
        Vector2 movement = new Vector2(MoveHorziontal,MoveVertical) * Speed;
        enemyBody.velocity = -movement;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth.Hp <= 0)
            return;
        float distance = Vector3.Distance(transform.position, target.transform.position);
        //transform.position = Vector2.MoveTowards(transform.position,target.transform.position, Speed*Time.deltaTime);
        MoveHorziontal = transform.position.x - target.transform.position.x;
        MoveVertical = transform.position.y - target.transform.position.y;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        enemyBody.constraints = RigidbodyConstraints2D.FreezeAll;
        Debug.Log("OnCollisionEnter2D Enemy");
    }
}
