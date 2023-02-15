using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform _target;

    // Update is called once per frame
    void Update()
    {
        Vector3 p = _target.position;
        p.z = p.z - 10;
        p.y +=2;
        transform.position = p;
    }
}
