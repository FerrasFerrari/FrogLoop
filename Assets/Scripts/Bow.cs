using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public UnlockBow UnlockBowScrpit;
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
                print("Deu Certo");
            }
        }
    }
}
