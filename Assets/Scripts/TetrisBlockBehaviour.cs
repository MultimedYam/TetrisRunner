using UnityEngine;
using System.Collections;

public class TetrisBlockBehaviour : MonoBehaviour 
{
    public int BlockWidth; //Developer must set this in the inspector.
    public int MovementSpeed;
    private int laneWidth = 2;
	// Use this for initialization
	void Start () 
    {
	    if ((this.transform.position.x + BlockWidth) > laneWidth)
        {
            this.transform.Rotate(new Vector3(0,90,0));
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(!(this.transform.rotation.y == 0))
            this.transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);
        else
            this.transform.Translate(Vector3.back * MovementSpeed * Time.deltaTime);

        if(this.BlockWidth == 0) //Only walls are blockwidth 0
            this.transform.Translate(Vector3.back * MovementSpeed * Time.deltaTime);

        if (this.transform.position.z <= -12)
            Destroy(this.gameObject);
	}
}
