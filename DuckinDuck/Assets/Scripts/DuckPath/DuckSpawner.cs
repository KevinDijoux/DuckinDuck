using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
	[SerializeField]
	private PathHolder _pathHolder;

	[SerializeField]
	private DuckFollower _duckPrefab;

	[SerializeField]
	Timer timer = new Timer(5f, false);

	private void Start()
	{
		if (_pathHolder == null)
		{
			_pathHolder = GetComponent<PathHolder>();
			if (_pathHolder == null )
			{
				Debug.LogError("No path holder found on " + gameObject.name);
			}
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
			duck.SetPath(_pathHolder.path);
			timer.Start();
		}
	}
}
