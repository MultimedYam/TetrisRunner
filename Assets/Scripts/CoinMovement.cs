using UnityEngine;
using System.Collections;

public class CoinMovement : MonoBehaviour 
{
	
	public float ConfiguredMovementSpeed;
	public GameObject GameModeHandler;
	private GamemodeHandler gamehandler;
	
	private Vector3 originalSpawn;
	// Use this for initialization
	void Start () 
	{
		originalSpawn = this.transform.position;
		GameModeHandler = GameObject.Find("GameController");
		gamehandler = GameModeHandler.GetComponent<GamemodeHandler>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.transform.position.z >= -12)
		{
			SetSpeed(gamehandler.GameSpeed);
			if(!(this.transform.rotation.y == 0))
				this.transform.Translate(Vector3.right * ConfiguredMovementSpeed * Time.deltaTime);
			else
				this.transform.Translate(Vector3.back * ConfiguredMovementSpeed * Time.deltaTime);
			
			if (this.transform.position.z <= -12 && this.transform.position.z >= -14)
			{
				SendToSpawn();
			}
		}
	}
	
	public void SendToSpawn()
	{
		this.transform.position = originalSpawn;
	}
	
	public void SetSpeed(float val)
	{
		if (gamehandler.GameSpeed == 0)
		{
			ConfiguredMovementSpeed *= val;
		}
	}
}
