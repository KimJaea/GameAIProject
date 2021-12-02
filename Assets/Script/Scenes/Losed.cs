using UnityEngine;
using System.Collections;

public class Losed : MonoBehaviour {
	void Start () {
	}

	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Application.LoadLevel("Start");
		}
	}
}
