using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnSideWallCollision()
    {
        print("Collided with side wall");
    }

    void OnFaceWallCollision()
    {
        print("Collided with face wall");
    }

    void OnMoveBlockCollision()
    {
        print("Collided with block");
    }
}
