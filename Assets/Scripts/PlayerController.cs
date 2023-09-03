using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [Header("Movement")]
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private float _jumpCooldownTime = 1.0f;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private Rigidbody _rigidBody;
    private float _lastKeyPressTime = -1.0f;
    private int _score = 0;

    // Declare an event to signal the GameManager when the player hits an obstacle.
    public delegate void ObstacleHit();
    public static event ObstacleHit OnObstacleHit;


    private void Start() {

        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.mass = 1.0f;
        _rigidBody.useGravity = true;
    }

    private void Update() {

        // check if pressing jump and able to jump
        if (Input.GetKeyDown(KeyCode.Space) && JumpOffCooldown()) {

            Debug.Log("Pressing!");

            Jump();

            _lastKeyPressTime = Time.time;
        }
    }

    private void OnTriggerEnter(Collider collider) {
        Debug.Log(collider);
        if (collider.CompareTag("ScoreTrigger")) {
            _score += 1;
            _scoreText.text = _score.ToString();
        }
        else if (collider.CompareTag("Obstacle")) {
            // Trigger the event when the player hits an obstacle.
            if (OnObstacleHit != null) {
                OnObstacleHit();
            }
        }
    }

    private bool JumpOffCooldown() {

        return Time.time - _lastKeyPressTime >= _jumpCooldownTime;
    }

    private void Jump() {

        _rigidBody.velocity = new Vector3(0, _jumpForce, 0);
    }
}
