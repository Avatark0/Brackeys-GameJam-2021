using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogador : Controle
{
    [SerializeField] private float speed = default;
    public bool hasIncarned;
    
    private void Start()
    {
        isPlayer=true;
    }

    public void Update()
    {
        Vector3 pos = transform.position;

        if(isPlayer){
            if(Input.GetKeyDown(KeyCode.W)){
                if(otherCollider != null){
                    transform.parent=otherCollider.gameObject.transform;

                    otherCollider.gameObject.GetComponent<Controle>().isPlayer=true;
                    isPlayer=false;
                    
                    otherCollider.attachedRigidbody.isKinematic=false;
                    otherCollider.isTrigger=false;
                    
                    // gameObject.GetComponent<Collider2D>().isTrigger=true;
                    // gameObject.GetComponent<Collider2D>().attachedRigidbody.isKinematic=true;
                    gameObject.GetComponent<Collider2D>().attachedRigidbody.simulated=false;
                }
            }

            if(Input.GetKey(KeyCode.A)){
                pos.x-=speed*Time.deltaTime;
                Debug.Log("left");
            }
            
            if(Input.GetKey(KeyCode.D)){
                pos.x+=speed*Time.deltaTime;
                Debug.Log("right");
            }
        }
        else{
            if(Input.GetKeyDown(KeyCode.S)){
                if(transform.parent.gameObject.GetComponent<Controle>() != null){
                    transform.parent.gameObject.GetComponent<Controle>().isPlayer=false;
                    isPlayer=true;
                    
                    transform.parent.GetComponent<Rigidbody2D>().isKinematic=true;
                    transform.parent.GetComponent<Collider2D>().isTrigger=true;
                    
                    // gameObject.GetComponent<Collider2D>().isTrigger=false;
                    // gameObject.GetComponent<Collider2D>().attachedRigidbody.isKinematic=false;
                    gameObject.GetComponent<Collider2D>().attachedRigidbody.simulated=true;

                    transform.parent=transform.parent.parent;
                    
                    Debug.Log(gameObject.GetComponent<Collider2D>().attachedRigidbody.gameObject);
                }
            }
        }
        
        transform.position = pos;
    }

    protected override void ResetValues(){
        grounded=true;
    }
}
