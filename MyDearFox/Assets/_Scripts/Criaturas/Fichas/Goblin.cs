using System.Collections.Generic;
using UnityEngine;
using Grimorio;

public class Goblin : Criatura
{
    void Awake(){
        criaturaSO=Resources.Load("CriaturasSO/Goblin") as FichaCriatura;
        grimorio=GrimorioSO.CreateInstance<GrimorioSO>();
        
        GameObject ListaDeHabilidadesObj = GameObject.Find("ListaDeHabilidades");
        List<HabilidadeSO> listaDeHabilidades=ListaDeHabilidadesObj.GetComponent<ListaDeHabilidades>().habilidades;
        
        foreach(HabilidadeSO habilidade in listaDeHabilidades)
        {
            HabilidadeSO newUniqueSO = (HabilidadeSO)UnityEngine.Object.Instantiate(habilidade) as HabilidadeSO;
            newUniqueSO.name=habilidade.name;
            grimorio.habilidades.Add(newUniqueSO);
        }
    }
}
