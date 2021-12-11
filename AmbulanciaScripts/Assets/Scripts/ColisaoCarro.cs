using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoCarro : MonoBehaviour
{
    public GameObject seta;
    public GameObject caixaDialogo1;
    public Transform target2;
    public ScriptSeta scriptSeta;
    public Renderer render;
    public Material material;
    public ScriptCarro carroScript;
    public bool primeiroGatilho = false;

    void OnTriggerEnter(Collider collider){
        StartCoroutine(colidiuComGatilho());
    }
    IEnumerator colidiuComGatilho(){
        primeiroGatilho = true;
        seta.SetActive(false);
        caixaDialogo1.SetActive(true);
        carroScript.enabled = false;
        yield return new WaitForSeconds(0.5f);
    }
    public void clicouNoBotao(){
        render.material = material;
        caixaDialogo1.SetActive(false);
        scriptSeta.target = target2;
        seta.SetActive(true);
        carroScript.enabled = true;
    }
}
