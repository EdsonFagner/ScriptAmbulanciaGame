using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisaoCarro2 : MonoBehaviour
{
    public GameObject seta;
    public GameObject caixaDialogo2;
    public ScriptCarro carroScript;
    public ColisaoCarro colisaoCarro;
    void OnTriggerEnter(Collider collider){
        if(colisaoCarro.primeiroGatilho == true){
            StartCoroutine(colidiuComGatilho2());
        }      
    }
    IEnumerator colidiuComGatilho2(){
        seta.SetActive(false);
        caixaDialogo2.SetActive(true);
        carroScript.enabled = false;
        yield return new WaitForSeconds(0.5f);
    }
    public void clicouProximo(){
        SceneManager.LoadScene(2);
    }
    public void clicouRepetir(){
        SceneManager.LoadScene(1);
    }
    public void clicouMenu(){
        SceneManager.LoadScene(0);
    }
}
