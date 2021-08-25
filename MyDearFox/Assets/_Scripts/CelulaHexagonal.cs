using UnityEngine;

public class CelulaHexagonal : MonoBehaviour
{
    private float neighboorDetectionRadius=4f;
    [Header("Display the radius of cell detection")]  
    [SerializeField] private bool drawGizmo=default;

    [Header("Has the cell been activated by a character")]
    [SerializeField] private bool foiAtivado = false;

    [Header("The board grid positioning values")]
    [SerializeField] private float gridX=2.59807f;
    [SerializeField] private float gridZ=4.5f;

    [Header("The cell prefab for instantiating the board")]
    [SerializeField] private GameObject celula=default;

    private void OnCollisionEnter(Collision other) {
        if(!foiAtivado){
            if(other.gameObject.transform.GetComponentInChildren<Jogador>()!=null)
            {
                foiAtivado=true;
                GetComponent<MeshRenderer>().material=Resources.Load("Materials/Verde-Neon") as Material;
            }
        }
    }

    public void PropagarCelula(float limiteTabuleiro){
        GameObject[] celulasVizinhas=DetectarCelulasVizinhas();
        GameObject[] vizinhasNovas=InstanciarNovasVizinhas(celulasVizinhas);

        foreach(var vizinha in vizinhasNovas){
            Vector3 posicao=transform.TransformVector(vizinha.transform.position);
            if(DentroDoTabuleiro(posicao, limiteTabuleiro)){
                vizinha.GetComponent<CelulaHexagonal>().PropagarCelula(limiteTabuleiro);
            }
        }
    }

    private GameObject[] DetectarCelulasVizinhas()
    {
        Collider[] collidersVizinhos=Physics.OverlapSphere(transform.position, neighboorDetectionRadius);
        int indexCont=0;
        foreach (var collider in collidersVizinhos)
            if(collider.GetComponent<CelulaHexagonal>()!=null)
                if(collider.gameObject.transform.position!=transform.position)
                    indexCont++;
        GameObject[] vizinhas=new GameObject[indexCont];
        indexCont=0;
        foreach (var collider in collidersVizinhos){
            if(collider.GetComponent<CelulaHexagonal>()!=null){
                if(collider.gameObject.transform.position!=transform.position){
                    vizinhas[indexCont]=collider.gameObject;
                    indexCont++;
                }
            }
        }
        return vizinhas;
    }

    private GameObject[] InstanciarNovasVizinhas(GameObject[] vizinhasOcupadas)
    {
        int totalPosicoes=6;
        int posicoesLivres=totalPosicoes-vizinhasOcupadas.Length;
        int index=0;
        GameObject[] vizinhasNovas=new GameObject[posicoesLivres];
        foreach(var posicao in PosicoesVizinhas()){
            int checagemPosicaoOcupada=vizinhasOcupadas.Length;
            for(int i=0;i<vizinhasOcupadas.Length;i++){
                if((posicao-vizinhasOcupadas[i].transform.position).magnitude>0.1)
                    checagemPosicaoOcupada--;
            }
            if(checagemPosicaoOcupada==0){
                vizinhasNovas[index]=Instantiate(celula,posicao,Quaternion.identity,transform.parent);
                vizinhasNovas[index].name="Cell";
                index++;
            }
        }
        return vizinhasNovas;
    }

    private Vector3[] PosicoesVizinhas(){
        Vector3[] posicoes=new Vector3[6];
        posicoes[0]=new Vector3(transform.position.x+gridX,transform.position.y,transform.position.z+gridZ);
        posicoes[1]=new Vector3(transform.position.x+2*gridX,transform.position.y,transform.position.z);
        posicoes[2]=new Vector3(transform.position.x+gridX,transform.position.y,transform.position.z-gridZ);
        posicoes[3]=new Vector3(transform.position.x-gridX,transform.position.y,transform.position.z-gridZ);
        posicoes[4]=new Vector3(transform.position.x-2*gridX,transform.position.y,transform.position.z);
        posicoes[5]=new Vector3(transform.position.x-gridX,transform.position.y,transform.position.z+gridZ);
        return posicoes;
    }

    private bool DentroDoTabuleiro(Vector3 _posicao, float limiteTabuleiro){
        float limiteEsquerda=limiteTabuleiro;
        float limiteDireita=-limiteTabuleiro;
        float limiteCima=limiteTabuleiro;
        float limiteBaixo=-limiteTabuleiro;
        bool esquerda=false;
        bool direita=false;
        bool cima=false;
        bool baixo=false;
        if(_posicao.x<=limiteEsquerda) esquerda=true;
        if(_posicao.x>=limiteDireita) direita=true;
        if(_posicao.z<=limiteCima) cima=true;
        if(_posicao.z>=limiteBaixo) baixo=true;

        if(esquerda && direita && cima && baixo)
            return true;
        else
            return false;
    }

    //Display the radius of the DetectarCelulasVizinhas method when selected
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        if(drawGizmo)
            Gizmos.DrawSphere(transform.position, neighboorDetectionRadius);
    }
}
