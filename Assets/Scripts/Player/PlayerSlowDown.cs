using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlowDown : MonoBehaviour
{
    private PlayerMovement playerMovementScript;
    private void Awake() {
        playerMovementScript = GetComponent<PlayerMovement>();
    }
    public IEnumerator MovementSlowDown(float duration, float amount){
        StopAllCoroutines();
        playerMovementScript.activeMoveSpeed *= amount;
        yield return new WaitForSeconds(duration);
        playerMovementScript.activeMoveSpeed = playerMovementScript.moveSpeed;
    }
}
