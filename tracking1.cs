using UnityEngine;
using System.Collections;
//функия слежения камеры за положением игрового обьекта.
//Передвигает камеру в зависимости от положения обьекта


//  в функции indikator вычисляются функции пересечения прямой проходящей через две точки нахождения планеты и шатла.
// с прямыми ограничивающими плоскость экрана. Попробовать сделть то-же только через проэкцию прямой на область отображения камеры
public class tracking : MonoBehaviour
{
    [SerializeField] private GameObject track;
	[SerializeField] private GameObject indikator; //переенная для объекта указателя планеты
	private GameObject ind;

	private Vector3 speed, direction;
    public float scor; // мощность двигателя
	//public float speedLimit=1000f; // скоростное ограничение
	public static tracking Instance; // если в другом скрипте нельзя вызвать этот метод
	// т.к. переменная динамическая используеться эта конструкция

	private Camera _camera; // указатель на экземпляр объекта

	void Awake(){
		Instance = this;
	}


	void Start(){
		speed = new Vector3(0f,0f,0); // начальная скорость шатла
		_camera = GetComponent<Camera> ();
		Camera cam = GetComponent<Camera> ();
		Resolution[] raz = Screen.resolutions; // получаем разрешение экрана
		cam.orthographicSize = ((float)raz [0].height); // меняем разрешение чтоб было один к одному
		ind= Instantiate (indikator) as GameObject;
		StartCoroutine (indicator ());
	}
	void Update()
    {
		speed = speed + (gravity.Instance.acceleration + gravity2.Instance.acceleration)*Time.deltaTime;
		 //speed.x = Mathf.Clamp (speed.x, -speedLimit, speedLimit);
		// speed.y = Mathf.Clamp (speed.y, -speedLimit, speedLimit);
        transform.Translate(speed * Time.deltaTime , Space.World); // перемещаем обьект относительно мировых координат
    }
	private IEnumerator indicator(){
		float rast1, rast2,x1=0f,y1=0f,x=0f,y=0f;
		while (true) { //1
			Vector3 napr = gravity.Instance.obj - transform.position; // вектор направленый от обьекта к
			float A2 = napr.y; // коэфф при х в общем уравнении прмой
			float B2 = -napr.x; // коэффициэнт при y
			float C2 = napr.x * gravity.Instance.obj.y - napr.y * gravity.Instance.obj.x;
			napr /= napr.magnitude;// к планете служит направляющим вектром прямой
			if (napr.x < 0) { // если планета находиться слева
				float C1 = -(transform.position.x - ((float)_camera.pixelWidth / 2)); // получаем координаты левого края экрана
				// в общем уравнении прямой B1 == 0 т к прямая параллельна оси oY
				if (B2 != 0) { // прямые пересекаються находим точку пересечения
					x = (-B2 * C1) / B2;
					y = (C1 * A2 - C2) / B2;
				}
			}
			if (napr.x > 0) {
				float x3 = transform.position.x + ((float)_camera.pixelWidth / 2); // получаем координаты левого края экрана
				float A3 = 1f; // находим знак коэффициэнта при X
				// в общем уравнении прямой B1 == 0 т к прямая параллельна оси oY
				float C3 = -x3; // свободный коэффициэнт
				float z = A3 * B2;
				if (z != 0) { // прямые пересекаються находим точку пересечения
					x = (-B2 * C3) / z;
					y = (C3 * A2 - C2 * A3) / z;
				}
			}
			if (napr.y> 0){ // вычисления аналогичные только прямая параллельна Ox
				float C4= -(transform.position.y+ ((float)_camera.pixelHeight/2));
				if(A2!=0){
					x1 = (B2*C4-C2)/A2;
					y1 = (-C4*A2)/A2;
				}
			}
			if(napr.y<0){
				float C4= -(transform.position.y- ((float)_camera.pixelHeight/2));
				if(A2!=0){
					x1 = (B2*C4-C2)/A2;
					y1 = (-C4*A2)/A2;
				}
			}
			Vector3 vek1 = new Vector3(x-transform.position.x,y-transform.position.y,0f);
			// вектор направленый в точку пересечения 
			rast1 = vek1.magnitude; //длинна этого вектора
			Vector3	vec2 = new Vector3(x1-transform.position.x,y1-transform.position.y,0f);
			rast2 = vec2.magnitude;
			if(rast1<rast2) 
			{
				ind.transform.position = new Vector3 (x, y, 0f);
			}
			else {
				ind.transform.position = new Vector3 (x1, y1, 0f);
			}
			yield return 0;
		}
		}
    void OnGUI()
    {
        if (Event.current.button == 1)
        {  // по нажатию левой кнопки мыши
            direction = new Vector3(-shuttle2.Instance.dx, -shuttle2.Instance.dy, 0f); //вектор направленый в сторону указателя мыши
            direction = direction / direction.magnitude; // теперь вектро еденичный
			speed = speed + (direction*scor); // сообщаем ускорение 
        }
    }
	public Vector3 speedSh(){
		return speed;
	}
}
