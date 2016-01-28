using UnityEngine;
using System.Collections;

public class CollisionBehaviour : MonoBehaviour 
{

	public GameObject MessageTarget = null;
	public GameObject GameManager = null;
	private Animator animatorController;
	
	[SerializeField]
	public AudioClip coinPickupSound;
	[SerializeField]
	public AudioClip ObstacleHitSound;
	AudioSource audio;
	
	private ParticleSystem particles;
	
	
	private int tempLives = 2;
	
	void Start()
	{
		audio = GetComponent<AudioSource>();
		particles = GetComponent<ParticleSystem>();
		animatorController = GetComponent<Animator>();
	}

    void OnTriggerEnter(Collider collisionTarget)
    {
        if (collisionTarget.tag == "FaceWall")
        {
        	audio.PlayOneShot(ObstacleHitSound, 1.0f);
        	GameManager.SendMessage("RemoveLife");
        	tempLives --;
	        MessageTarget.SendMessage("OnFaceWallCollision", SendMessageOptions.DontRequireReceiver);
	        if (tempLives == 0)
	        {
	        	animatorController.SetBool("FallFlat", true);
	        }
        }

        if (collisionTarget.tag == "MoveBlock")
        {
        	audio.PlayOneShot(ObstacleHitSound, 1.0f);
        	GameManager.SendMessage("RemoveLife");
        	tempLives --;
	        MessageTarget.SendMessage("OnMoveBlockCollision", SendMessageOptions.DontRequireReceiver);
	        if (tempLives == 0)
	        {
	        	animatorController.SetBool("FallFlat", true);
	        }
        }
	    
	    if (collisionTarget.tag == "CoinPickup")
	    {
	    	audio.PlayOneShot(coinPickupSound, 1.0f);
	    	particles.Emit(1);
	    	particles.time = 0;
	    	collisionTarget.SendMessage("SendToSpawn", SendMessageOptions.DontRequireReceiver);
	    	GameManager.SendMessage("AddCoin", 1, SendMessageOptions.DontRequireReceiver);
	    	MessageTarget.SendMessage("OnCoinPickup", SendMessageOptions.DontRequireReceiver);
	    }
	    
	    if (collisionTarget.tag == "SideWall")
	    {
		    GameManager.SendMessage("GameOver");
	    }
    }
}
