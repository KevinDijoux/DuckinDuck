using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCameraLimits : MonoBehaviour
{
	[SerializeField]
	private float x = 10;

	[SerializeField]
	private float y = 10;
	
	[SerializeField]
	private float z = 10;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, new Vector3(x, y, z));
	}
}
