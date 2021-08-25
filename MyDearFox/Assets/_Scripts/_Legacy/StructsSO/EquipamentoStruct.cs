using UnityEngine;

public class EquipamentoStruct : ScriptableObject
{
   [System.Serializable] 
    public struct Equipamento
    {
        [SerializeField] private Itens pocaoCura;
        [SerializeField] private Itens espada;
        [SerializeField] private Itens arco;
        [SerializeField] private Itens cajado;
        [SerializeField] private Itens pergaminho;
    }

    [System.Serializable]
    private struct Itens
    {
        [SerializeField] private bool itemObtido;
        [SerializeField] private int quantidade;
        [SerializeField] private ItemStruct.Item item;
    }
}
