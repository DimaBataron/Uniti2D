using UnityEngine;
using System.Collections;

/* создание и полет снарядов  */
public class projectile : MonoBehaviour {
	
	public float timelife = 3f; // время жизни снаряда 
	public float speed = 10;  // скорость движения снаряда
	private Vector3 trans;
	// Use this for initialization
	void Start () {
		timelife += Time.time;
		trans = tracking.Instance.speedSh(); // получаем скорость корабля
		trans *= Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(trans.x,trans.y, trans.z,Space.World);
		transform.Translate (0f, speed * Time.deltaTime;, 0f);
		if (Time.time > timelife) { // проверяем просуществовал ли снаряд заданное время
			Destroy(this.gameObject);
		}
	
	}
}
