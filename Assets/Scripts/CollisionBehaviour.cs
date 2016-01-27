using UnityEngine;
using System.Collections;

public class CollisionBehaviour : MonoBehaviour 
{

	public GameObject MessageTarget = null;
	[SerializeField]
	public AudioClip coinPickupSound;
	[SerializeField]
	public AudioClip ObstacleHitSound;
	AudioSource audio;
	
	void Start()
	{
		audio = GetComponent<AudioSource>();
	}

    void OnTriggerEnter(Collider collisionTarget)
    {
        if (collisionTarget.tag == "FaceWall")
        {
        	audio.PlayOneShot(ObstacleHitSound, 1.0f);
            MessageTarget.SendMessage("OnFaceWallCollision", SendMessageOptions.DontRequireReceiver);
        }

        if (collisionTarget.tag == "MoveBlock")
        {
        	audio.PlayOneShot(ObstacleHitSound, 1.0f);
            MessageTarget.SendMessage("OnMoveBlockCollision", SendMessageOptions.DontRequireReceiver);
        }
	    
	    if (collisionTarget.tag == "CoinPickup")
	    {
	    	audio.PlayOneShot(coinPickupSound, 1.0f);
	    	Destroy(collisionTarget.gameObject);
	    	MessageTarget.SendMessage("OnCoinPickup", SendMessageOptions.DontRequireReceiver);
	    }
    }
}
