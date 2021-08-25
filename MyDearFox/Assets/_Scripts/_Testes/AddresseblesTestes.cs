using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.AddressableAssets;

public class AddresseblesTestes : ScriptableObject
{
    /*public List<Grimorio.HabilidadeSO> habilidades;

    [Header("Teste de Addressebles: grimorio")]
    [SerializeField] private AssetReference _grimorioAsset=default;
    */

    /*private GrimorioSO()
    {
        foreach(HabilidadeSO habilidade in Resources.LoadAll<HabilidadeSO>("Grimorio/"))
        {
            HabilidadeSO novaHabilidade=HabilidadeSO.CreateInstance(habilidade.name) as HabilidadeSO;
            Debug.Log(novaHabilidade);
            habilidades.Add(novaHabilidade);
        }
    }*/

    /*private void LoadEventChannel(AsyncOperationHandle<HabilidadeSO> _habilidade)
    {
        _grimorioAsset.LoadAssetAsync<HabilidadeSO>().Completed+=LoadGrimorioAsset;
    }

    private void LoadGrimorioAsset(AsyncOperationHandle<HabilidadeSO> _habilidade)
    {
        foreach(HabilidadeSO habilidade in _grimorioAsset)
        {
            habilidades.Add(habilidade);
        }
    }*/
}

