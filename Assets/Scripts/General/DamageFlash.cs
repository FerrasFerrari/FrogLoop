using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public Color flashColor;
    [SerializeField]private float flashTime = 0.25f;
    private SpriteRenderer spritesRenderer;
    private Material material;
    private Coroutine damageFlashCoroutine;

    private void Start() {
        spritesRenderer = GetComponent<SpriteRenderer>();
        material = spritesRenderer.material;
    }

    public void CallDamageFlasher(){
        damageFlashCoroutine = StartCoroutine(DamageFlasher());
    }

    private IEnumerator DamageFlasher(){

        material.SetColor("_FlashColor", flashColor);
        material.SetFloat("_FlashAmount", 1f);

        float currentFlashAmount = 0f;
        float timeElapsed = 0f;
        while(timeElapsed < flashTime){
            
            timeElapsed += Time.deltaTime;

            currentFlashAmount = Mathf.Lerp(1f, 0f, (timeElapsed / flashTime));
            material.SetFloat("_FlashAmount", currentFlashAmount);

            yield return null;
        }
        yield return new WaitForSeconds(flashTime);
    }

}
