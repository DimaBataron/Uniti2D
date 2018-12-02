using UnityEngine;
using System.Collections;

public class vagina: MonoBehaviour {

	public static GameObject previous; // указатель на предыдущего врага
	public static GameObject subsequent; // указатель на следующего врага
	public static float speed;  // скороть движения противника
	private static int state;

	private Vector3  move,target;
	void Start () {
		previous = null;
		subsequent = null;
		speed = 100f;
	 	state = (int)Random.Range (0, 1); // состояние противника
		int pos = Random.Range (0, 3); // с какой стороны появится противник 
		// 0- сверху   1 -снизу     2-слева     3- справа
		float x=2500f, y=2500f; // используеться для уточнения положения противника
		if (pos == 0) { // сверху
			this.transform.position = new Vector3 (Random.Range(-x,x),y, 1f);
		} 
		else
		{
			if (pos == 1) { //снизу
				this.transform.position = new Vector3 (Random.Range (-x, x),-y , 1f);
			} 
			else 
			{
				if (pos == 2) { // слева
				this.transform.position = new Vector3(-x,Random.Range(-y,y),1f);
			}
				else this.transform.position = new Vector3(x,Random.Range(-y,y),1f);  // справа
			}
		}
	}
	void Update () {
	if (state == 0) {         // атакует персонажа
			target = shuttle2.Instance.pos;
		} else               // атакует планету
			target = gravity.Instance.pos;
		move =  target - this.transform.position; // вектор напраленый на цель
		move = move / move.magnitude; // единичный вектор направленный на цель
		move = move * speed * Time.deltaTime; 
		transform.Translate (move.x, move.y, 0f); // перемещаеться в сторону цели
	}
	public GameObject previousNew{
		get{ return previous;}
		set{ previous = value;}
	}
	public GameObject subsequentNew{
		get{ return subsequent;}
		set{ subsequent = value;}
	}
}
