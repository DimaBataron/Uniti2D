using UnityEngine;
using System.Collections;

// выстреливание снарядов по нажатию кпопки мыши с заданной скорострельностью
public class shot : MonoBehaviour {

	[SerializeField] private GameObject sperm;
	public float fireRate = 0.3F;
	private float nextFire = 0.0F;
	void Update () {
	if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject clone = Instantiate(sperm, transform.position, transform.rotation) as GameObject;
				}
	}
}
