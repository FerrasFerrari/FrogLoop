using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower3 : MonoBehaviour
{
    public bool BrokenTower3;
    // Start is called before the first frame update
    void Start()
    {
        BrokenTower3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        BrokenTower3 = true;
    }
}
