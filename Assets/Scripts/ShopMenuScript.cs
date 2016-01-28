using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopMenuScript : MonoBehaviour {
	
	
	private int Coins;
	private int Lives;
	
	private int BuyLifeCost = 10;
	
	public GameObject buyButton;
	
	public GameObject coinLabel;
	public GameObject heartLabel;
	
	void Start()
	{
		PlayerPrefs.SetInt("Lives", 2);
	}
	
	void Update()
	{
		Coins = PlayerPrefs.GetInt("Coins");
		Lives = PlayerPrefs.GetInt("Lives");
		
		if (buyButton != null)
		{
			if (Coins < BuyLifeCost)
			{
				buyButton.SetActive(false);
			}
			else buyButton.SetActive(true);
		}
		
		coinLabel.GetComponent<Text>().text = Coins.ToString();
		heartLabel.GetComponent<Text>().text = Lives.ToString();
		UpdatePlayerPrefs();
	}
	
	public void BuyLife()
	{
		Coins -= BuyLifeCost;
		Lives ++;
		UpdatePlayerPrefs();
	}
	
	private void UpdatePlayerPrefs()
	{
		PlayerPrefs.SetInt("Coins", Coins);
		PlayerPrefs.SetInt("Lives", Lives);
	}
	
}
