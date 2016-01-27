using UnityEngine;
using System.Collections;

public class TetrisBlockBehaviour : MonoBehaviour 
{
    public int BlockWidth; //Developer must set this in the inspector.
	public float ConfiguredMovementSpeed;
	private int laneWidth = 2;
	
	public GameObject GameModeHandler;
	private GamemodeHandler gamehandler;
	// Use this for initialization
	void Start () 
	{
		GameModeHandler = GameObject.Find("GameController");
		gamehandler = GameModeHandler.GetComponent<GamemodeHandler>();
	    if ((this.transform.position.x + BlockWidth) > laneWidth)
        {
            this.transform.Rotate(new Vector3(0,90,0));
        }
	}
	
	// Update is called once per frame
	void Update () 
	{
		SetSpeed(gamehandler.GameSpeed);
        if(!(this.transform.rotation.y == 0))
            this.transform.Translate(Vector3.right * ConfiguredMovementSpeed * Time.deltaTime);
        else
            this.transform.Translate(Vector3.back * ConfiguredMovementSpeed * Time.deltaTime);

        if(this.BlockWidth == 0) //Only walls are blockwidth 0
            this.transform.Translate(Vector3.back * ConfiguredMovementSpeed * Time.deltaTime);

        if (this.transform.position.z <= -12)
        {
	        //MessageTarget.SendMessage("OnBlockDelete", SendMessageOptions.DontRequireReceiver);
            Destroy(this.gameObject);
        }
    }
	
	public void SetSpeed(float val)
	{
		ConfiguredMovementSpeed *= val;
	}
}
