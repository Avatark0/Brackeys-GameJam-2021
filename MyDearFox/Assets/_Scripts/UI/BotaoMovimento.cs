using UnityEngine;

namespace InterfaceDeUsuario
{
    public class BotaoMovimento : MonoBehaviour
    {
        public Criatura criaturaDoJogador;

        private void Awake()
        {
            DefinirCriaturaDoJogador();
        }

        public void Andar()
        {
            criaturaDoJogador.grimorio.habilidades.Find(x => x.name == "Andar").Efeito(criaturaDoJogador);
        }

        public void DefinirCriaturaDoJogador()
        {
            criaturaDoJogador=gameObject.GetComponentInParent<Criatura>();
        }

        /*
        public string TipoDeMovimento(int tipo)
        {
            switch(tipo){
                case 0: return "bipede";
                case 1: return "quadrupede";
                case 2: return "voar";
                case 3: return "nadar";
                case 4: return "deslizar";
                default: return "imovel";
            }
        }*/
    }
}
