using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Knockbacker : MonoBehaviour
{
    public float knockbackMultiplyer = 7f;
    public float delay = 0.3f;
    private Rigidbody2D rb;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Knockback(float aimAngle, GameObject sender)
    {
        // rb.AddForce(new Vector2(Mathf.Cos(aimAngle * Mathf.Deg2Rad) * knockbackMultiplyer, 
        // Mathf.Sin(aimAngle * Mathf.Deg2Rad) * knockbackMultiplyer), ForceMode2D.Impulse);
        if(rb != null){
            Vector2 direction = (transform.position - sender.gameObject.transform.position).normalized;
            rb.AddForce(direction * knockbackMultiplyer, ForceMode2D.Impulse);
            StartCoroutine(Reset());
        }
    }

    private IEnumerator Reset(){
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector2.zero;
    }
}
