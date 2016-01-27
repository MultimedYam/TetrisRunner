using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour 
{
	private float timerTime = 1.0f;
	
	private int sessionScore = 0;
	
	
	/// <summary>
	/// UI ELEMENTS
	/// </summary>
	public GameObject ScoreLabel;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateScore();
	}
	
	void UpdateScore()
	{
		timerTime -= Time.deltaTime;
		
		if (timerTime <= 0)
		{
			sessionScore += 1;
			if(ScoreLabel != null)
			{
				Text scoreVal = ScoreLabel.GetComponent<Text>();
				scoreVal.text = sessionScore.ToString();
			
			}
			
			timerTime = 1.0f;
		}
	}
	
	public void AddToScore(int val)
	{
		sessionScore += val;
		UpdateScore();
	}
}
