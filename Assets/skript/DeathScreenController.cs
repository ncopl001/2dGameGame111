using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start button clicked! Loading Main Scene...");
        SceneManager.LoadScene("game for class");
    }
}