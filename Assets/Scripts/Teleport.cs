using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
	
	void Update () {
		if (Input.GetMouseButton (1)) {
			RaycastHit hit;

			if (Physics.Raycast (transform.position, transform.forward, out hit, maxRaycast)) {
				GameObject hitObj = hit.transform.gameObject;
				if (hitObj.tag == "Open") {
					transform.position = hit.transform.position + tpDistance * transform.forward;
					hitObj.GetComponent<Wall> ().trigger ();
				} else {
					//TODO
				}
			}
		}
	}
}
