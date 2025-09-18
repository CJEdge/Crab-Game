using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowComponent : MonoBehaviour
{
	public Transform[] targets; // An array of the transforms of the players
	public float padding = 2f; // The padding around the players that you want to show
	public float smoothTime = 0.3f; // The smoothing time for the camera movement
	public float minCameraY = 0f; // The minimum y-position of the camera

	private Camera _camera; // The camera component attached to this game object
	private Vector3 _velocity; // The velocity of the camera movement for smoothing

	void Start() {
		_camera = GetComponent<Camera>();
	}

	void LateUpdate() {
		// If there are no players in the scene, don't do anything
		if (targets.Length == 0) {
			return;
		}

		// Find the bounds of all the players
		Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
		for (int i = 0; i < targets.Length; i++) {
			bounds.Encapsulate(targets[i].position);
		}

		// Calculate the current camera height based on the current camera size
		float currentCameraHeight = _camera.orthographicSize * 2f;

		// Calculate the target camera height based on the minimum y-position and the desired camera size
		float targetCameraHeight = Mathf.Max(bounds.size.x, bounds.size.y) / 2f + padding + minCameraY;

		// Calculate the difference between the current camera height and the target camera height
		float heightDiff = targetCameraHeight - currentCameraHeight;

		// Calculate the desired camera position
		Vector3 desiredPosition = bounds.center;
		desiredPosition.z = transform.position.z;

		// Adjust the desired camera position by the height difference
		desiredPosition.y += heightDiff;

		// Set the camera position and size using smoothing
		transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, smoothTime);
		_camera.orthographicSize = Mathf.SmoothDamp(_camera.orthographicSize, targetCameraHeight / 2f, ref _velocity.z, smoothTime);
	}
}