using UnityEngine;

//[CreateAssetMenu(fileName = "Terreno", menuName = "Terreno", order = 0)]
public class Terreno : ScriptableObject
{
    [SerializeField] private int cor;
    [SerializeField] private int[] coresVizinhas;
    [SerializeField] private int nivel;
    [SerializeField] private int mobilidadeTerreno;
    [SerializeField] private int bonusVisaoTerreno;
}