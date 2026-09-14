using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void LoadNextLevel()
    {
        if (gameManager.replay)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            gameManager.replay = true;
            EventBus.Publish(EventBusTypes.REPLAY);
            this.gameObject.SetActive(false);
        }
    }
}
