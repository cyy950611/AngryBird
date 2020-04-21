using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

	public float maxSpeed = 10;
	public float minSpeed = 5;

	private SpriteRenderer render;

	public Sprite hurtPig;

	private void Awake() {
		render = GetComponent<SpriteRenderer>();	
	}

	private void OnCollisionEnter2D(Collision2D other) {
		print("当前速度为" + other.relativeVelocity.magnitude);
		if(other.relativeVelocity.magnitude > maxSpeed){
			Destroy(gameObject);
		} else if(other.relativeVelocity.magnitude > minSpeed && other.relativeVelocity.magnitude < maxSpeed){
			render.sprite = hurtPig;
		}
	}
}
