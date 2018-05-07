using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float speed = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
        transform.position = pos + Vector3.up * Time.deltaTime * speed;

	}
}
