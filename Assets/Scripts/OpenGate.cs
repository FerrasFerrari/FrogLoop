using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    private Animator animator;
    public bool Broken; 
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isBroken", false);
        Broken = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        animator.SetBool("isBroken", true);
        Broken = true;
    }
}
