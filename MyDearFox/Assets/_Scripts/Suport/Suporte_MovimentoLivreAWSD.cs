using UnityEngine;

public class Suporte_MovimentoLivreAWSD : MonoBehaviour
{
    [SerializeField, Range(0,10)] private float speed=5;

    void Update(){
         if(Input.GetKey(KeyCode.D))
            transform.Translate(new Vector3(-speed*Time.deltaTime,0,0));
        if(Input.GetKey(KeyCode.A))
            transform.Translate(new Vector3(speed*Time.deltaTime,0,0));
        if(Input.GetKey(KeyCode.W))
            transform.Translate(new Vector3(0,0,-speed*Time.deltaTime*1.15f));
        if(Input.GetKey(KeyCode.S))
            transform.Translate(new Vector3(0,0,speed*Time.deltaTime*1.15f));   
        
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("MovimentoLivreAWSD: SPACE apertado");
        }      
    }
}
