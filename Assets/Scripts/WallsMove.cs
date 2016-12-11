using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsMove : MonoBehaviour {
    private const float speedNormal = 0.025f;
    private const float speedOtherNormal = 0.3f;
    private const float scaleSpeedNormal = 0.004f;
    private const float cameraZoomNormal = 0.015f;
    private const float cameraZoomFinalNormal = 0.18f;
    private const float speedHard = 0.05f;
    private const float speedOtherHard = 0.3f;
    private const float scaleSpeedHard = 0.008f;
    private const float cameraZoomHard = 0.03f;
    private const float cameraZoomFinalHard = 0.36f;
    private float speed;
    private float speedOther;
    private float scaleSpeed;
    private float cameraZoom;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject floor;
    private Camera camera;
    public GameHandler gameHandler;

	// Use this for initialization
	void Start () {
        switch (GameHandler.difficulty)
        {
            case Difficulty.normal:
                speed = speedNormal;
                speedOther = speedOtherNormal;
                scaleSpeed = scaleSpeedNormal;
                cameraZoom = cameraZoomNormal;
                break;
            case Difficulty.hard:
                speed = speedHard;
                speedOther = speedOtherHard;
                scaleSpeed = scaleSpeedHard;
                cameraZoom = cameraZoomHard;
                break;
            default:
                break;
        }
        Time.timeScale = 1;
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameHandler.finishing)
        {
            switch (GameHandler.difficulty)
            {
                case Difficulty.normal:
                    cameraZoom = cameraZoomFinalNormal;
                    break;
                case Difficulty.hard:
                    cameraZoom = cameraZoomFinalHard;
                    break;
                default:
                    break;
            }
        }
        if (!gameHandler.finished)
        {
            wall1.transform.Translate(new Vector3(speed * speedOther * Time.deltaTime, -speed * Time.deltaTime));
            wall2.transform.Translate(new Vector3(-speed * Time.deltaTime, -speed * speedOther * Time.deltaTime));
            floor.transform.localScale = new Vector3(floor.transform.localScale.x - scaleSpeed * Time.deltaTime, floor.transform.localScale.y - scaleSpeed * Time.deltaTime);
            camera.orthographicSize -= cameraZoom * Time.deltaTime;
        }
    }
}
