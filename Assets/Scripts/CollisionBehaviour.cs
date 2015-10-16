using UnityEngine;
using System.Collections;

public class CollisionBehaviour : MonoBehaviour 
{

    public GameObject MessageTarget = null;

    void OnTriggerEnter(Collider collisionTarget)
    {
        Debug.Log("Collided, possible message sent");

        if (collisionTarget.tag == "SideWall")
        {
            MessageTarget.SendMessage("OnSideWallCollision", SendMessageOptions.DontRequireReceiver);
        }

        if (collisionTarget.tag == "FaceWall")
        {
            MessageTarget.SendMessage("OnFaceWallCollision", SendMessageOptions.DontRequireReceiver);
        }

        if (collisionTarget.tag == "MoveBlock")
        {
            MessageTarget.SendMessage("OnMoveBlockCollision", SendMessageOptions.DontRequireReceiver);
        }
    }
}
