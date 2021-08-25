using UnityEngine;

public class Tabuleiro : MonoBehaviour
{
    [Header("Cell prefab")]
    [SerializeField] private GameObject celula=default;

    [Header("Number of starting cells")]
    [SerializeField] private int numNucleos;

    [Header("Board size")]//Limit is 242 (before overflow from recurrence)
    [SerializeField, Range(0,242)] private float limiteTabuleiro=default;

    private GameObject[] nucleos;
    private Vector3 posicao;

    private void Start()
    {
        numNucleos=1;
        nucleos=IniciarNucleos(numNucleos);
        PropagarNucleos(nucleos);
    }

    private GameObject[] IniciarNucleos(int _numNucleos){
        GameObject[] _nucleos=new GameObject[_numNucleos];
        for(int i=0; i<_numNucleos; i++){
            posicao=Vector3.zero;//posicionar nucleo no tabuleiro, encontrar a posicao adequada. Por enquanto usa 0 com default do único nucleo.
            _nucleos[i]=Instantiate(celula, posicao, Quaternion.identity,transform);
        }
        return _nucleos;
    }

    private void PropagarNucleos(GameObject[] _nucleos){
        foreach(var nucleo in _nucleos){
            nucleo.GetComponent<CelulaHexagonal>().PropagarCelula(limiteTabuleiro);
        }
    }
}
