using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDestroier : MonoBehaviour
{
    public OpenGate OpenScript;
    public Tower2 Tower2Script;
    public Tower3 Tower3Script;
    // Start is called before the first frame update
    void Start()
    {
        OpenScript.Broken = false;
        Tower2Script.BrokenTower2 = false;
        Tower3Script.BrokenTower3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenScript.Broken == true && Tower2Script.BrokenTower2 == true && Tower3Script.BrokenTower3 == true)
        {
            Destroy(gameObject);
        }
    }
}
