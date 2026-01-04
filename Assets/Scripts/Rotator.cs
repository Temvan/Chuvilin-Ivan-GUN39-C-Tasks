using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 _rotate; 
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    private IEnumerator Start()
    {
        yield return new WaitForFixedUpdate();

        while (true)
        {
            Quaternion deltaRotation = Quaternion.Euler(_rotate * Time.fixedDeltaTime);
            _rb.MoveRotation(_rb.rotation * deltaRotation);

            yield return new WaitForFixedUpdate();
        }
    }
}