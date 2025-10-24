using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour {

    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;

    private void Start() {

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (!target)
        {
            GetTarget();
        } else {

            RotateTowardsTarget(); 
        }

    }
    private void RotateTowardsTarget() { 
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void FixedUpdate(){
        rb.velocity = transform.up * speed;

    }

    private void GetTarget(){
        if (GameObject.FindGameObjectWithTag("Player")){
        
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player")){
           Destroy(other.gameObject);
            target = null;
            SceneManager.LoadScene("DeathScreen");
        } else if (other.gameObject.CompareTag("tag")){
           Destroy(other.gameObject);
            Destroy(gameObject);

        }

    }*/

private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        // Get the PlayerHealth script and apply damage
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage();
        }
    }
   else if (collision.gameObject.CompareTag("bullet"))
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}

}