using UnityEngine;
using System.Collections;

public class Won : MonoBehaviour {
	void Start () {
	}

	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Application.LoadLevel("Start");
		}
	}
}
