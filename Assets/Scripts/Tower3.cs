using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Tower3 : MonoBehaviour
{
    private Animator animator;
    public bool BrokenTower3;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        BrokenTower3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        animator.SetBool("isBroken", true);
        BrokenTower3 = true;
    }
}
