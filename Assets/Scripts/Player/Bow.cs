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
    private bool shoot = false;
    private Mana manaScript;
    private PlayerAttack Rotate;
    private Animator anim;
    public AudioSource audioSource;
    public AudioClip arco;

    private void Awake() {
        manaScript = GetComponent<Mana>();
        Rotate = GetComponent<PlayerAttack>();
        UnlockBowScrpit.Unlocked = false;
    }
    private void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        BowInput();
    }
    void BowInput()
    {
        if (UnlockBowScrpit.Unlocked == true)
        {
                if (Input.GetKeyDown(KeyCode.Q) && manaScript.CanUseBow() && !shoot)
                {
                    shoot = true;        
                }
            
        }
    }
    private void LateUpdate() {
        if(shoot){
            Rotate.RotateAttackPoint2();
            anim.SetBool("Bow", true);
            GameObject Arrow = Instantiate(ArrowPrefab, ArrowPos.position + new Vector3(arrowSpawnOffsetX,0,0), ArrowRotationObject.rotation);
            Arrow.GetComponent<Rigidbody2D>().AddForce(Rotate.aimDirection.normalized * ArrowForce, ForceMode2D.Impulse);
            audioSource.clip = arco;
            audioSource.Play();
            shoot = false;
            anim.SetBool("Bow", false);
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(ArrowPos.position + new Vector3(arrowSpawnOffsetX,0,0), 0.035f);
    }
}
