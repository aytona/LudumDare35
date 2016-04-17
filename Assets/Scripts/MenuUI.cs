using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject[] scenesArray;

	public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToMain()
    {
        ResetSceneArray();
        ActivateScene("Main");
    }

    public void ToInstructions()
    {
        ResetSceneArray();
        ActivateScene("Instructions");
    }

    public void ToCredits()
    {
        ResetSceneArray();
        ActivateScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void ResetSceneArray()
    {
        foreach(GameObject i in scenesArray)
        {
            if (i.activeInHierarchy)
            {
                i.SetActive(false);
            }
        }
    }

    private void ActivateScene(string name)
    {
        foreach(GameObject i in scenesArray)
        {
            if (i.name == name)
            {
                i.SetActive(true);
            }
        }
    }
}
