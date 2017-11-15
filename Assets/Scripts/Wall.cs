using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Wall : MonoBehaviour {

	public enum WallState{OPEN, CLOSED};

	public WallState wallState;
	public Wall[] triggers; //TODO add more triggers.
	private bool triggered = false; //TODO more customizable triggers

	public Material openMat;
	public Material closedMat;

	// Use this for initialization
	void Start () {
		if (wallState == WallState.OPEN) {
			setOpen ();
		} else {
			setClosed ();
		}
	}

	private void setOpen() {
		gameObject.tag = "Open";
		GetComponent<Renderer> ().material = openMat;
	}

	private void setClosed() {
		gameObject.tag = "Closed";
		GetComponent<Renderer> ().material = closedMat;
	}

	public void switchState() {
		if (wallState == WallState.CLOSED) {
			setOpen ();
			wallState = WallState.OPEN;
		} else {
			setClosed ();
			wallState = WallState.CLOSED;
		}
	}

	public void trigger() {
		if (!triggered) {
			foreach (Wall w in triggers) {
				w.switchState ();
			}
			triggered = true;
		}
	}
}
