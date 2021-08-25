using UnityEngine;

public class CanalDeCombate : ScriptableObject
{
    public delegate void CanalDeIniciarCombate();

    public static event CanalDeIniciarCombate iniciarCombate;

    public static void EventoDeIniciarCombate(){
        if(iniciarCombate!=null){
            iniciarCombate();
        }
        else{
            Debug.Log("CanalDeCombate: evento de combate nao teve subscribers");
        }
    }
}
