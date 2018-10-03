using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public static SceneManager instance = null;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

        // Update is called once per frame
        void Update () {
		
	}

    public void GoToScene(int sceneIndexNumber)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndexNumber);
    }

    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void GoToScene1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

}
