using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName="Nova Criatura",menuName="Criaturas/Nova Criatura",order=0)]
public class FichaCriatura : ScriptableObject
{
    [SerializeField] public string nome;
    [SerializeField] public int nivelBase;
    [SerializeField] public int experiencia;
    [SerializeField] public int tamanho;

    [SerializeField] public Atributos atributos;

    [System.Serializable] 
    public struct Atributos{
        [SerializeField, Range(0,10)] public int forca;
        [SerializeField, Range(0,10)] public int destreza;
        [SerializeField, Range(0,10)] public int constituicao;
        [SerializeField, Range(0,10)] public int inteligencia;
        [SerializeField, Range(0,10)] public int sabedoria;
        [SerializeField, Range(0,10)] public int carisma;
    }
}
