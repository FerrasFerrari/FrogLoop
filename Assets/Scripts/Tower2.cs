using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : MonoBehaviour
{
    public bool BrokenTower2;
    // Start is called before the first frame update
    void Start()
    {
        BrokenTower2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        BrokenTower2 = true;
    }
}
