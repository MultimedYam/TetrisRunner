using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BlockSpawner : MonoBehaviour 
{
    public enum SpawnFrequency { Slow, Normal, Fast };
    [SerializeField]
    public List<GameObject> MoveBlocks = new List<GameObject>();
    [SerializeField]
    public List<GameObject> JumpBlocks = new List<GameObject>();
    [SerializeField]
    public List<GameObject> SlideBlocks = new List<GameObject>();
    [SerializeField]
    public List<GameObject> Coin = new List<GameObject>();
    public List<Vector3> BlockSpawns = new List<Vector3>();
    [SerializeField]
    public SpawnFrequency BlockSpawnFrequency;

    private enum EventType { Move = 1, Jump = 2, Slide = 3, Coin = 4 };
    private float timer = 0;
    private float timeInterval;
    private GameObject parent;

	// Use this for initialization
	void Start () 
    {
        parent = GameObject.Find("SpawnedBlocks");

	    switch (BlockSpawnFrequency)
        {
            case SpawnFrequency.Slow:
                {
                    timeInterval = 5.75f;
                    break;
                }
            case SpawnFrequency.Normal:
                {
                    timeInterval = 4f;
                    break;
                }
            case SpawnFrequency.Fast:
                {
                    timeInterval = 3.5f;
                    break;
                }
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        if (timer >= timeInterval)
        {

            EventType currentEvent = (EventType)Random.Range(1, 4);
            switch(currentEvent)
            {
                case EventType.Move:
                    {
                        GameObject _object = Instantiate(MoveBlocks[Random.Range(0, MoveBlocks.Count)], BlockSpawns[Random.Range(0, 4)], Quaternion.identity) as GameObject;
                        _object.transform.SetParent(parent.transform);

                        timer = 0;
                        break;
                    }
                case EventType.Jump:
                    {
                        GameObject objectToSpawn = JumpBlocks[Random.Range(0, JumpBlocks.Count)];
                        GameObject _object = Instantiate(objectToSpawn, BlockSpawns[2], objectToSpawn.transform.rotation) as GameObject;
                        _object.transform.SetParent(parent.transform);

                        timer = -2;
                        break;
                    }
                case EventType.Slide:
                    {
                        GameObject objectToSpawn = SlideBlocks[Random.Range(0, SlideBlocks.Count)];
                        GameObject _object = Instantiate(objectToSpawn, new Vector3(0,0,13), objectToSpawn.transform.rotation) as GameObject;
                        _object.transform.SetParent(parent.transform);

                        timer = -2;
                        break;
                    }
                case EventType.Coin:
                    {
                        GameObject objectToSpawn = Coin[0];
                        Instantiate(objectToSpawn, BlockSpawns[Random.Range(0, 4)], objectToSpawn.transform.rotation);

                        timer = 0;
                        break;
                    }
                default:
                    {
                        GameObject objectToSpawn = Coin[0];
                        Instantiate(objectToSpawn, BlockSpawns[Random.Range(0, 4)], objectToSpawn.transform.rotation);

                        timer = 0;
                        break;
                    }
            }
        }
    }
}
