using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _followed;

    private void Start()
    {
        _followed = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Updat
    // e is called once per frame
    private void Update()
    {
        Vector3 newPosition = new Vector3(_followed.position.x, transform.position.y, -10);
        transform.position = newPosition;
    }
}
