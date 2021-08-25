using UnityEngine;

//[CreateAssetMenu(fileName="Deck", menuName="Deck",order=1)]
public class Deck : ScriptableObject
{
    [SerializeField] private int[] cores;
    [SerializeField] private FichaCriatura[] Criaturas;
}
