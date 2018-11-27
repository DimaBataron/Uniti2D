using UnityEngine;
using System.Collections;

/* Скрипт управляющий повотором обьекта в зависимости от положения курсора*/

public class shuttle2 : MonoBehaviour {

	private Vector3 world,direction;
	private float angle;
	public float dx, dy;
	private Quaternion rot;

	public static shuttle2 Instance; // если в другом скрипте нельзя вызвать этот метод
	// т.к. переменная динамическая используеться эта конструкция

	void Awake(){
		Instance = this;
	}
	void Update () {  
		world = Input.mousePosition;  // получаем положение указателя мыши 
		world= Camera.main.ScreenToWorldPoint(world); // преобразуем положение к мировым координатам
		dx = this.transform.position.x - world.x; // приращение вектора относительно обьекта
		dy = this.transform.position.y - world.y; 
		angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg; //угол поворота
		rot = Quaternion.Euler(new Vector3(0, 0, angle + 90));
		this.transform.rotation = rot;
	}

}
