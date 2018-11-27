using UnityEngine;
using System.Collections;

/* Скрипт управляющий повотором обьекта в зависимости от положения курсора
 * и сообщающий ускорение в напралении указателя курсора */

public class shuttle2 : MonoBehaviour {
	private Vector3 world,direction,speed;
	private float dx,dy,angle;
	private Quaternion rot;
	void Update () {  
		world = Input.mousePosition;  // получаем положение указателя мыши 
		world= Camera.main.ScreenToWorldPoint(world); // преобразуем положение к мировым координатам
		dx = this.transform.position.x - world.x; // приращение вектора относительно обьекта
		dy = this.transform.position.y - world.y; 
		angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg; //угол поворота
		rot = Quaternion.Euler(new Vector3(0, 0, angle + 90));
		this.transform.rotation = rot;
		transform.Translate (speed*Time.deltaTime,Space.World);
	}
	 void OnGUI()
	{
		if (Event.current.button == 1) {  // по нажатию левой кнопки мыши
			direction = new Vector3 (-dx, -dy, 0); //вектор направленый в сторону указателя мыши
			direction = direction / direction.magnitude; // теперь вектро еденичный
			speed=(speed+direction); // сообщаем ускорение 
		}
	}

}
