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
				RaycastHit newHit;
				if (Physics.Raycast (hit.point + new Vector3(0, raycastHeight, 0), Vector3.down, out newHit, maxRaycast)) {
					targetPos = newHit.point;
					target.transform.position = targetPos;
				}
			}
		} else if (Input.GetMouseButtonUp(1)) {
			target.transform.position = new Vector3(0, 0, 0);
			transform.position = targetPos;
		}
	}
}
