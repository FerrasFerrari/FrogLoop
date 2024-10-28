using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class ScreenShaker : MonoBehaviour
{
    [SerializeField]private float screenShakeForce = 0.04f;
    private CinemachineImpulseSource impulseSource;
    private void Awake() {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    public void ShakeDirectional(Vector2 direction) {
        impulseSource.GenerateImpulse(-direction * screenShakeForce);
    }
}
