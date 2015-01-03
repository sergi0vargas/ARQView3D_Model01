using UnityEngine;
using System.Collections;

public class FuckYeah : MonoBehaviour {


    public Transform camera;
    public Transform player;
    private bool flip = false;

    void Start()
    {
        camera.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Flip();
        }
	}

    void Flip()
    {
        if (flip)
        {
            camera.gameObject.SetActive(false);
            player.gameObject.SetActive(true);
            flip = !flip;
        }
        else
        {
            camera.gameObject.SetActive(true);
            player.gameObject.SetActive(false);
            flip = !flip;
        }
    }
}
