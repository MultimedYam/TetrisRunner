using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuUIScript : MonoBehaviour 
{
	public GameObject MainMenuPanel;
	public GameObject ShopPanel;
	public GameObject ConfigPanel;
	public GameObject HighScoreLabel;
	
	void Start()
	{
		HighScoreLabel.GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore").ToString();
	}
	
	public void ShowMainMenu(bool val)
	{
		MainMenuPanel.SetActive(val);
	}
	
	public void ShowShopMenu(bool val)
	{
		ShopPanel.SetActive(val);
	}
	
	public void PlayGame()
	{
		SceneManager.LoadScene("gamescene");
	}
	
	
}
