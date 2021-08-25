using System.Collections;
using UnityEngine;

namespace Grimorio
{
    [System.Serializable]
    [CreateAssetMenu(fileName="Possuir",menuName="Grimorio/Possuir",order=-1)]
    public class Possuir : HabilidadeSO
    {
        public Possuir()
        {
            tipo=Tipo.Magia;
            custoAcao=1;
        }

        public override void Efeito(Criatura criaturaDoJogador)
        {
            criatura=criaturaDoJogador;

            if(custoAcao<=criaturaDoJogador.AcoesRestantes())
            {
                SelecaoPorClique clique = GameObject.FindWithTag("SelecaoPorClique").GetComponent<SelecaoPorClique>();

                clique.habilidadeEmUso(this);
                clique.AtivarSelecionarCriatura();
            }
        }

        public override void EfeitoCriaturaSelecionada(Criatura criaturaSelecionada)
        {
            Criatura criaturaDoJogador = criatura;
            if(criaturaDoJogador.Acao(custoAcao))
            {
                GameObject jogador = criaturaDoJogador.GetComponentInChildren<Jogador>().gameObject;
                jogador.transform.parent = criaturaSelecionada.gameObject.transform;

                criaturaDoJogador.AlternarIA();
                criaturaSelecionada.AlternarIA();

                int drenarAcoesRestantes = criaturaDoJogador.AcoesRestantes();
                criaturaDoJogador.Acao(drenarAcoesRestantes);
                
                SelecaoPorClique clique = GameObject.FindWithTag("SelecaoPorClique").GetComponent<SelecaoPorClique>();
                clique.DesativarSelecionarCriatura();

                GameObject.Find("ScrollHabilidades").GetComponent<InterfaceDeUsuario.ScrollHabilidades>().InstanciarScrollDeHabilidades();
                GameObject.Find("Movimento").GetComponent<InterfaceDeUsuario.BotaoMovimento>().DefinirCriaturaDoJogador();
                GameObject.Find("Jogador").GetComponent<Jogador>().ResetarPosicaoRelativa();
            }
        }
    }
}
