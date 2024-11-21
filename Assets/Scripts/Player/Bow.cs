using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public float ArrowForce = 20f;
    [SerializeField]
    private float arrowSpawnOffsetX = -0.3f;
    public UnlockBow UnlockBowScrpit;
    public GameObject ArrowPrefab;
    [SerializeField] private Transform ArrowPos;
    [SerializeField] private Transform ArrowRotationObject;
    private PlayerAttack Rotate;
    public AudioSource audioSource;
    public AudioClip arco;

    // Start is called before the first frame update
    void Start()
    {
        UnlockBowScrpit.Unlocked = false;
        Rotate = GetComponent<PlayerAttack>();
        
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
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    Rotate.RotateAttackPoint();
                    GameObject Arrow = Instantiate(ArrowPrefab, ArrowPos.position + new Vector3(arrowSpawnOffsetX,0,0), ArrowRotationObject.rotation);
                    Arrow.GetComponent<Rigidbody2D>().AddForce(Rotate.aimDirection.normalized * ArrowForce, ForceMode2D.Impulse);
                audioSource.clip = arco;
                audioSource.Play();
                }
            
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(ArrowPos.position + new Vector3(arrowSpawnOffsetX,0,0), 0.035f);
    }
}
