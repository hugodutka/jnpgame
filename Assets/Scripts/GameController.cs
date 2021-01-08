using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : ASingleton<GameController>
{
    private const string GAMEPLAY_SCENE_NAME = "Gameplay";

    private SceneLoader m_SceneLoader;

    private ulong m_Points = 0;

    public void HandleCoinPickedUp(Coin coin)
    {
        if (coin == null)
        {
            return;
        }

        m_Points += coin.Points;
        Debug.Log($"total points: {m_Points}");
    }

    protected override void Initialize()
    {
        m_SceneLoader = new SceneLoader();
        m_SceneLoader.LoadScene(GAMEPLAY_SCENE_NAME, HandleSceneLoaded);
    }

    private void HandleSceneLoaded(Scene loadedScene)
    {
        Debug.LogError($"Loaded scene {loadedScene.name}");
    }

    private bool m_Paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_Paused = !m_Paused;
            Time.timeScale = m_Paused ? 0f : 1f;
        }
    }
}
