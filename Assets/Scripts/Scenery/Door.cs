using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private BoxCollider2D doorCollider;
    private Animator animator;
    
    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        doorCollider.enabled = false;
    }

    public void Close(){
        animator.SetTrigger("Close");
        doorCollider.enabled = true;
    }
    public void Open(){
        animator.SetTrigger("Open");
        doorCollider.enabled = false;
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position + new Vector3(GetComponent<BoxCollider2D>().offset.x, 
        GetComponent<BoxCollider2D>().offset.y, 0), GetComponent<BoxCollider2D>().size);
    }
}
