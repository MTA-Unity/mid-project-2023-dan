using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private float _generationInterval = 3;

    private float _lastGenerated = -1.0f;
  
    void FixedUpdate() {
        if (Time.time - _lastGenerated >= _generationInterval) {

            // starting position
            Vector3 vector3 = new Vector3(_obstaclePrefab.transform.position.x,
                                          _obstaclePrefab.transform.position.y + Random.Range(-15.0f, 15.0f),
                                           _obstaclePrefab.transform.position.z);

            GameObject newObstacle = Instantiate(_obstaclePrefab, vector3, _obstaclePrefab.transform.rotation);
            Destroy(newObstacle, 5.5f);

            _lastGenerated = Time.time;
        }
    }
}
