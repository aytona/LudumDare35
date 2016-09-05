using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aytona.UI.Canvas
{
    class MenuUI : MonoBehaviour
    {
        public GameObject[] canvases = null;

        public void StartGame()
        {
            SceneManager.LoadScene(1);
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
