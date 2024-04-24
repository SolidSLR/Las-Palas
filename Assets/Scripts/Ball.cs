using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    public int randomStartDirection;
    public int ballDirection;
    public Rigidbody2D rb;
    Vector3 actualPosition;
    // Start is called before the first frame update
    void Start()
    {
        actualPosition = this.transform.position;
        randomStartDirection = Random.Range(0,1); 
        //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.down * ballSpeed);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
       /* actualPosition += Vector3.down * ballSpeed * Time.deltaTime;
        if(randomStartDirection == 0){
            actualPosition += Vector3.left *ballSpeed * Time.deltaTime;
        }
        if(randomStartDirection == 1){
            actualPosition += Vector3.right * ballSpeed * Time.deltaTime;
        }
        this.transform.position = actualPosition;*/
        if(ballDirection == 1){
            rb.AddForce(Vector3.right * ballSpeed, ForceMode2D.Impulse);
            ballDirection = 0;
        }else if(ballDirection == 2){
            rb.AddForce(Vector3.left * ballSpeed, ForceMode2D.Impulse);
            ballDirection = 0;
        }/*else if(ballDirection == 3){
            rb.AddForce(Vector3.up * ballSpeed, ForceMode2D.Impulse);
            ballDirection = 0;
        }*/
        //Debug.Log("Valor que debería aplicarse a la posición actual de la bola: "+actualPosition.x);
    }
    
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
   void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall"){
           // ballSpeed = -ballSpeed;
            Debug.Log("La bola ha chocado con una pared");
        }

        if(other.gameObject.tag =="Player"){
           // ballSpeed = -ballSpeed;
            ballDirection = BallBounce(transform.position, other.transform.position);
            Debug.Log("La bola ha chocado con la pala. Valor de ballDirection: "+ballDirection);
        }

        if(other.gameObject.tag =="Ceiling"){
           // ballSpeed = -ballSpeed;
            Debug.Log("La bola ha chocado con el techo");
        }
    }
    public int BallBounce(Vector3 ballPos, Vector3 bracketPos){
        if(ballPos.x > bracketPos.x){
            Debug.Log("Me voy hacia la derecha");
            return 1;
        }else if(ballPos.x < bracketPos.x){
            Debug.Log("Me voy hacia la izquierda");
            return 2;
        }else {
            Debug.Log("Me voy para el medio");
            return 3;
        }
    }
}
