using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [HideInInspector]public bool hasEntered = false;
    private List<GameObject> enemiesInRoom = new();
    [SerializeField]private List<GameObject> doorsInRoom = new();
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            enemiesInRoom.Add(other.gameObject);
        }
        if(other.gameObject.CompareTag("Player") && !hasEntered){
            hasEntered = true;
            CloseDoors();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            enemiesInRoom.Remove(other.gameObject);
            CheckEnemiesAlive();
        }
    }

    private void CheckEnemiesAlive(){
        if(enemiesInRoom.Count == 0){
            OpenDoors();
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
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
    }
}
