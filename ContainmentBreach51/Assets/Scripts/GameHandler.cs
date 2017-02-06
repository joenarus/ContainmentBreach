﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {
	public int waveNumber;
	public int hordeSize;
	public int score;
	public int lives;
	public int coins;
	public bool changed;
	public Camera PlayerCamera;

	public AlienHordeBehavior horde;
	public GameObject building1;

	public Text lives_text;
	public Text coins_text;
	public Text score_text;
	public Text wave_text;
	public Builder currentBuilding;
	//public Canvas Buildings;


	// Use this for initialization
	void Start () {
		lives = 10;
		score = 0;
		coins = 10;
		changed = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (changed) {
			lives_text.text = "Lives: " + lives;
			score_text.text = "Score: " + score;
			coins_text.text = "Coins: " + coins;
			wave_text.text = "Wave: " + waveNumber;
			changed = false;
		}
	}

	public void newWave() {
		waveNumber++;
		coinChange (coins*waveNumber);
	}

	public int coinChange(int x) {
		coins += x;
		changed = true;
		return coins;
	}

	public int scoreChange(int x) {
		score += x;
		changed = true;
		return score;
	}
	public int livesChange(int x) {
		lives += x;
		changed = true;
		return lives;
	}

	public void buildBuilding(int x) {
		
		if (x == 1) {
		
			GameObject clone = Instantiate (building1, Input.mousePosition, Quaternion.identity);
			clone.transform.parent = GameObject.Find ("Buildings").transform;
			currentBuilding = clone.GetComponent<Builder> ();
		}
	}
}
