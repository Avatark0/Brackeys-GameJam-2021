using System.Collections;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    [SerializeField] private GameObject jogador=default;

    private Vector3 posicaoRelativa;

    private void Start()
    {
        posicaoRelativa = transform.localPosition;
    }

    public void ResetarPosicaoRelativa()
    {
        transform.localPosition = posicaoRelativa;
    }

    public void ChangeParent(GameObject newParent)
    {
        jogador.transform.parent=newParent.transform;
    }
}
