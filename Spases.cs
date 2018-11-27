using UnityEngine;
using System.Collections;

/* скрипт выисляющий движение по орбите с осью вращения x y */
public class OrbitMove : MonoBehaviour {
	public float  time;  // период- время за которое совершаеться один полный оборот
	public float x,y; // координаты оси вращения;
	private float  Omega; // угловая скорость- величина характеризующая быстроту вращения выраженная в радианах
	private float  Fi; // текущий угол характеризующий нахождение тела в данный момент времени
	private float  R; // радиус вращения тела
	private float  x0,y0; //текущие координаты тела
	private float  deltaX,deltaY; // расстояния от оси вращения
	private float  NatFi; //Текущий угол тела с осью X

	// Use this for initialization
	void Start () {
		Vector3 startPos = this.transform.position;
		x0 = startPos.x;
		y0 = startPos.y;
		deltaX = x0 - x;
		deltaY = y0 - y;
		R = Mathf.Sqrt (deltaX * deltaX + deltaY * deltaY);
		Omega = (2*Mathf.PI)/time;
		if (deltaX != 0) {
			NatFi = Mathf.Atan (deltaY / deltaX);
		}
		StartCoroutine (resetFI());
	
	}
	void Update () {
		Fi += Omega * Time.deltaTime;
		x0 = R * Mathf.Cos (Fi) + x; // Основная задача кинематики определить положение
		y0 = R * Mathf.Sin (Fi) + y; // тела в любой момент времени. 
		this.transform.position = new Vector3 (x0, y0, 0); //Вычисление положения тела в данный момнет
	}
	private IEnumerator resetFI(){
	while (true) {
			Fi=NatFi;
			yield return new WaitForSeconds(time);
		}
	}


}
