using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    // win lose conditions

    public enum WinCondition
    {
        DefeatAllEnemies,
    }
    public enum LoseCondition
    {
        PlayerDead,
    }
    [SerializeField] private WinCondition _winCondition;
    [SerializeField] private LoseCondition _loseCondition;

    // win lose text and bools
    [Header("Text")]
    [SerializeField] private Text _winText;
    [SerializeField] private Text _loseText;



    // win conditions
    [Header("WinConditions")]
    // all enemies dead variables
    [SerializeField] private GameObject[] _enemies;



    // lose conditions
    [Header("LoseConditions")]
    // player dead
    public bool _playerDead = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        switch (_loseCondition)
        {
            case LoseCondition.PlayerDead:
                // check if player still alive
                if (_playerDead == true)
                {
                    _loseText.enabled = true;
                    StartCoroutine(LevelFinished());
                }
                break;
        }

        switch (_winCondition)
        {
            case WinCondition.DefeatAllEnemies:
                // check if all enemies exist
                foreach (GameObject enemy in _enemies)
                {
                    if(enemy)
                    { return; }
                }

                _winText.enabled = true;
                StartCoroutine(LevelFinished());
                break;
        }
	}

    private IEnumerator LevelFinished()
    {
        yield return new WaitForSeconds(3);
        SceneManager.instance.GoToMainMenu();
    }
}
