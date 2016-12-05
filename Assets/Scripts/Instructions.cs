using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour
{

	private GameController gc;

    void Start()
    {
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
			gc.loadScene(GameController.Scenes.MainMenu.ToString());
        }
    }
}
