using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTeleport : MonoBehaviour {

	public GameObject target;
	public float raycastHeight = 30f;

	public float maxRaycast = 100f;
	public float tpDistance = 3f;

	private Vector3 targetPos;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			RaycastHit hit;

			if (Physics.Raycast (transform.position, Camera.main.transform.forward, out hit, maxRaycast)) {
				GameObject hitObj = hit.transform.gameObject;
				if (hitObj.tag == "OpenPassable") {
					hitObj.layer = 2; //Ignore raycast.
					hitObj.GetComponent<Wall> ().setOpen ();

					RaycastHit newHit;
					if (Physics.Raycast (hit.point + new Vector3 (0, raycastHeight, 0), Vector3.down, out newHit, maxRaycast, 1<<8)) {
						targetPos = newHit.point;
						target.transform.position = targetPos;
					}

					hitObj.layer = 0; //Default
				}

				//DUPLICATED CODE
				RaycastHit newHit2;
				if (Physics.Raycast (hit.point + new Vector3 (0, raycastHeight, 0), Vector3.down, out newHit2, maxRaycast, 1<<8)) {
					targetPos = newHit2.point;
					target.transform.position = targetPos;
				}
			}

		} else if (Input.GetMouseButtonUp (1)) {
			target.transform.position = new Vector3 (0, 0, 0);
			transform.position = targetPos;
		} else if (Input.GetMouseButton (0)) {
			RaycastHit hit;

			if (Physics.Raycast (transform.position, transform.forward, out hit, maxRaycast)) {
				GameObject hitObj = hit.transform.gameObject;
				if (hitObj.tag == "Open") {
					hitObj.GetComponent<Wall> ().setOpenPassable ();
					hitObj.GetComponent<Wall> ().trigger ();
				} else {
					//TODO
				}
			}
		}
	}
}
