using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
	[SerializeField]
	private float _cameraSpeed = 25f;

	[SerializeField]
	private List<GameObject> _movementLimits = new List<GameObject>();

	private GameObject _movementLimit;


	private void OnEnable()
	{
		_movementLimit = _movementLimits[0];
	}

	private	void GoodOlMovement()
	{
		transform.localPosition = new UnityEngine.Vector3
									(Mathf.Clamp(transform.localPosition.x + _cameraSpeed * Input.GetAxis("Horizontal") * Time.deltaTime,
									-_movementLimit.transform.localPosition.x, _movementLimit.transform.position.x),

									transform.position.y,

									Mathf.Clamp(transform.localPosition.z + _cameraSpeed * Input.GetAxis("Vertical") * Time.deltaTime,
									-_movementLimit.transform.localPosition.z, _movementLimit.transform.localPosition.z));

	}

	void LateUpdate()
	{
		GoodOlMovement();
	}
}
