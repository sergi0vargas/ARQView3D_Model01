using UnityEngine;
using System.Collections;

public class FuckYeah : MonoBehaviour {


    public Transform MainCamera;
    public Transform player;
    private bool flip = false;
    public CameraPivotMovement cp;
    public MouseOrbit ms;
    private bool fpsActive = false;

    void Start()
    {
        MainCamera.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            FlipCamera();
        }
	}

    void FlipCamera()
    {
        if (fpsActive)
        {
            flip = false;
            Flip();

            cp.SetActive();
            ms.SetActive();
            fpsActive = !fpsActive;
        }
        else
        {
            cp.SetActive();
            ms.SetActive();
            fpsActive = !fpsActive;
        }
    }

    void Flip()
    {
        if (flip)
        {
            MainCamera.gameObject.SetActive(false);
            player.gameObject.SetActive(true);
            flip = !flip;
        }
        else
        {
            MainCamera.gameObject.SetActive(true);
            player.gameObject.SetActive(false);
            flip = !flip;
        }
    }
}
