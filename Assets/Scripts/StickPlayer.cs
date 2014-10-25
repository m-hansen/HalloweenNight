﻿using UnityEngine;
using System.Collections;

public class StickPlayer : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

		if(player != null){
			player.transform.position = this.transform.position;
		}
	
	}
}
