using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIScript : MonoBehaviour 
{
	private float timerTime = 1.0f;
	
	private int sessionScore = 0;
	private int totalCoins = 0;
	
	public GameObject GameOverLabel;
	
	
	/// <summary>
	/// UI ELEMENTS
	/// </summary>
	public GameObject ScoreLabel;
	public GameObject HighScoreLabel;
	public GameObject CoinAmountLabel;
	public GameObject LivesLabel;

	
	// Update is called once per frame
	void Update () 
	{
		UpdateUI();
	}
	
	void UpdateUI()
	{
		timerTime -= Time.deltaTime;
		
		if (timerTime <= 0)
		{
			if(ScoreLabel != null)
			{
				Text scoreVal = ScoreLabel.GetComponent<Text>();
				scoreVal.text = sessionScore.ToString();
			}
			timerTime = 1.0f;
		}
		
		if (totalCoins > 0)
		{
			CoinAmountLabel.GetComponent<Text>().text = totalCoins.ToString();
		}
	}
	
	public int GetScore()
	{
		return sessionScore;
	}
	
	public void SetHighScore(int val)
	{
		if (val > 0)
		{
			Text hiScoreVal = HighScoreLabel.GetComponent<Text>();
			hiScoreVal.text = val.ToString();
		}
	}
	
	public void AddToScore(int val)
	{
		sessionScore += val;
		UpdateUI();
	}
	
	public void SetGameOver(bool val)
	{
		if (val)
		{
			GameOverLabel.SetActive(val);
		}
	}
	
	public void RestartRun()
	{
		Time.timeScale = 1.0f;
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void SetCoinValue(int val)
	{
		totalCoins = val;
		Text totalCoinsLabel = CoinAmountLabel.GetComponent<Text>();
		totalCoinsLabel.text = val.ToString();
	}
	
	public void AddCoin(int val)
	{
		totalCoins += val;
	}
	
	public void SetLivesValue(int val)
	{
		Text livesLabel = LivesLabel.GetComponent<Text>();
		livesLabel.text = val.ToString();
	}
	
	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene("mainmenu");
	}
}
