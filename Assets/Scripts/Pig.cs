using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

	public float maxSpeed = 6;
	public float minSpeed = 3;

	private SpriteRenderer render;

	public Sprite hurtPig;

	public GameObject boom;

    public GameObject score;

    public bool isPig = false;

	private void Awake() {
		render = GetComponent<SpriteRenderer>();	
	}

	private void OnCollisionEnter2D(Collision2D other) {
		print("当前速度为" + other.relativeVelocity.magnitude);
		if(other.relativeVelocity.magnitude > maxSpeed){
			Dead();
		} else if(other.relativeVelocity.magnitude > minSpeed && other.relativeVelocity.magnitude < maxSpeed){
			render.sprite = hurtPig;
		}
	}

	void Dead(){
        if (isPig) {
            GameManager._instance.pig.Remove(this);
        }
		Destroy(gameObject);
		Instantiate(boom, transform.position, Quaternion.identity);
        GameObject go = Instantiate(score, transform.position + new Vector3(0,0.5f,0), Quaternion.identity);
        Destroy(go, 1.5f);
	}
}
