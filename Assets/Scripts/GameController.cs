using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : ASingleton<GameController>
{
    public UIMainInterfaceView MainInterfaceView;

    private const string GAMEPLAY_SCENE_NAME = "Gameplay";

    private SceneLoader m_SceneLoader;

    private ulong m_Points = 0;

    private float m_StartTime = 0.0f;

    public void ResetPoints()
    {
        m_Points = 0;
    }

    public void ResetStartTime()
    {
        m_StartTime = Time.time;
    }

    public void HandleCoinPickedUp(Coin coin)
    {
        if (coin == null)
        {
            return;
        }

        m_Points += coin.Points;
    }

    protected override void Initialize()
    {
        m_SceneLoader = new SceneLoader();
        m_SceneLoader.LoadScene(GAMEPLAY_SCENE_NAME, HandleSceneLoaded);

        MainInterfaceView.Initialize(Pause);
    }

    private void HandleSceneLoaded(Scene loadedScene)
    {
        Debug.LogError($"Loaded scene {loadedScene.name}");
    }

    private bool m_Paused = false;

    private void Update()
    {
        MainInterfaceView.Configure(m_Points, Time.time - m_StartTime);
    }

    private void Pause()
    {
        m_Paused = !m_Paused;
        Time.timeScale = m_Paused ? 0f : 1f;
    }
}
