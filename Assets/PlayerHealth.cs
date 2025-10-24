using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;                  // Starting lives
    public float respawnDelay = 1f;        // Delay before respawn or death screen
    private Vector3 respawnPoint;          // Where player respawns

    private void Start()
    {
        // Set the respawn point to wherever the player starts
        respawnPoint = transform.position;
    }

    public void TakeDamage()
    {
        lives--;

        if (lives > 0)
        {
            // Respawn player at starting point
            Debug.Log("Player lost a life! Lives remaining: " + lives);
            StartCoroutine(RespawnPlayer());
        }
        else
        {
            // No lives left — go to death screen
            Debug.Log("Player died! Game Over!");
            SceneManager.LoadScene("DeathScreen");
        }
    }

    private IEnumerator RespawnPlayer()
    {
        // Disable movement and hide player briefly
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        // Move to respawn point and restore
        transform.position = respawnPoint;
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }
}

