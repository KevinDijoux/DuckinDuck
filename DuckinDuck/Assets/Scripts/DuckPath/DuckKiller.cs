using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckKiller : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Duck")
		{
			print("Duck killed");
			Destroy(other.gameObject);
		}
	}
}
