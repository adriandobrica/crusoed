﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BoatMove : MonoBehaviour {
	float angle;
	public float amplitude;
	public float frequency;
	public float step;
	Vector3 newposition;
	bool stopped;
	public GameObject directionalLight;
	Light objlight;
	public AudioSource explosion;
	public AudioSource blueDanube;

	IEnumerator Waiter()
	{
		yield return new WaitForSecondsRealtime (0.1f);
		Application.LoadLevel (1);
	}
	// Use this for initialization
	void Start () {
		angle = 0.0f;
		newposition = new Vector3 ();
		objlight = directionalLight.GetComponent<Light> ();
		stopped = false;
		blueDanube.Play ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (stopped == false) {
			transform.position += amplitude * (Mathf.Sin (2 * Mathf.PI * frequency * Time.time) -
			Mathf.Sin (2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))) * transform.up;
			newposition = transform.position;
			newposition.x = transform.position.x + step * Time.deltaTime;
			transform.position = newposition;

			if (transform.position.x >= 3.8f) {
				objlight.intensity = 8;
				objlight.bounceIntensity = 8;
				stopped = true;
				blueDanube.Stop ();
				explosion.Play ();
				StartCoroutine (Waiter ());
			}
		}
	}
}
