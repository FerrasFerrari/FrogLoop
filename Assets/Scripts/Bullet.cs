using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    public Rigidbody2D BulletRB;
    public Vector2 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        BulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDir = (target.transform.position - transform.position).normalized * speed;
        BulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
