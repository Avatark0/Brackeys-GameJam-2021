using UnityEngine;

namespace Grimorio
{
    [System.Serializable]
    [CreateAssetMenu(fileName="Visao",menuName="Grimorio/Visao",order=4)]
    public class Visao : HabilidadeSO
    {
        public Visao()
        {
            tipo=Tipo.Passivo;
            custoAcao=0;
        }

        public override void Efeito(Criatura criatura){}

        public override void EfeitoCriaturaSelecionada(Criatura criaturaSelecionada){}
    }
}