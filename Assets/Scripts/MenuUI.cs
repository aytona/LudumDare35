using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aytona.UI
{
    class MenuUI : MonoBehaviour
    {
        public GameObject[] canvases;

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void SwitchCanvas(string target)
        {
            foreach(GameObject canvas in canvases)
            {
                if (canvas.name != target)
                {
                    canvas.SetActive(false);
                }
                else
                {
                    canvas.SetActive(true);
                }
            }
        }
    }
}
