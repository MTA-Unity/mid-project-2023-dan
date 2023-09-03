using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

    [SerializeField] private float _speed = -1.0f;

    void FixedUpdate() {
        Vector3 inputVector = new Vector3(_speed, 0, 0);
        transform.position += inputVector;
    }
}
