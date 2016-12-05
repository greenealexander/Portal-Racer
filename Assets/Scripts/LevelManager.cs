using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Text timeText;
    public Text bestTimeText;
    private float startTime;
    private float playerTime;
    private bool isFin;
    private float bestTime;
    public GameObject winGamePopUp;
    public GameObject loseGamePopUp;
    public Image img;
    private GameController gameController;
    private Rigidbody car;
    private float gameTime;
    public float maxGameTime;
    private Vector3 startPos;
    private Quaternion startRot;

    void Start()
    {
        GameController.CurrentGameScene = SceneManager.GetActiveScene().name;
        // reset the game score before 
        // SaveData.Save(GameController.currentGameScene, maxGameTime);
        bestTime = SaveData.Load(GameController.CurrentGameScene);
        winGamePopUp.SetActive(false);
        loseGamePopUp.SetActive(false);
        isFin = false;
        startTime = Time.time;
        Color c = img.color;
        c.a = 0.7f;
        img.color = c;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        car = GameObject.Find("Car").GetComponent<Rigidbody>();
        gameTime = maxGameTime;
        startPos = gameObject.transform.position;
        startRot = gameObject.transform.rotation;
    }

    void Update()
    {
        if (!isFin && gameTime > 0)
        {
            gameTime = maxGameTime - (Time.time - startTime);
            if (gameTime <= 10f)
            {
                timeText.color = new Color(1f, 0.5f, 0.8f);
            }
            timeText.text = floatToTimeString(gameTime);
            if (car.position.y <= -30)
            {
                gameObject.transform.position = startPos;
                gameObject.transform.rotation = startRot;
                car.velocity = Vector3.zero;
            }
        }
        else if (gameTime <= 0)
        {
            isFin = true;
            Destroy(car.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl>());
            timeText.text = floatToTimeString(0f);
            timeText.color = new Color(1f, 1f, 1f);
            loseGamePopUp.SetActive(true);
            car.velocity = Vector3.zero;
        }

        if (isFin)
        {
            if (SceneManager.GetActiveScene().name.Equals("Level5"))
            {
                GameObject.Find("NextLevel").SetActive(false);
            }
            else if (Input.GetKeyDown("n"))
            {
                gameController.loadNextLevel();
            }


            if (Input.GetKeyDown("r"))
            {
                gameController.restartScene();
            }
            if (Input.GetKeyDown("l"))
            {
                gameController.loadScene(GameController.Scenes.LevelSelection.ToString());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FinishLine")
        {
            isFin = true;
            playerTime = maxGameTime - gameTime;
            timeText.text = floatToTimeString(playerTime);

            if (playerTime < bestTime)
            {
                bestTime = playerTime;
                SaveData.Save(GameController.CurrentGameScene, bestTime);
            }
            bestTimeText.text = floatToTimeString(bestTime);
            winGamePopUp.SetActive(true);
            Destroy(car.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl>());
            car.velocity = Vector3.zero;
            timeText.color = new Color(1f, 1f, 1f);

            switch (SceneManager.GetActiveScene().name)
            {
                case "Level1":
                    clearLevel(0);
                    break;
                case "Level2":
                    clearLevel(1);
                    break;
                case "Level3":
                    clearLevel(2);
                    break;
                case "Level4":
                    clearLevel(3);
                    break;
                case "Level5":
                    clearLevel(4);
                    break;
                default:
                    Debug.Log("wrong scene");
                    break;
            }
        }
    }

    private void clearLevel(int i)
    {
        GameController.ClearedLevels[i] = true;
        SaveData.saveClearedLevels();

    }

    private string floatToTimeString(float time)
    {
        int mins = ((int)time / 60);
        float secs = (time % 60);
        return string.Format("{0:00}:{1:00.00}", mins, secs);
    }
}