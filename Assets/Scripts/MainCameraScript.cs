using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    private GameObject steer;
    private Vector3 defaultPos;

    private void Start()
    {
        steer = GameObject.Find("PlayerSteer");
        defaultPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = defaultPos;

        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        Vector3 dir = (transform.TransformPoint(defaultPos) - steer.transform.position).normalized;

        RaycastHit hit;        
        if (Physics.Raycast(steer.transform.position, dir, out hit, Mathf.Infinity, layerMask))
        {
            float dist = Vector3.Distance(steer.transform.position, transform.TransformPoint(defaultPos));
            if(hit.distance < dist) {
                Vector3 newPosition = steer.transform.position + dir * (hit.distance - 0.5f);
                Debug.DrawLine(steer.transform.position, newPosition);
                transform.position = newPosition;
            }
        }
    }
}
