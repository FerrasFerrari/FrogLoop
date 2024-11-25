using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalk : MonoBehaviour
{
    public float rayDist;
    public float speed;
    public bool movingRight;
    public Transform wallDetect;
    public Transform wallDetectL;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right);
        RaycastHit2D wallcheckR = Physics2D.Raycast(wallDetect.position, Vector2.down, rayDist);
        if(wallcheckR.collider == false)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, - 180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        
    }
}
