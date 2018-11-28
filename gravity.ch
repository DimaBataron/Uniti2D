using UnityEngine;
using System.Collections;

/*	Гравитационное взаимодействие объектов
  */
public class gravity : MonoBehaviour {
	public float mas=1f;
	private Vector3 target,obj;  // векторы указывающие координаты цели и координаты объкта
	public Vector3 acceleration; // вектор указывающий направление ускорения


	public static gravity Instance; // если в другом скрипте нельзя вызвать методы из этого класса
	// т.к. переменная динамическая используеться эта конструкция
	
	void Awake(){
		Instance = this;
	}
	// Update is called once per frame
	void Update () {
		target = shuttle2.Instance.pos;
		obj = this.transform.position;
		acceleration = obj - target; // вектор направленный от корабля к планете
		float radius = (acceleration.magnitude); 
		acceleration = acceleration / radius; // единичный вектор направленый в напралении ускорения
		acceleration = acceleration * (mas / radius*radius)*0.005f; // вектор сообщающий ускорение
			// обьекту который попал в радиус действия граитации;
	}
}
