﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	private AssetBundle myLoadedAssetBundle;
	private string[] scenePaths;

	// Use this for initialization
	void Start ()
	{
		//myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/");
		//scenePaths = myLoadedAssetBundle.GetAllScenePaths();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void newGame()
	{
		Debug.Log ("Loaded!");
		//SceneManager.LoadScene (scenePaths[0], LoadSceneMode.Single);
		Debug.Log ("Loaded!");
		Application.LoadLevel (1);
	}

	public void quit()
	{
		Application.Quit();
	}
}
