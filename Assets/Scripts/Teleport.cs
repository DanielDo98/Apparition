using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject test;
	public GameObject target;
	public GameObject lineRenderer;
	public float raycastHeight = 30f;

	public float maxRaycast = 100f;
	public float tpDistance = 3f;

	public float v0 = 5;

	private Vector3 targetPos;

	void SetupLine()
	{
		LineRenderer line = lineRenderer.GetComponent<LineRenderer> ();
		line.sortingLayerName = "OnTop";
		line.sortingOrder = 5;
		line.useWorldSpace = true;
	}

	public void SetUp() {
		SetupLine ();
	}

	//Functional ray code
	/*public void Update() {
		if (Input.GetMouseButton (1)) {
			RaycastHit hit;

			//Typical raycasting
			if (Physics.Raycast (transform.position, Camera.main.transform.forward, out hit, maxRaycast)) {
				GameObject hitObj = hit.transform.gameObject;
				RaycastHit newHit;
				//This checks if the object is in the raycastable layer.
				if (Physics.Raycast (hit.point + new Vector3 (0, raycastHeight, 0), Vector3.down, out newHit, maxRaycast, 1<<8)) {
					targetPos = newHit.point;
					target.transform.position = targetPos;
					lineRenderer.GetComponent<LineRenderer>().SetPosition(0, transform.position);
					lineRenderer.GetComponent<LineRenderer>().SetPosition(1, newHit.point);
				}
			}

		} else if (Input.GetMouseButtonUp (1)) {
			target.transform.position = new Vector3 (0, 0, 0); //If we finish the teleport, then reset the target object.
			transform.position = targetPos;
			lineRenderer.GetComponent<LineRenderer>().SetPosition(0, Vector3.zero);
			lineRenderer.GetComponent<LineRenderer>().SetPosition(1, Vector3.zero);
		}
	}*/


	public void Update() {
		if (Input.GetMouseButton (1)) {
			float theta = transform.forward.y;
			for (float t = 0f; t < 30f; t = t + .1f) {
				Object.Instantiate (test
					, transform.position + new Vector3(v0 * t * Mathf.Cos (theta), v0 * t * Mathf.Sin(theta) - 0.5f * 9.8f * t * t, v0 * t * Mathf.Cos (theta))
					, Quaternion.identity);
			}
		} else if (Input.GetMouseButtonUp (1)) {
			target.transform.position = new Vector3 (0, 0, 0); //If we finish the teleport, then reset the target object.
			transform.position = targetPos;
		}
	}
}
