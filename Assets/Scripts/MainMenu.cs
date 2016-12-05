using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private GameController gameController;
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            gameController.loadScene(GameController.Scenes.LevelSelection.ToString());
        }
        if (Input.GetKeyDown("i"))
        {
            gameController.loadScene(GameController.Scenes.Instructions.ToString());
        }

        if (Input.GetKeyDown("l"))
        {
            gameController.loadScene(GameController.Scenes.LevelSelection.ToString());
        }
    }
}
