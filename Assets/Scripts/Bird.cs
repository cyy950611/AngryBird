using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	private bool isClick = false;
	
	public float maxDis = 1.2f;

    [HideInInspector]
	public SpringJoint2D sp; 

	private Rigidbody2D rg;

	public LineRenderer rightLine;
	public Transform rightPos;
	public LineRenderer leftLine;
	public Transform leftPos;

    public GameObject boom;
	// Use this for initialization
	private void Awake() {
		sp = GetComponent<SpringJoint2D>();
		rg = GetComponent<Rigidbody2D>();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isClick){
			transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position += new Vector3(0,0, -Camera.main.transform.position.z);
			if(Vector3.Distance(transform.position, rightPos.position) > maxDis){
				//进行位置限定
				Vector3 pos = (transform.position - rightPos.position).normalized; //单位向量化
				pos *= maxDis;
				transform.position = pos + rightPos.position;
			}
			Line();
		}
	}

	//鼠标按下
	private void OnMouseDown() {
		isClick = true;
		rg.isKinematic = true;
	}

	//鼠标抬起
	private void OnMouseUp() {
		isClick = false;
		rg.isKinematic = false;
		Invoke("Fly",0.1f);
        //禁用划线组件
        rightLine.enabled = false;
        leftLine.enabled = false;
        
	}

	void Fly(){
		sp.enabled = false;
        Invoke("Next", 3);
	}

	void Line(){
        rightLine.enabled = true;
        leftLine.enabled = true;

		rightLine.SetPosition(0, rightPos.position);
		rightLine.SetPosition(1, transform.position);

		leftLine.SetPosition(0, leftPos.position);
		leftLine.SetPosition(1, transform.position);
	}

    /// <summary>
    /// 下一只小鸟飞出
    /// </summary>
    void Next() {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameManager._instance.NextBird();
    }
}
