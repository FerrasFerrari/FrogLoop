using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToNormal : MonoBehaviour
{
    public TimeBomb TimeBombScript;
    public float delay = 3;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        TimeBombScript.NSM = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeBombScript.NSM == true) 
        {
            Debug.Log("viado");
            //timer += Time.deltaTime;
            //if (timer > delay)
           // {
                //Time.timeScale = 1f;
                //Time.fixedDeltaTime = Time.timeScale * .02f;
            //}
        }
    }
}
