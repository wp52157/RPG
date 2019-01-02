using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float distance;
    private Transform player;
    Vector3 offest;
	// Use this for initialization
	void Start () {
        offest = transform.forward * distance;
        player = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position =Vector3.Lerp(transform.position, player.position - offest,0.1f);
	}
}
