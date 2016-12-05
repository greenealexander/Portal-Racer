using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static GameController instance = null;
    public enum Scenes { MainMenu, LevelSelection, Instructions, Level1, Level2, Level3, Level4, Level5 };
    public static string CurrentGameScene;
    public static bool[] ClearedLevels;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        SaveData.loadClearedLevels();
    }

    public void loadScene(string scene)
    {
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }

    public void restartScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void loadNextLevel() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
}