using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DuckFollower : MonoBehaviour
{
	[SerializeField]
	private Path _path = null;

	[SerializeField]
	private float _moveSpeed = 1f;

	[SerializeField]
	private float _rotateSpeed = 1f;

	[SerializeField]
	private float _distanceThreshold = 0.5f;

	[SerializeField]
	private float _randomPos = 2.5f;

	[System.NonSerialized]
	private int _currentPathIndex = 0;

	private Vector3 _nextDestination;

	private bool _grosBool = false;

	public void SetCanMove(bool canMove)
	{
		this.enabled = canMove;
	}

	public void SetPath(Path path, bool teleportToFirstWaypoint = true)
	{
		_path = path;
		if (teleportToFirstWaypoint == true)
		{
			Transform firstWaypoint = _path.FirstWaypoint;
			if (firstWaypoint != null)
			{
				transform.position = firstWaypoint.position;
			}
		}
	}

	private void Update()
	{
		if (_path == null || _currentPathIndex >= _path.Waypoints.Count)
		{
			return;
		}
		if (_grosBool == false)
		{
			SetWaypoint(_currentPathIndex);
			_grosBool = true;
		}

		if (Vector3.Distance(transform.position, _nextDestination) < _distanceThreshold && _currentPathIndex < _path.Waypoints.Count - 1)
		{
			_currentPathIndex = _currentPathIndex + 1;
			SetNewDestination(Vector3.zero);
			return;
		}

		MoveTo(_nextDestination);
		LookAt(_nextDestination);
	}
	private void SetNewDestination(Vector3 position)
	{
		if (position == Vector3.zero)
		{
			Vector3 randomizedPosition = Vector3.zero;
			if (_currentPathIndex != 0 && _currentPathIndex != _path.Waypoints.Count - 1)
			{
				randomizedPosition = new Vector3(
										Random.Range(-_randomPos, _randomPos),
										0,
										Random.Range(-_randomPos, _randomPos));
			}

			_nextDestination = _path.Waypoints[_currentPathIndex].position + randomizedPosition;
		}
		else
		{
			_nextDestination = position;
		}
	}
	public void SetWaypoint(int indexPath)
	{
		_currentPathIndex = indexPath;

		SetNewDestination(Vector3.zero);
	}

	private void MoveTo(Vector3 position)
	{
		Vector3 movement = (position - transform.position).normalized * _moveSpeed * Time.deltaTime;
		transform.position += movement;
	}

	private void LookAt(Vector3 position)
	{
		//transform.LookAt(position, Vector3.up);

		Vector3 direction = position - transform.position;
		direction.y = 0;
		Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotateSpeed * Time.deltaTime);
	}
}

