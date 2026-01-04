using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    private GameObject _gate;
    [SerializeField]
    private Ball _ball;
    [SerializeField]
    private UpdateScoreUI _updateScoreUI;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>() != null)
        {
            _updateScoreUI.AddScore(1);
            Destroy(other.gameObject);
            // Debug.Log("remove: " + other.gameObject.name);
        }
    }
}
