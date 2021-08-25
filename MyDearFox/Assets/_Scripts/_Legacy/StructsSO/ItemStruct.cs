using UnityEngine;

public class ItemStruct : ScriptableObject
{
    [System.Serializable] 
    public struct Item{
        [SerializeField] public string name;
        [SerializeField] public string categoria;
        [SerializeField] public int preco;
    }
}
