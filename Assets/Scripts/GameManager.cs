using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Instantiate(Resources.Load<GameManager>("Game Manager"));
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    private void Awake() 
    {
        if (_instance == null)
        {
            _instance = this;
            SFXManager.SFXInstance.PlayMainMenuMusic();
            DontDestroyOnLoad(_instance.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private float sceneLoadDelay = 2f;

    // Constant Scene Names
    private const string MAIN_MENU_SCENE_NAME = "Main Menu";
    private const string END_MENU_SCENE_NAME = "End Menu";
    private const string GAME_SCENE_NAME = "Game";

    public void LoadMainMenu()
    {
        HUD.HUDInstance.gameObject.SetActive(false);
        SFXManager.SFXInstance.PlayMainMenuMusic();
        SceneManager.LoadScene(MAIN_MENU_SCENE_NAME);
    }

    public void LoadEndMenu()
    {
        HUD.HUDInstance.gameObject.SetActive(false);
        SFXManager.SFXInstance.PlayEndMenuMusic();
        StartCoroutine(DelayedSceneLoad(END_MENU_SCENE_NAME, sceneLoadDelay));
    }

    public void LoadGame()
    {
        HUD.HUDInstance.gameObject.SetActive(true);
        SFXManager.SFXInstance.PlayGameMusic();
        ScoreKeeper.ScoreKeeperInstance.ResetScore();
        SceneManager.LoadScene(GAME_SCENE_NAME);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    private IEnumerator DelayedSceneLoad(string sceneName, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(sceneName);
    }
}
