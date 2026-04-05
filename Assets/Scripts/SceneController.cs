using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneController : MonoBehaviour
{
    [SerializeField] readonly GameInstaller _gameInstaller;

    public SceneController(GameInstaller gameInstaller)
    {
        _gameInstaller = gameInstaller;
    }
    public void OpenMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenGameScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}

