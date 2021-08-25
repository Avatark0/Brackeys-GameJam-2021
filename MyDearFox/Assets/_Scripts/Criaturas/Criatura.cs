using UnityEngine;
using Grimorio;

public class Criatura : MonoBehaviour
{
    public FichaCriatura criaturaSO;
    [SerializeField] public GrimorioSO grimorio;

    public bool usarIA;

    private bool meuTurno;

    private int totalAcoes;
    private int acoesRestantes;

    [HideInInspector] public int nivel;

    public int iniciativa;
    public int vida;

    private void Start()
    {
        if(GetComponentInChildren<Jogador>()==null)
            usarIA=true;

        nivel=criaturaSO.nivelBase;
        
        totalAcoes=(int)Mathf.Ceil(1+nivel/4);
        acoesRestantes=totalAcoes;

        iniciativa=nivel+criaturaSO.atributos.destreza;

        vida=criaturaSO.atributos.constituicao*2*nivel;
    }

    public bool MeuTurno()
    {
        if(!meuTurno)
        {
            meuTurno=true;
            acoesRestantes=totalAcoes;
            return true;
        }
        else if(acoesRestantes>0)
        {
            Debug.Log(name+": meuTurno="+meuTurno);
            if(usarIA)
                IA();
            else
                GetComponentInChildren<Jogador>().ResetarPosicaoRelativa();
            
            return true;
        }
        else
        {
            meuTurno=false;
            return false;
        }
    }

    public bool Acao(int custo)
    {
        if(custo<=acoesRestantes){
            acoesRestantes-=custo;
            return true;
        }
        else return false;
    }

    public int AcoesRestantes()
    {
        return acoesRestantes;
    }

    private void IA()
    {
        grimorio.habilidades.Find(x => x.name == "Esperar").Efeito(this);
    }

    public void AlternarIA()
    {
        //usarIA = usarIA ? false : true;
        usarIA = !usarIA;
    }

    public Criatura CriaturaSelecionada()
    {
        return this;
    }
}
