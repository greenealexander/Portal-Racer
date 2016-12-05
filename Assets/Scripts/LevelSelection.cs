using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour
{
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;
    public GameObject lock5;
    public GameObject GameClearedScreen;
    private GameController gc;
    private GameObject[] locks;

    // Use this for initialization
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        locks = new GameObject[] { lock1, lock2, lock3, lock4, lock5 };
        int clearedCounter = 0;

        for (int i = 0; i < GameController.ClearedLevels.Length; i++)
        {
            if (i == 0)
            {
                locks[i].SetActive(false);
            }
            else if (!GameController.ClearedLevels[i - 1])
            {
                locks[i].SetActive(true);
            }
            else
            {
                locks[i].SetActive(false);
                clearedCounter++;
            }
        }

        if (clearedCounter == 5)
        {
            GameClearedScreen.SetActive(true);
        }
        else
        {
            GameClearedScreen.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            gc.loadScene(GameController.Scenes.Level1.ToString());
        }
        if (Input.GetKeyDown("2") && GameController.ClearedLevels[0])
        {
            gc.loadScene(GameController.Scenes.Level2.ToString());
        }
        if (Input.GetKeyDown("3") && GameController.ClearedLevels[1])
        {
            gc.loadScene(GameController.Scenes.Level3.ToString());
        }
        if (Input.GetKeyDown("4") && GameController.ClearedLevels[2])
        {
            gc.loadScene(GameController.Scenes.Level4.ToString());
        }
        if (Input.GetKeyDown("5") && GameController.ClearedLevels[3])
        {
            gc.loadScene(GameController.Scenes.Level5.ToString());
        }
        if (Input.GetKeyDown("m")) 
        {
            gc.loadScene(GameController.Scenes.MainMenu.ToString());
        }
    }
}
