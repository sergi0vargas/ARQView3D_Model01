using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraPivotMovement : MonoBehaviour {

	public List<Transform> wayPoints;
	public int actualWayPoint = 0; 

	public Transform pivot;

	//CAMBIAR POR CORUTINAS
	private Transform target;
	public float speed = 10;

    public bool camaraActiva = true;

	void Start(){
			
		/*GameObject[] ga = GameObject.FindGameObjectsWithTag ("WayPoint");

		foreach (GameObject ob in ga) {
			wayPoints.Add(ob.transform);
		}*/

		target = transform;
	}

	public void NextWayPoint(){
		actualWayPoint++;
		if (actualWayPoint >= wayPoints.Count)
			actualWayPoint = 0;

		target = wayPoints [actualWayPoint];
	}

	public void PreviousWayPoint(){
		actualWayPoint--;
		if (actualWayPoint < 0)
			actualWayPoint = wayPoints.Count-1;
		
		target = wayPoints [actualWayPoint];
	}

	void Update(){

        if (camaraActiva)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
            //OJO
            transform.LookAt(pivot);
        }
	}
    public void SetActive()
    {
        camaraActiva = !camaraActiva;
    }

}
