using UnityEngine;
using System.Collections;

public class GamemodeHandler : MonoBehaviour 
{
	public int Score { get; private set; }
	public int HighScore {get; private set;}
	public int Lifes { get; private set; }
	
	private float timer = 5f;
	
	public float GameSpeed = 1;
	// Use this for initialization
	void Start () 
	{
		HighScore = PlayerPrefs.GetInt("Score");
        Score = 0;
        Lifes = 2;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    timer -= Time.deltaTime;
	    if (timer <= 0f)
	    {
	    	GameSpeed *= 1.001f;
	    	timer = 5f;
	    }
    }
	
	void OnApplicationQuit()
	{
		PlayerPrefs.SetInt("Score", Score);
	}
	
	void AddToScore(int val)
	{
		Score += val;
		if (Score > HighScore)
		{
			HighScore = Score;
		}
	}
	
	void ClearScore()
	{
		Score = 0;
	}
}
