using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShaker : MonoBehaviour
{
    [SerializeField]private float screenShakeForce = 0.04f;
    private CinemachineImpulseSource impulseSource;
    private void Awake() {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    public void Shake(Vector2 direction) {
        impulseSource.GenerateImpulse(-direction * screenShakeForce);
    }
}
