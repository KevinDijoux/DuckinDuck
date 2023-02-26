
using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuackPlayer : MonoBehaviour
{
	[SerializeField]
	private List<AudioClip> audioClip = new List<AudioClip>();
	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private Timer timer = new Timer(5f, true);
	public void PlayQuack()
	{
		int index = Random.Range(0, audioClip.Count);
		audioSource.Play();
	}

	private void Start()
	{
		timer.Start();
		timer.OnEndCallback += HandleEndCallback;
	}

	private void Update()
	{
		timer.Update();
	}

	private void HandleEndCallback()
	{
		PlayQuack();
		timer = new Timer(Random.Range(1, 7));
		timer.Start();
	}
}
