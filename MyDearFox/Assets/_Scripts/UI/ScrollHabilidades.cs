using UnityEngine;
using UnityEngine.UI;
using Grimorio;

namespace InterfaceDeUsuario
{
    public class ScrollHabilidades : MonoBehaviour
    {
        public Criatura criaturaDoJogador;

        [SerializeField] private GameObject jogador=default;
        [SerializeField] private GameObject conteudoScroll=default;
        [SerializeField] private GameObject buttonHabilidade=default;
        [SerializeField] private GameObject[] scrollHabilidades;
        [SerializeField] private float tamanhoInicial = 0f;

        private void Start()
        {
            InstanciarScrollDeHabilidades();
        }

        public void InstanciarScrollDeHabilidades()
        {
            DefinirCriaturaDoJogador();

            ResetarConteudo();

            ResetarTamanho();

            int indexTotal = criaturaDoJogador.grimorio.habilidades.Count;
            int index = 0;
            scrollHabilidades = new GameObject[indexTotal];

            foreach(HabilidadeSO habilidade in criaturaDoJogador.grimorio.habilidades)
            {
                if(!habilidade.obtida)
                {
                    if(habilidade.tipo != HabilidadeSO.Tipo.Passivo)
                    {
                        GameObject botao = InstanciarBotao(habilidade);

                        ReposicionarConteudo(botao);

                        scrollHabilidades[index]=botao;
                        index++;
                    }
                }
            }
        }

        private void DefinirCriaturaDoJogador()
        {
            criaturaDoJogador=jogador.GetComponentInParent<Criatura>();
        }

        private void ResetarConteudo()
        {
            foreach(GameObject botao in scrollHabilidades)
            {
                Destroy(botao);
            }

            scrollHabilidades=null;
        }

        private void ResetarTamanho()
        {
            Vector2 size = conteudoScroll.GetComponent<RectTransform>().sizeDelta;
            size.y = tamanhoInicial;
            conteudoScroll.GetComponent<RectTransform>().sizeDelta = size;
        }

        private GameObject InstanciarBotao(HabilidadeSO habilidade)
        {
            GameObject botao = Instantiate(buttonHabilidade, conteudoScroll.transform);

            botao.GetComponentInChildren<Text>().text = habilidade.name;

            botao.GetComponent<Button>().onClick.AddListener(delegate {habilidade.Efeito(criaturaDoJogador); });

            return botao;
        }

        private void ReposicionarConteudo(GameObject botao)
        {
            Vector2 size = conteudoScroll.GetComponent<RectTransform>().sizeDelta;
            size.y += botao.GetComponent<RectTransform>().sizeDelta.y;
            conteudoScroll.GetComponent<RectTransform>().sizeDelta = size;

            Vector3 pos = conteudoScroll.GetComponent<RectTransform>().position;
            pos.y += botao.GetComponent<RectTransform>().sizeDelta.y;
            conteudoScroll.GetComponent<RectTransform>().position = pos;
        }
    }
}