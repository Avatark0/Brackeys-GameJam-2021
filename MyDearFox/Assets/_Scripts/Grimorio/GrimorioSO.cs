using System.Collections.Generic;
using UnityEngine;

namespace Grimorio 
{
    [System.Serializable]
    public class GrimorioSO : ScriptableObject
    {
        public List<HabilidadeSO> habilidades=new List<HabilidadeSO>();
    }
}

/*Antigo sistema de pericias, sera integrado às habilidades
//cada pericia deve ter uma acao ou conjunto de acoes que ela afeta
    [System.Serializable] 
    public struct Pericias{
        [SerializeField, Range(0,50)] public int nadar;
        [SerializeField, Range(0,50)] public int escalar;
        [SerializeField, Range(0,50)] public int falarIdioma;
        [SerializeField, Range(0,50)] public int cavalgar;
        [SerializeField, Range(0,50)] public int sensoDirecao;
        [SerializeField, Range(0,50)] public int observarMagia;//Aumenta chance de dropar pergaminho
    }
*/
