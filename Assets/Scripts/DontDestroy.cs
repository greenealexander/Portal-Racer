using UnityEngine;

public class DontDestroy : MonoBehaviour {

	public static DontDestroy instance = null;

	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
