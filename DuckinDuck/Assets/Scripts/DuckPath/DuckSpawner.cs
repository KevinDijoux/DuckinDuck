using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
	[SerializeField]
	public Path _path;

	[SerializeField]
	private DuckFollower _duckPrefab;

	[SerializeField]
	Timer timer = new Timer(5f, false);

	private void Start()
	{
		if (_path == null)
		{
			Debug.LogError("No path holder found on " + gameObject.name);
		}
		timer.OnEndCallback += HandleEndCallback;
		timer.Start();
	}

	private void Update()
	{
		timer.Update();
	}

	private void HandleEndCallback()
	{
		if (_duckPrefab != null) 
		{ 
			DuckFollower duck = Instantiate(_duckPrefab, transform.position, Quaternion.identity);
			duck.SetPath(_path);
			timer.Start();
		}
	}
}
