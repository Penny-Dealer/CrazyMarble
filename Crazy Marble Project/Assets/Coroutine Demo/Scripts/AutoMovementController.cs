using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovementController : MonoBehaviour
{
    private Rigidbody _rigidBody;

    [field: SerializeField]
    public Vector3 StartPosition { get; private set; }
    [field: SerializeField]
    public Vector3 EndPosition { get; private set; }
    [field: SerializeField]
    public float Duration { get; private set; }
    [field: SerializeField]
    public float Delay { get; private set; }
    // Start is called before the first frame update
    public bool IsMoving = false;
    public float StartedMovingAt = 0;
    public bool IsMovingback = false;
    public float StartedMovingbackAt = 0;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        StartCoroutine(HandleMovement());
        transform.position = StartPosition;
    }

    private IEnumerator HandleMovement()
    {
        while (true)
        {
            yield return new WaitForSeconds(Delay);
            IsMoving = true;
            StartedMovingAt = Time.time;
            yield return new WaitForSeconds(Duration);
            IsMoving = false;
            yield return new WaitForSeconds(Delay);
            IsMovingback = true;
            StartedMovingbackAt = Time.time;
            yield return new WaitForSeconds(Duration);
            IsMovingback = false;
        }
    }

    void FixedUpdate()
    {
        if (IsMoving) { 

        float timeElapsed = Time.time - StartedMovingAt;
        float percentComplete = Mathf.Clamp01(timeElapsed / Duration);
        Vector3 target = Vector3.Lerp(StartPosition, EndPosition, percentComplete);
        _rigidBody.MovePosition(target);
        }
        else if (IsMovingback)
        {
            float timeElapsed = Time.time - StartedMovingbackAt;
        float percentComplete = Mathf.Clamp01(timeElapsed / Duration);
        Vector3 target = Vector3.Lerp(EndPosition, StartPosition, percentComplete);
        _rigidBody.MovePosition(target);

        }
    }

       
}
