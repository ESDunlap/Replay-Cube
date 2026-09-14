using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    [SerializeField]
    public bool replay = false;

    private void OnEnable()
    {
        EventBus.Subscribe(EventBusTypes.REPLAY, Replay);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(EventBusTypes.REPLAY, Replay);
    }

    public void CompleteLevel()
    {
        gameHasEnded = true;
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    void Replay()
    {
        gameHasEnded = false;
        replay = true;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
