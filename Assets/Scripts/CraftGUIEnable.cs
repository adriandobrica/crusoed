﻿using UnityEngine;
using System.Collections;

public class CraftGUIEnable : MonoBehaviour {
    bool enable = true;
    // Use this for initialization
    GameObject background;
	void Start () {
        background = transform.GetChild(0).gameObject;
        background.SetActive(enable);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            enable = !enable;
            if (enable)
            {
                //background.transform.GetChild(0).GetComponent<CraftSlotsManager>().mapIcons();
            }
            background.SetActive(enable);
            //Debug.Log("Pressed C!\n");
        }

    }
}
