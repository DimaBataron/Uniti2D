using UnityEngine;
using System.Collections;
//функия слежения камеры за положением игрового обьекта.
//Передвигает камеру в зависимости от положения обьекта, а также сообщает перемещение камеры, и всех дочерних объектов

public class tracking : MonoBehaviour
{
    [SerializeField] private GameObject track;
    private Vector3 speed, direction;
    private float _dx, _dy;
    public float scor = 0.65f;
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * scor, Space.World); // перемещаем обьект относительно мировых координат
    }
    void OnGUI()
    {
        if (Event.current.button == 1)
        {  // по нажатию левой кнопки мыши
            direction = new Vector3(-shuttle2.Instance.dx, -shuttle2.Instance.dy, 0f); //вектор направленый в сторону указателя мыши
            direction = direction / direction.magnitude; // теперь вектро еденичный
            speed = (speed + direction); // сообщаем ускорение 
        }
    }
}
