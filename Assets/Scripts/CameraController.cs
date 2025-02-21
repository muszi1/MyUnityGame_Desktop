using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public bool freezeVertical;
    public bool freezeHorizontal;
    private Vector3 positionStore;

    public bool clampPosition;
    public Transform clamMin, clamMax;
    private float halfWidth, halfHeight;
    public Camera theCam;

    // Start is called before the first frame update
    void Start()
    {
        positionStore = transform.position;
        clamMin.SetParent(null);
        clamMax.SetParent(null);

        halfHeight = theCam.orthographicSize;
        halfWidth = theCam.orthographicSize * theCam.aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        if (freezeVertical == true)
        {
            transform.position = new Vector3(transform.position.x, positionStore.y, transform.position.z);
        }
        if (freezeHorizontal == true)
        {
            transform.position = new Vector3(positionStore.x, transform.position.y, transform.position.z);
        }

        if (clampPosition == true)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, clamMin.position.x + halfWidth, clamMax.position.x - halfWidth),
                Mathf.Clamp(transform.position.y, clamMin.position.y + halfHeight, clamMax.position.y - halfHeight),
                transform.position.z);
        }
        if (MovingBackground.instance != null)
        {
            MovingBackground.instance.MoveBackFIX();
        }
    }

   //gizmos hasznalata
    private void OnDrawGizmos()
    {
        if (clampPosition == true)
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawLine(clamMin.position, new Vector3(clamMin.position.x, clamMax.position.y, 0f));
            Gizmos.DrawLine(clamMin.position, new Vector3(clamMax.position.x, clamMin.position.y, 0f));

            Gizmos.DrawLine(clamMax.position, new Vector3(clamMin.position.x, clamMax.position.y, 0f));
            Gizmos.DrawLine(clamMax.position, new Vector3(clamMax.position.x, clamMin.position.y, 0f));
        }
    }

}
