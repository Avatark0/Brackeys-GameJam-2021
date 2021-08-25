using UnityEngine;

namespace Grimorio
{
    [System.Serializable]
    [CreateAssetMenu(fileName="Voar",menuName="Grimorio/Voar",order=2)]
    public class Voar : HabilidadeSO
    {
        public Voar()
        {
            tipo=Tipo.Acao;
            custoAcao=1;
            movimento=3;
        }

        public override void Efeito(Criatura criatura){}

        public override void EfeitoCriaturaSelecionada(Criatura criaturaSelecionada){}
    }
}
