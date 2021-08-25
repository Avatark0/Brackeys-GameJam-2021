using UnityEngine;

public class SelecaoPorClique : MonoBehaviour
{
    [SerializeField]
    private LayerMask ClickablesLayer;

    [SerializeField]
    private GameObject PainelDeSelecaoPorClique;

    private bool selecionarObjeto;
    private Grimorio.HabilidadeSO habilidade=default;

    private void Awake()
    {
        PainelDeSelecaoPorClique.SetActive(false);
    }

    private void Update()
    {
        if(selecionarObjeto)
        {
            if(!PainelDeSelecaoPorClique.activeSelf)
                PainelDeSelecaoPorClique.SetActive(true);

            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit rayHit;

                if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out rayHit, Mathf.Infinity, ClickablesLayer))
                {
                    Criatura criaturaSelecionada=rayHit.collider.GetComponent<Criatura>().CriaturaSelecionada();

                    habilidade.EfeitoCriaturaSelecionada(criaturaSelecionada);
                }
            }
            else if(Input.GetMouseButtonDown(1))
            {
                PainelDeSelecaoPorClique.SetActive(false);
                selecionarObjeto=false;
            }
        }
    }

    public void habilidadeEmUso(Grimorio.HabilidadeSO _habilidade)
    {
        habilidade=_habilidade;
    }

    public void AtivarSelecionarCriatura()
    {
        selecionarObjeto = true;
    }

    public void DesativarSelecionarCriatura()
    {
        selecionarObjeto = false;
        PainelDeSelecaoPorClique.SetActive(false);
    }
}
