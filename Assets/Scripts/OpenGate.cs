using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public bool Broken; 
    // Start is called before the first frame update
    void Start()
    {
        Broken = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        Broken = true;
    }
}
