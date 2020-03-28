using System.Collections;
using UnityEngine;

public class MenuCameraScript : MonoBehaviour
{
    public Transform target;
    private float speedMod = 0.2f;
    private Vector3 point;

    void Start()
    {
        point = target.position;
        transform.LookAt(point);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedMod);
    }
}
