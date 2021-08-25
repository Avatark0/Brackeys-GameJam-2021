using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcoesRestantes : MonoBehaviour
{
    [SerializeField] private Text texto=default;

    public void AtualizarTexto(int acoesRestantes)
    {
        texto.text=acoesRestantes.ToString();
    }

    private void Start()
    {
        AtualizarTexto(1);
    }
}
