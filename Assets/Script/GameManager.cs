using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject giftbox;
	public GameObject kid;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Screen screen = GameObject.Find("GUI Text").GetComponent<Screen>();

		giftbox.SetActive(false);

		if (screen.mission)
        {
			giftbox.SetActive(true);
        }

	}
}
