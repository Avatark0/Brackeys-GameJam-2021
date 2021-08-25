using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoresStruct : ScriptableObject
{
    [System.Serializable] 
    public struct Cores{
        [SerializeField] public bool verde;
        [SerializeField] public bool azul;
        [SerializeField] public bool branco;
        [SerializeField] public bool vermelho;
        [SerializeField] public bool preto;
    }
}
