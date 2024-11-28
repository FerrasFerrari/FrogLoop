using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    private static HitStop _instance;
    public static HitStop Instance { get {return _instance; }}
    public bool WAITING{get; private set;} = false ;

    private void Awake() {
        if(_instance != null && _instance != this){
            Destroy(this.gameObject);
        }else{
            _instance = this;
        }
        //DontDestroyOnLoad(this.gameObject);
    }
    public void Stop(float duration){
        if(WAITING){return;}
        Time.timeScale = 0.0f;
        StartCoroutine(Wait(duration));
    }
    public void Stop(float duration, float value){
        if(WAITING){return;}
        Time.timeScale = value;
        StartCoroutine(Wait(duration));
    }
    IEnumerator Wait(float duration){
        WAITING = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        WAITING = false;
    }
}
