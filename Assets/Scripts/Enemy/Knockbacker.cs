using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockbacker : MonoBehaviour
{
    //public float knockbackMultiplyer = 7f;
    public float delay = 0.3f;
    private Rigidbody2D rb;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Knockback(float knockbackMultiplier, GameObject sender)
    {
        if(rb != null){
            Vector2 direction = (transform.position - sender.gameObject.transform.position).normalized;
            rb.AddForce(direction * knockbackMultiplier, ForceMode2D.Impulse);
            rb.excludeLayers += LayerMask.GetMask("Enemy");
            StartCoroutine(Reset());
        }
    }

    private IEnumerator Reset(){
        yield return new WaitForSeconds(delay);
        rb.excludeLayers -= LayerMask.GetMask("Enemy");
        rb.velocity = Vector2.zero;
    }
}
