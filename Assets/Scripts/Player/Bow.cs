using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public UnlockBow UnlockBowScrpit;
    public GameObject ArrowPrefab;
    public Transform ArrowPos;
    public float ArrowForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        UnlockBowScrpit.Unlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShootBow();
    }
    void ShootBow()
    {
        if (UnlockBowScrpit.Unlocked == true)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                GameObject Arrow = Instantiate(ArrowPrefab, ArrowPos.position, ArrowPos.rotation);
                Arrow.GetComponent<Rigidbody2D>().AddForce(ArrowPos.position * ArrowForce, ForceMode2D.Impulse);
            }   
        }
    }
}
