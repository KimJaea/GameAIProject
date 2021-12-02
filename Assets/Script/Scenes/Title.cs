using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
	private int page;
	private GUIText s1;
	private GUIText s2;

	void Start () {
		page = 1;

		s1 = GameObject.Find("Selection1").GetComponent<GUIText>();
		s1.material.color = Color.yellow;
		s2 = GameObject.Find("Selection2").GetComponent<GUIText>();
		s2.material.color = Color.white;

	}

	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			s1.material.color = Color.yellow;
			s2.material.color = Color.white;
			page = 1;
		} else if (Input.GetKey (KeyCode.D)) {
			s1.material.color = Color.white;
			s2.material.color = Color.yellow;
			page = 2;
		} else if (Input.GetKey (KeyCode.Space)) {
			if(page == 1)
				Application.LoadLevel("How");
			else if(page == 2)
				Application.LoadLevel("Main");
		}
	}
}
