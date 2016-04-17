using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject[] scenesArray;

    private bool inPause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !inPause)
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        ResetSceneArray();
        ActivateScene("Main");
        inPause = false;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void PauseGame()
    {
        inPause = true;
        Time.timeScale = 0;
        ResetSceneArray();
        ActivateScene("Pause");
    }

    // TODO: Put resetscenearray() and activatescene() into a different class
    private void ResetSceneArray()
    {
        foreach (GameObject i in scenesArray)
        {
            if (i.activeInHierarchy)
            {
                i.SetActive(false);
            }
        }
    }

    private void ActivateScene(string name)
    {
        foreach (GameObject i in scenesArray)
        {
            if (i.name == name)
            {
                i.SetActive(true);
            }
        }
    }
}
