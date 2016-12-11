using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsMove : MonoBehaviour {
    private float speed = 0.05f;
    private float speedOther = 0.3f;
    private float scaleSpeed = 0.008f;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject floor;
    private Camera camera;
    public GameHandler gameHandler;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameHandler.finished)
        {
            wall1.transform.Translate(new Vector3(speed * speedOther * Time.deltaTime, -speed * Time.deltaTime));
            wall2.transform.Translate(new Vector3(-speed * Time.deltaTime, -speed * speedOther * Time.deltaTime));
            floor.transform.localScale = new Vector3(floor.transform.localScale.x - scaleSpeed * Time.deltaTime, floor.transform.localScale.y - scaleSpeed * Time.deltaTime);
            camera.orthographicSize -= 0.03f * Time.deltaTime;
        }
    }
}
