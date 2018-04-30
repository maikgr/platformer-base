using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	void Awake() {
		GameObject.FindGameObjectWithTag("Music").GetComponent<PlayMusic>().Play();
	}

	public void NewScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
}