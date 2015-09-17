using UnityEngine;
using System.Collections;

public class TetrisBlockBehaviour : MonoBehaviour 
{
    public int BlockWidth; //Developer must set this in the inspector.
    public int MovementSpeed;
    private int laneWidth = 5;
	// Use this for initialization
	void Start () 
    {
	    if (ShouldRotate())
        {
            this.transform.Rotate(Vector3.right * Time.deltaTime, Space.Self);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        this.transform.Translate(Vector3.back * MovementSpeed * Time.deltaTime);
	}

    bool ShouldRotate()
    {
        if (this.transform.position.x + BlockWidth > laneWidth)
        {
            return true;
        }
        return false;
    }
}
