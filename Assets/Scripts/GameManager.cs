using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  private ControlMap controls;
  [Header("Events")]
  [Space]
  public UnityEvent OnPauseEvent;
  public int sceneIndex = 1;

  void OnEnable() { controls.Enable(); }
  void OnDisable() { controls.Disable(); }

  public void OnStartGame()
  {
    Debug.Log("Hi");
    SceneManager.LoadScene(1);
  }

  public void MainMenu()
  {
    SceneManager.LoadScene(0);
    sceneIndex = 1;
  }

  public void OnLevelComplete()
  {
    SceneManager.LoadScene(sceneIndex += 1);
  }

  public void OnPause()
  {
    Time.timeScale = 0;
  }

  public void OnResume()
  {
    Time.timeScale = 1;
  }

  void Awake()
  {
    controls = new ControlMap();
    controls.Player.Pause.performed += ctx => { OnPauseEvent.Invoke(); };
    DontDestroyOnLoad(this.gameObject);
  }

}
