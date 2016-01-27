using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour 
{
	
	public GameObject MessageReceiver;
	
	private UIScript otherScript;
	// Use this for initialization
	void Start () 
	{
		otherScript = GetComponent<UIScript>();
	}

    void OnFaceWallCollision()
	{
		otherScript.AddToScore(-10);
        print("Collided with face wall");
    }

    void OnMoveBlockCollision()
	{
		otherScript.AddToScore(-5);
        print("Collided with block");
    }
	
	void OnCoinPickup()
	{
		otherScript.AddToScore(5);
		print ("Picked up Coin");
	}
}
