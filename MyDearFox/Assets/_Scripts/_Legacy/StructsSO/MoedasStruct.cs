using UnityEngine;

public abstract class MoedasStruct : ScriptableObject
{
    [System.Serializable] 
    public struct Moedas{
        [SerializeField] public int ouro;
        [SerializeField] public int prata;
        [SerializeField] public int cobre;
    }
}
