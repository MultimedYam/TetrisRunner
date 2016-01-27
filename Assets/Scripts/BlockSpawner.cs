﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BlockSpawner : MonoBehaviour 
{
    public enum SpawnFrequency { Slow, Normal, Fast, SideWalls };
    [SerializeField]
    public List<GameObject> MoveBlocks = new List<GameObject>();
    [SerializeField]
    public List<GameObject> JumpBlocks = new List<GameObject>();
    [SerializeField]
    public List<GameObject> SlideBlocks = new List<GameObject>();
	public GameObject Coin;
    public List<Vector3> BlockSpawns = new List<Vector3>();
    [SerializeField]
    public SpawnFrequency BlockSpawnFrequency;

    private enum EventType { Move = 1, Jump = 2, Slide = 3};
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
                    timeInterval = 3f;
                    break;
                }
            case SpawnFrequency.SideWalls:
                {
                    timeInterval = 2f;
                    break;
                }
        }
    }
	
	public void	SpawnCoin()
	{
		if (Coin != null)
		{
			Vector3 chosenSpawn = BlockSpawns[Random.Range(0, 4)];
			Vector3 coinsSpawn = new Vector3(chosenSpawn.x, 0.5f, chosenSpawn.z);
			Instantiate(Coin, coinsSpawn, Coin.transform.rotation);
		
			timer = 0;
		}
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        if (timer >= timeInterval)
        {
        	SpawnCoin();

	        EventType currentEvent = (EventType)Random.Range(1, 3);
            switch(currentEvent)
            {
                case EventType.Move:
                    {
                        if (MoveBlocks.Count > 0)
                        {
                            GameObject _object = Instantiate(MoveBlocks[Random.Range(0, MoveBlocks.Count)], BlockSpawns[Random.Range(0, 4)], Quaternion.identity) as GameObject;
                            _object.transform.SetParent(parent.transform);

                            timer = 0;
                        }
                        break;
                    }
                case EventType.Jump:
                    {
                        if (JumpBlocks.Count > 0)
                        {
                            GameObject objectToSpawn = JumpBlocks[Random.Range(0, JumpBlocks.Count)];
                            GameObject _object = Instantiate(objectToSpawn, BlockSpawns[2], objectToSpawn.transform.rotation) as GameObject;
                            _object.transform.SetParent(parent.transform);

                            timer = -2;
                        }
                        break;
                    }
                case EventType.Slide:
                    {
                        if (SlideBlocks.Count > 0)
                        {
                            GameObject objectToSpawn = SlideBlocks[Random.Range(0, SlideBlocks.Count)];
                            GameObject _object = Instantiate(objectToSpawn, new Vector3(0, 0, 13), objectToSpawn.transform.rotation) as GameObject;
                            _object.transform.SetParent(parent.transform);

                            timer = -2;
                        }
                        break;
                    }
                default:
                    {
	                    GameObject objectToSpawn = Coin;
                        Instantiate(objectToSpawn, BlockSpawns[Random.Range(0, 4)], objectToSpawn.transform.rotation);

                        timer = 0;
                        break;
                    }
            }
        }
    }
}
