using UnityEngine;
using System.Collections;

public class SegmentBehaviour : MonoBehaviour 
{
	public GameObject NewSegmentToSpawn;
	public float MovementSpeed;
	private GameObject parentObject;
	private GameObject gameManager;
	
	private float configuredMovementSpeed;
	
	// Update is called once per frame
	void Start ()
	{
		gameManager = GameObject.Find("GameController");
		parentObject = GameObject.Find("Floor");
		
		
	}
	void FixedUpdate () 
	{
		configuredMovementSpeed = gameManager.GetComponent<GamemodeHandler>().GameSpeed;
		this.transform.Translate (Vector3.back * MovementSpeed * configuredMovementSpeed * Time.deltaTime);
		if (this.transform.position.z <= -12)
		{
			GameObject childObject;
			childObject = Instantiate(NewSegmentToSpawn, new Vector3(0, 0, 13), Quaternion.identity) as GameObject;
			childObject.transform.SetParent(parentObject.transform);
			
			Destroy(this.gameObject);
		}
	}
}
