using GSGD1;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
	[SerializeField]
	public Path path;

	private List<Path> _path = new List<Path>();

	[SerializeField]
	private DuckFollower _duckPrefab;

	[SerializeField]
    GSGD1.Timer timer = new GSGD1.Timer(5f, false);

	private void Start()
	{
		if (path == null)
		{
			GetAllPath();
			GetPath();
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
			duck.SetPath(path);
			timer.Start();
		}
	}

	private void GetPath()
	{
		var tempGet = _path[0];
		for (int i = 0, length = _path.Count; i < length; i++)
		{
			float distance = Vector3.Distance(_path[i].transform.position, transform.position);
			float targetDistance = Vector3.Distance(tempGet.transform.position, transform.position);

			if (distance < targetDistance)
			{
				tempGet = _path[i];
			}
		}
		path = tempGet;
	}

	

	private void GetAllPath()
	{
		
		_path.Clear();
		foreach (GameObject Path in GameObject.FindGameObjectsWithTag("Path"))
		{
			_path.Add(Path.GetComponent<Path>());
		}
	}
}
