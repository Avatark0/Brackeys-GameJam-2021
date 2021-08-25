using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public void Atacar(){
        Debug.Log("Player Atacou!");
    }
}

/*
    void Awake(){
        menuDeCombate=GameObject.Find("MenuDeCombate");
        menuDeCombate.SetActive(false);

        CanalDeCombate.iniciarCombate+=Combate;
    }

    void OnDisable(){
        CanalDeCombate.iniciarCombate-=Combate;
    }

    private void Combate(){
        menuDeCombate.SetActive(true);
    }
    */
