using UnityEngine;

public class CanalDeInstanciamento : ScriptableObject
{
    //public delegate void Canal(ScriptableObject meuSO);
    public delegate void CanalDeInstanciarCriatura(FichaCriatura criatura, Vector3 coordenadas);

    public static event CanalDeInstanciarCriatura instanciarCriatura;

    public static void EventoDeInstanciarCriatura(FichaCriatura criatura, Vector3 coordenadas)
    {
        if(instanciarCriatura!=null)
        {
            instanciarCriatura(criatura, coordenadas);
        }
        else
        {
            Debug.Log("CanalDeInstanciamento: evento de instanciar criatura nao teve subscribers");
        }
    }
}

/*
//Função para seleção e instanciamento de criatura:
    FichaCriatura fichaCriatura = Resources.Load("CriaturasSO/Slime") as FichaCriatura;
    CanalDeInstanciamento.EventoDeInstanciarCriatura(fichaCriatura, transform.position);
*/
