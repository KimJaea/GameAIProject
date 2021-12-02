using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This script is the modification of the implementation of the Flocks behaviors from http://www.unifycommunity.com/wiki/index.php?title=Flocking
/// </summary>

public class FlockController : MonoBehaviour
{
	public float minVelocity = 3;       
	public float maxVelocity = 12;       
	public int flockSize = 7;        
	public float centerWeight = 2;      
	public float velocityWeight = 2;    
	public float separationWeight = 2;  
	public float followWeight = 20;     
	public float randomizeWeight = 1;  

	public Flock prefab;
	public Transform target;
	public GameObject gameobj;

	internal Vector3 flockCenter;      
	internal Vector3 flockVelocity;    

	public ArrayList flockList = new ArrayList();

	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Fatherbody").transform;

		for (int i = 0; i < flockSize; i++)
		{
			Flock flock = Instantiate(prefab, transform.position, transform.rotation) as Flock;
			flock.transform.parent = transform;
			flock.controller = this;
			flockList.Add(flock);
		}
	}

	void Update()
	{
		Vector3 center = Vector3.zero;
		Vector3 velocity = Vector3.zero;

		foreach (Flock flock in flockList)
		{
			center += flock.transform.localPosition;
			velocity += flock.rigidbody.velocity;
		}

		flockCenter = center / flockSize;
		flockVelocity = velocity / flockSize;

		Targetchange();

	}


	void Targetchange()
	{
		Screen screen = GameObject.Find("GUI Text").GetComponent<Screen>();

		if (screen.gift == false)
		{
			target = GameObject.FindGameObjectWithTag("Fatherbody").transform;
		}
		else if (screen.gift == true && screen.mission == false)
		{
			target = GameObject.FindGameObjectWithTag("Player").transform;
		}
		else if (screen.gift == true && screen.mission == true)
		{
			target = GameObject.FindGameObjectWithTag("Gift").transform;
		}
	}

}