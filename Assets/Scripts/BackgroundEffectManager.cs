using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundEffectManager : MonoBehaviour
{
    private static BackgroundEffectManager _instance;
    public static BackgroundEffectManager Instance { get { return _instance; }}
    public Material backgroundEffectMaterial;
    public Color menuColor;
    [SerializeField]private Color gameColor;
    
    private void Awake() {
        if(_instance != null && _instance != this){
            Destroy(this.gameObject);
        }else{
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
            backgroundEffectMaterial.color = menuColor;
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
            backgroundEffectMaterial.color = gameColor;
    }
    private void Start() {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }
    void OnSceneChanged(Scene current, Scene next){
        if(next == SceneManager.GetSceneByBuildIndex(0))
            backgroundEffectMaterial.color = menuColor;
        if(next == SceneManager.GetSceneByBuildIndex(1))
            backgroundEffectMaterial.color = gameColor;
    }

    public void ChangeColor(Color color){
        backgroundEffectMaterial.color = color;
    }
    public void ChangeColor(Color color, float transitionDuration){
        StopAllCoroutines();
        StartCoroutine(ChangeColorInterpolate(color, transitionDuration));
    }
    public IEnumerator ChangeColorInterpolate(Color color, float transitionDuration){
        float timeElapsed = 0f;
        while(timeElapsed < transitionDuration){
            backgroundEffectMaterial.color = Color.Lerp(backgroundEffectMaterial.color, color, timeElapsed / transitionDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        backgroundEffectMaterial.color = color;
    }
    public void ResetColor(){
        backgroundEffectMaterial.color = gameColor;
    }
    public void ResetColor(float transitionDuration){
        StopAllCoroutines();
        StartCoroutine(ChangeColorInterpolate(gameColor, transitionDuration));
    }
}
