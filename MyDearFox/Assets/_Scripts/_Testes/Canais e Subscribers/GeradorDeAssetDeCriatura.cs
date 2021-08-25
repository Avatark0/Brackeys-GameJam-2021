using UnityEngine;

public class GeradorDeAssetDeCriatura : MonoBehaviour
{   
    void Awake()
    {   
       CanalDeInstanciamento.instanciarCriatura+=CriarAssetDeCriatura;
    }

    private void OnDisable()
    {
        CanalDeInstanciamento.instanciarCriatura-=CriarAssetDeCriatura;
    }

    public void CriarAssetDeCriatura(FichaCriatura criatura, Vector3 coordenadas)
    {
        
    }
}
