using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public int TriggerNumber;
    [HideInInspector] public bool PodeSpawnar1 = false;
    [HideInInspector] public bool PodeSpawnar2 = false;
    [HideInInspector] public bool PodeSpawnar3 = false;
    [HideInInspector] public bool BarraBoss = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(TriggerNumber == 1)
        {
            print("o 1 foi");
            PodeSpawnar1 = true;
        }
        if (TriggerNumber == 2)
        {
            print("o 2 foi");
            PodeSpawnar2 = true;
        }
        if (TriggerNumber == 3)
        {
            print("o 3 foi");
            PodeSpawnar3 = true;
        }
        if(TriggerNumber == 4)
        {
           
            BarraBoss = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
    }
}
