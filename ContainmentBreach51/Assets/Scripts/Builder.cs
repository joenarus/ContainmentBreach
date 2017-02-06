using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {
	public bool building;
	public int cost;
	public Camera PlayerCamera;
	// Use this for initialization
	void Start () {
		building = true;
		PlayerCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (building) { //dragging building
			Vector3 target = PlayerCamera.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
			transform.position = target;  //Vector3.MoveTowards(transform.position, target, 10 * Time.deltaTime);


			if (Input.GetMouseButtonDown(0)) { //places building
				if (cost <= GameObject.Find ("GameController").GetComponent<GameHandler> ().coins) {
					if (target.x >= -8.5 && target.x <= -6.5) {
						if (target.y >= -.5 && target.y <= 3.5) {
							building = false;
						}

					} else if (target.x >= -4.5 && target.x <= -2.5) {
						if (target.y >= -1.5 && target.y <= 2.5) {
							building = false;
						}
					} else if (target.x >= -.5 && target.x <= 1.5) {
						if (target.y >= -.5 && target.y <= 3.5) {
							building = false;
						}
					} else if (target.x >= 3.5 && target.x <= 5.5) {
						if (target.y >= -1.5 && target.y <= 2.5) {
							building = false;	 
						}
					} else {

						Debug.Log ("Can't build here");
						Destroy (gameObject);
					}
				} else {
					Debug.Log ("Not enough coins");
					Destroy (gameObject);
				}
				if (building == false) {
					GameObject.Find ("GameController").GetComponent<GameHandler> ().coinChange(0-cost);
				}
					
			}


		}
	}
}
