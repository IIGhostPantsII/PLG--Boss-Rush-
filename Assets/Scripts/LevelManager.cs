using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level
{
    Level1,
    Level2,
    Level3
}

public class LevelManager : MonoBehaviour
{
    [SerializeField] public Level _currentLevel;
    [SerializeField] public GameObject[] _levels;

    void Start()
    {
        LoadLevel(_currentLevel);
    }

    void LoadLevel(Level level)
    {
        switch(level)
        {
            case Level.Level1:
                _levels[0].SetActive(true);
                break;
            case Level.Level2:
                break;
            case Level.Level3:
                break;
            default:
                Debug.LogError("Error Unknown Level");
                break;
        }
    }

    public void NextLevel()
    {
        switch(_currentLevel)
        {
            case Level.Level1:
                _currentLevel = Level.Level2;
                break;
            case Level.Level2:
                _currentLevel = Level.Level3;
                break;
            case Level.Level3:
                Debug.Log("Win");
                break;
            default:
                Debug.LogError("Error Unknown Level");
                break;
        }

        LoadLevel(_currentLevel);
    }
}

