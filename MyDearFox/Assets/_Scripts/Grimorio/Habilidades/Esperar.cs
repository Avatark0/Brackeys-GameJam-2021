using UnityEngine;

namespace Grimorio
{
    [System.Serializable]
    [CreateAssetMenu(fileName="Esperar",menuName="Grimorio/Esperar",order=0)]
    public class Esperar : HabilidadeSO
    {
        public Esperar()
        {
            tipo=Tipo.Acao;
            custoAcao=1;
            movimento=1;
        }
        
        public override void Efeito(Criatura estaCriatura)
        {
            estaCriatura.Acao(custoAcao);
        }

        public override void EfeitoCriaturaSelecionada(Criatura criaturaSelecionada){}
    }
}
