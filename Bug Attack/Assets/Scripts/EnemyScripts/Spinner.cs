using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] GameObject spinnignObject;
    [SerializeField] float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        spinnignObject.transform.Rotate(0.0f, 0.0f, speed, Space.World);
    }
}
