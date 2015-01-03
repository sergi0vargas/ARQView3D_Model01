using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour {

    public Transform target;
    public float distancia = 50;
    public float multiplicadorDistancia = 10;
    public float camSpeed = 10;

    public float xSpeed = 200;
    public float ySpeed = 100;

    public float yMinLimit = -20;
    public float yMaxLimit = 80;

    private float x = 0;
    private float y = 0;

    public bool camaraActiva = false;

	// Use this for initialization
	void Start () {
        Vector3 angulo = transform.eulerAngles;
        x = angulo.y;
        y = angulo.x;

        if (GetComponent<Rigidbody>())
		    GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (target && camaraActiva)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distancia) + target.position;

            distancia = distancia + Input.GetAxis("Mouse ScrollWheel") * multiplicadorDistancia;

            transform.rotation = rotation;
            transform.position = position;

            //ARREGLAR DESPLASAMIENTO LENTO
            //transform.position = Vector3.Slerp(transform.position, position, camSpeed*Time.deltaTime);

        }
	}

    static float ClampAngle(float angulo, float min, float max)
    {
        if (angulo < -360)
            angulo += 360;
        if (angulo > 360)
            angulo -= 360;
        
        return Mathf.Clamp(angulo,min,max);
    }

    public void SetActive()
    {
        camaraActiva = !camaraActiva;
    }

}
