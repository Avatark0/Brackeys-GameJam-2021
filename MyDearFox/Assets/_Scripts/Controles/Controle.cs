using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controle : MonoBehaviour
{
    public bool isPlayer;
    protected Collider2D otherCollider;
    protected bool grounded;
    protected float time;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Possuivel"){
            Debug.Log(gameObject.name+": enter trigger, other = "+other);
            otherCollider=other;
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Possuivel"){
            Debug.Log(gameObject.name+": exit trigger, other = "+other);
            otherCollider=null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Chao"){
            grounded=true;
            Debug.Log(gameObject.name+": landed");
        }
    }

    private void Start(){
        ResetValues();
    }

    protected abstract void ResetValues();

}
