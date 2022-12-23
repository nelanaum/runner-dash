using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
	public UnityEngine.UI.Text text;
	public float timer;
	public int score;

	void Start()
	{
		score = 0;
	}

	void Update()
	{
		timer += Time.deltaTime;
		bool isTimerReachedOneSec = timer > 1f;
		
		
		if (isTimerReachedOneSec)
		{
			score++;
			timer = 0f;
		}
		
		text.text = score.ToString();
	}
}