
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnd = false;
    public float restartDelay = 1f;

    public GameObject LevelComplete;
    public void CompleteLevel()
    {
        LevelComplete.SetActive(true);
    }
    public void endGame ()
    {
        if(gameEnd == false)
        {
            gameEnd = true;
            Debug.Log("Game over");
            Invoke("restart", restartDelay);
        }
        
    }

    void restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
