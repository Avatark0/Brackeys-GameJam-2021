using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    /*
mass: 2
speed: 6
maxFallSpeed: 5
jumpSpeed: 1000
jumpBuffer: 0.2
jumpHoldTime: 0.3
hoverSpeed: 1
hoverBufferTime: 5
*/

    [SerializeField] private float mass = default;//2f
    [SerializeField] private float speed = default;
    [SerializeField] private float jumpSpeed = default;
    [SerializeField] private float jumpBufferTime = default;
    
    [SerializeField] private Rigidbody2D rigbd = default;

    protected Collider2D otherCollider;
    protected bool grounded;
    protected float time;
    
    private void Start(){
        ResetValues();
    }

    public void Update()
    {
        Vector3 pos = transform.position;
            
        if(Input.GetKey(KeyCode.A)){
            pos.x-=speed*Time.deltaTime;
            //Debug.Log("left");
        }
        
        if(Input.GetKey(KeyCode.D)){
            pos.x+=speed*Time.deltaTime;
            //Debug.Log("right");
        }

        if(Input.GetKey(KeyCode.Space)){
            Jump();
        }
        else{
            rigbd.gravityScale=1;
            //Debug.Log("released jump at "+time);
        }

        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Chao"){
            grounded=true;
            //Debug.Log(gameObject.name+": landed");
        }
    }

    private void Jump(){
        if(grounded){
            rigbd.velocity = Vector2.zero;
            rigbd.AddForce(new Vector2(0,jumpSpeed));
            grounded=false;
            time = Time.time;
            //Debug.Log("jumped");
        }
        else if(time+jumpBufferTime >= Time.time){
            rigbd.gravityScale=0;
            //Debug.Log("buffering jump, gravityScale = "+rigbd.gravityScale);
        }
        else{
            rigbd.gravityScale=1;
            //Debug.Log("released jump");
        }
    }

    private void ResetValues(){
        grounded=true;
        rigbd.mass=mass;
    }
}
