using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Assertions.Must;

public class RoomTrigger : MonoBehaviour
{
    [HideInInspector]public bool hasEntered = false;
    [SerializeField]private AudioSource audioSource;
    [SerializeField]private AudioClip closeDoorsSFX;
    [SerializeField]private AudioClip openDoorsSFX;
    private List<GameObject> enemiesInRoom = new();
    [SerializeField]private List<GameObject> doorsInRoom = new();
    [SerializeField]private Color roomFightingBackgroundColor;
    [SerializeField]private float colorChangeTransitionDuration;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            enemiesInRoom.Add(other.gameObject);
        }
        if(other.gameObject.CompareTag("Player") && !hasEntered){
            hasEntered = true;
            StartCoroutine(ChangeDoorState(true));
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            enemiesInRoom.Remove(other.gameObject);
            CheckEnemiesAlive();
        }else if(other.gameObject.CompareTag("Player")){
            hasEntered = false;
            StopAllCoroutines();
        }
    }

    private void CheckEnemiesAlive(){
        if(enemiesInRoom.Count == 0){
            StartCoroutine(ChangeDoorState(false));
        }else{
            return;
        }
    }
    private void OpenDoors(){
        foreach(GameObject door in doorsInRoom){
            door.GetComponent<Door>().Open();
        }
    }
    private void CloseDoors(){
        foreach(GameObject door in doorsInRoom){
            door.GetComponent<Door>().Close();
        }
    }

    private IEnumerator ChangeDoorState(bool estate){
        
        yield return new WaitForSeconds(.75f);
        if(estate){

            audioSource.clip = closeDoorsSFX;
            audioSource.Play();

            CloseDoors();

            BackgroundEffectManager.Instance.ChangeColor(roomFightingBackgroundColor, colorChangeTransitionDuration);
        }else{

            audioSource.clip = openDoorsSFX;
            audioSource.Play();

            OpenDoors();

            BackgroundEffectManager.Instance.ResetColor(colorChangeTransitionDuration);
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + new Vector3(GetComponent<BoxCollider2D>().offset.x, 
        GetComponent<BoxCollider2D>().offset.y, 0), GetComponent<BoxCollider2D>().size);
    }
}
