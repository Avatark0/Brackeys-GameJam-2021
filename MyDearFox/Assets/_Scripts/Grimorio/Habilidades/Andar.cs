using UnityEngine;
using UnityEngine.EventSystems;

namespace Grimorio
{
    [System.Serializable]
    [CreateAssetMenu(fileName="Andar",menuName="Grimorio/Andar",order=1)]
    public class Andar : HabilidadeSO
    {
        public Andar()
        {
            tipo=Tipo.Acao;
            custoAcao=1;
            movimento=1;
        }

        public override void Efeito(Criatura criatura)
        {
            if(criatura.Acao(custoAcao))
            {
                Vector3 pos=criatura.transform.position;
                float incrementoX=2.59807f;
                float incrementoZ=4.5f;

                switch (EventSystem.current.currentSelectedGameObject.name){
                    case "Button_CimaDireita":
                        pos.x+=-incrementoX;
                        pos.z+=-incrementoZ;
                        break;
                    case "Button_CimaEsquerda":
                        pos.x+=incrementoX;
                        pos.z+=-incrementoZ;
                        break;
                    case "Button_BaixoDireita":
                        pos.x+=-incrementoX;
                        pos.z+=incrementoZ;
                        break;
                    case "Button_BaixoEsquerda":
                        pos.x+=incrementoX;
                        pos.z+=incrementoZ;
                        break;
                    case "Button_Direita":
                        pos.x+=-2*incrementoX;
                        break;
                    case "Button_Esquerda":
                        pos.x+=2*incrementoX;
                        break;
                }
                criatura.transform.position=pos;
            }
        }

        public override void EfeitoCriaturaSelecionada(Criatura criaturaSelecionada){}
    }
}
