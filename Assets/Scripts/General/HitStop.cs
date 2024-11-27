using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    private static HitStop _instance;
    public static HitStop Instance { get {return _instance; }}
    bool waiting = false;

    private void Awake() {
        if(_instance != null && _instance != this){
            Destroy(this.gameObject);
        }else{
            _instance = this;
        }
    }
    public void Stop(float duration){
        if(waiting){return;}
        Time.timeScale = 0.0f;
        StartCoroutine(Wait(duration));
    }
    IEnumerator Wait(float duration){
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        waiting = false;
    }
}
