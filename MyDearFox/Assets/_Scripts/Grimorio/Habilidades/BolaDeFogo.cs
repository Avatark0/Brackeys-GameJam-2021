using UnityEngine;

namespace Grimorio
{
    [System.Serializable]
    [CreateAssetMenu(fileName="BolaDeFogo",menuName="Grimorio/BolaDeFogo",order=3)]
    public class BolaDeFogo : HabilidadeSO
    {
        public BolaDeFogo()
        {
            tipo=Tipo.Magia;
            custoAcao=3;
        }

        public override void Efeito(Criatura criatura){}

        public override void EfeitoCriaturaSelecionada(Criatura criaturaSelecionada){}
    }
}