using UnityEngine;
using System.Collections;

public class SwipeScript : MonoBehaviour 
{
    private Vector3 destinationPos;
	private float FloatingTime = 0.9f;
	private Animator animatorController;
	private CapsuleCollider characterCapsule;
	private float duckTimer;
	
	public AudioClip wilhelmScream;
	private bool screaming = false;
	public AudioClip jumpSound;
    void Start()
	{
		characterCapsule = this.GetComponent<CapsuleCollider>();
        destinationPos = this.transform.position;
        animatorController = GetComponent<Animator>();
    }
    void OnSwipeLeft()
    {
        print("Left Swipe");
	    destinationPos = new Vector3(this.transform.position.x - 1, 0, -9);
    }
    void OnSwipeRight()
    {
        print("Right Swipe");
	    destinationPos = new Vector3(this.transform.position.x + 1, 0, -9);
    }
    void OnSwipeUp()
    {
        print("Up Swipe");
	    destinationPos = new Vector3(this.transform.position.x, 1.05f, -9);
	    animatorController.SetBool("Jump", true);
	    GetComponent<AudioSource>().PlayOneShot(jumpSound);
    }
    void OnSwipeDown()
    {
	    print("Down Swipe");
	    duck();
	    animatorController.SetBool("ShouldDuck", true);
    }
	
	
	void duck()
	{
		characterCapsule.height = 0.5f;
		characterCapsule.center= new Vector3(0, 0, 0);
		duckTimer = 1f;
	}
	
    void Update()
    {
        if (this.transform.position != destinationPos)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, destinationPos, 5.0f * Time.deltaTime);
        }
        if (this.transform.position.y >= 1)
        {
	        FloatingTime -= Time.deltaTime;
	        if (FloatingTime <= 0f)
	        {
		        FloatingTime = 0.9f;
                destinationPos = new Vector3(this.transform.position.x, this.transform.position.y - 1, -9);
	        }
        }
	    if (duckTimer > 0)
	    {
		    duckTimer -= Time.deltaTime;
		    if(duckTimer <= 0)
		    {
			    characterCapsule.height = 1.7f;
			    characterCapsule.center = new Vector3(0, 0.95f, 0);
		    }
	    }
	    
	    if (this.transform.position.x < -2.5f || this.transform.position.x > 2.5f)
	    {
	    	if (this.transform.position.x < -2.5f)
		    	destinationPos = new Vector3(-3f, -20f, this.transform.position.z);
		    else if (this.transform.position.x > 2.5f)
			    destinationPos = new Vector3(3f, -20f, this.transform.position.z);
	    	animatorController.SetBool("Falling", true);
	    	if (screaming == false)
	    	{
		    	GetComponent<AudioSource>().PlayOneShot(wilhelmScream);
		    	screaming = true;
	    	}
	    }
	    
    }
}
