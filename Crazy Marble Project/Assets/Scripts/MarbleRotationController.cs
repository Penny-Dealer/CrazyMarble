using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleRotationController : MonoBehaviour
{
    // Start is called before the first frame update
    [field: SerializeField]

    public Vector3 RotationVector { get; private set; }

    void FixedUpdate()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.AddTorque(RotationVector, ForceMode.VelocityChange);
    }
}
