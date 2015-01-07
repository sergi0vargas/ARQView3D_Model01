using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour {

    public Transform target;


    public float distancia = 60;
    public float distanciaMax = 80;
    public float distanciaMin = 50;
    private float lastDist = 0;


    public float multiplicadorDistancia = 10;
    public float camSpeed = 10;
    public float pinchSpeed;

    public float xSpeed = 200;
    public float ySpeed = 100;

    public float yMinLimit = -20;
    public float yMaxLimit = 80;

    private float x = 0;
    private float y = 0;

    public bool camaraActiva = false;

    private Touch touch;

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
            if (Application.platform != RuntimePlatform.Android || Application.platform != RuntimePlatform.IPhonePlayer)
            {
                if (Input.GetMouseButton(0))
                {
                    x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                    y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                }
                y = ClampAngle(y, yMinLimit, yMaxLimit);

                Quaternion rotation = Quaternion.Euler(y, x, 0);
                Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distancia) + target.position;
                
                var temp = distancia + Input.GetAxis("Mouse ScrollWheel") * multiplicadorDistancia;
                distancia = Mathf.Clamp(temp, distanciaMin, distanciaMax);
                //distancia = distancia + Input.GetAxis("Mouse ScrollWheel") * multiplicadorDistancia;

                //ARREGLAR DESPLASAMIENTO LENTO
                //transform.position = Vector3.Slerp(transform.position, position, camSpeed*Time.deltaTime);
                transform.rotation = rotation;
                transform.position = position;
            }
            else
            {
                if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    //One finger touch does orbit
                    touch = Input.GetTouch(0);

                    x += touch.position.x * xSpeed * 0.02f;

                    y -= touch.position.y * ySpeed * 0.02f;

                }

                if (Input.touchCount > 1 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved))
                {
                    //Two finger touch does pinch to zoom
                    var touch1 = Input.GetTouch(0);

                    var touch2 = Input.GetTouch(1);

                    distancia = Vector2.Distance(touch1.position, touch2.position);

                    if (distancia > lastDist)
                    {
                        distancia += Vector2.Distance(touch1.deltaPosition, touch2.deltaPosition) * pinchSpeed / 10;

                    }
                    else
                    {
                        distancia -= Vector2.Distance(touch1.deltaPosition, touch2.deltaPosition) * pinchSpeed / 10;
                    }
                    lastDist = distancia;

                }
 
            }
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