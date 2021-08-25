using System.Collections.Generic;
using UnityEngine;

public class SpawnerCriaturas : MonoBehaviour
{
    public static GameObject[] criaturasSpawnadas;
    private static int indexCriatura=0;
    private static int limiteIndexCriatura=100;
    [SerializeField] private GameObject[] visualizadorDeCriaturasSpawnadas;

    void Awake(){
       criaturasSpawnadas=new GameObject[limiteIndexCriatura];
       visualizadorDeCriaturasSpawnadas=criaturasSpawnadas;

       CanalDeInstanciamento.instanciarCriatura+=SpawnCriatura;
    }

    private void OnDisable(){
        CanalDeInstanciamento.instanciarCriatura-=SpawnCriatura;
    }

    private void SpawnCriatura<T>(T fichaCriatura, Vector3 coordenadas) where T:FichaCriatura
    {
        coordenadas.y+=2;
        
        GameObject criatura = Resources.Load("Prefabs/"+fichaCriatura.nome) as GameObject;
        Instantiate(criatura,coordenadas,Quaternion.identity,transform);

        criaturasSpawnadas[indexCriatura] = criatura;
        visualizadorDeCriaturasSpawnadas=criaturasSpawnadas;

        indexCriatura++;
        Debug.Log("SpawnerCriaturas: Spawn "+fichaCriatura.nome+" with index = "+indexCriatura+", at "+coordenadas);
    }    
}
