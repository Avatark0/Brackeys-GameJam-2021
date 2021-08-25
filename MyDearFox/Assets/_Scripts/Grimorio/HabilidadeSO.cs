using UnityEngine;

namespace Grimorio
{
    public abstract class HabilidadeSO : ScriptableObject
    {
        [SerializeField] public bool obtida;
        [SerializeField] public int nivel;

        [SerializeField] public Tipo tipo;

        public int custoAcao;
        public int movimento;

        public Criatura criatura;

        public abstract void Efeito(Criatura criaturaAtiva);

        public abstract void EfeitoCriaturaSelecionada(Criatura criaturaSelecionada);

        public enum Tipo
        {
            Passivo,
            Acao,
            Magia, 
        }
    }
}