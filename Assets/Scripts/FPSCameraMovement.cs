using UnityEngine;
using System.Collections;

public class FPSCameraMovement : MonoBehaviour {

	void Update () {

        var directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if(directionVector != Vector3.zero){
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), Space.Self);
        }
	}
}
