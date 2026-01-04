using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 _start; 
    [SerializeField] private Vector3 _end;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _delayTime = 1f;
    // [SerializeField] private float _rotationSpeed = 90f; 

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true; 
    }

    private IEnumerator Start()
    {
        while (true)
        {
            yield return MoveBetweenPoints(_start, _end);
            yield return new WaitForSeconds(_delayTime);
            yield return MoveBetweenPoints(_end, _start);
            yield return new WaitForSeconds(_delayTime);
        }
    }

    private IEnumerator MoveBetweenPoints(Vector3 from, Vector3 to)
    {
		
        float distance = Vector3.Distance(from, to);
        float moveTime = distance / _speed;
        float time = 0f;

        while (time < moveTime)
        {
            Vector3 newPos = Vector3.Lerp(from, to, time / moveTime);
            _rb.MovePosition(newPos);

            time += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        _rb.MovePosition(to);
    }

    // private void FixedUpdate()
    // {
    //     Quaternion deltaRotation = Quaternion.Euler(Vector3.up * _rotationSpeed * Time.fixedDeltaTime);
    //     _rb.MoveRotation(_rb.rotation * deltaRotation);
    // }

    private void OnDrawGizmos()
    {
       Gizmos.color = Color.red;

		Vector3 startWorld = _start;
		Vector3 endWorld   = _end;

		Gizmos.DrawLine(startWorld, endWorld);
		Gizmos.DrawSphere(startWorld, 0.2f);
		Gizmos.DrawSphere(endWorld, 0.2f);


    }
}