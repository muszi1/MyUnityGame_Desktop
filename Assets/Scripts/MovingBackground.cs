using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{

    public static MovingBackground instance;
    private void Awake()
    {
        instance = this;
    }
    private Transform Cam;
    public Transform sky, TreeLine;
    [Range(0f, 1f)]
    public float BgSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Cam=FindFirstObjectByType<Camera>().transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }

    public void MoveBackFIX()
    {
        sky.position = new Vector3(Cam.position.x, Cam.position.y, sky.position.z);

        TreeLine.position = new Vector3(
            Cam.position.x * BgSpeed,
            Cam.position.y,
            TreeLine.position.z);
    }
}
