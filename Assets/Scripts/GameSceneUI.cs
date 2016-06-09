using UnityEngine;
using System.Collections;

public class GameSceneUI : MonoBehaviour {

	public void PlayShapesScene() {
		Application.LoadLevel("ShapeScene");
	}

	public void QuitApp() {
		Application.Quit();
	}
}
