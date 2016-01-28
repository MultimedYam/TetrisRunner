using UnityEngine;
using System.Collections;

public class GamemodeHandler : MonoBehaviour 
{
	public int Score { get; private set; }
	public int HighScore {get; private set;}
	public int Lives { get; private set; }
	public int Coins { get; private set; }
	
	private float timer = 1f;
	
	public float GameSpeed = 1;
	
	public GameObject UI = null;
	// Use this for initialization
	void Start () 
	{
		HighScore = PlayerPrefs.GetInt("HighScore");
		Coins = PlayerPrefs.GetInt("Coins");
        Score = 0;
		Lives = PlayerPrefs.GetInt("Lives");
		
		UI.GetComponent<UIScript>().SetHighScore(HighScore);
		UI.GetComponent<UIScript>().SetCoinValue(Coins);
		UI.GetComponent<UIScript>().SetLivesValue(Lives);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    timer -= Time.deltaTime;
	    if (timer <= 0f)
	    {
	    	GameSpeed *= 1.001f;
	    	UI.GetComponent<UIScript>().AddToScore(1);
	    	timer = 1f;
	    }
    }
	
	
	//Rename to SetScore
	void SetScore(int val)
	{
		Score += val;
		if (Score > HighScore)
		{
			HighScore = Score;
		}
	}
	
	void AddCoin(int val)
	{
		Coins += val;
	}
	
	void ClearScore()
	{
		Score = 0;
	}
	
	void GameOver()
	{
		PlayerPrefs.SetInt("HighScore", HighScore);
		PlayerPrefs.SetInt("Coins", Coins);
		
		GetComponent<SwipeHandler>().TurnOffControls();
		GetComponent<BlockSpawner>().StopSpawning();
		GameObject.Find("Side Walls").GetComponent<BlockSpawner>().StopSpawning();
		GameSpeed = 0;
		UI.SendMessage("SetGameOver", true, SendMessageOptions.DontRequireReceiver);
		
		timer = 1000000;
	}
	
	void RemoveLife()
	{
		Lives--;
		GameSpeed = 1f;
		UI.GetComponent<UIScript>().SetLivesValue(Lives);
		
		if (Lives <= 0)
		{
			int score = UI.GetComponent<UIScript>().GetScore();
			SetScore(score);
			GameOver();
		}
	}
}
