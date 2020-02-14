using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
  [SerializeField] Animator getReadyAnim;
  [SerializeField] GameObject crushedCanvas;
  [SerializeField] GameObject player;

  void Start() {
    StartCoroutine(waitForReady());
  }

  public void ShowCrushed() {
    crushedCanvas.SetActive(true);
    StartCoroutine(waitForContinue());
  }

  IEnumerator waitForReady() {
    Time.timeScale = 0f;
    getReadyAnim.SetTrigger("GetReady");
    float count = 0f;
    while (count < 1f) {
      count += Time.unscaledDeltaTime;
      yield return null;
    }
    Time.timeScale = 1f;
    yield return null;
  }

  IEnumerator waitForContinue() {
    while (true) {
      if (Input.GetButton("Cancel")) {
        Application.Quit();
        break;
      } else if (Input.anyKeyDown) {
        crushedCanvas.SetActive(false);
        yield return SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
        break;
      }
      yield return null;
    }
    yield return null;
  }
}