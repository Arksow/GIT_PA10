using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    float flyForce = 5f; // Adjust this value to control the upward flying force.
    float deathHeight = -5f;
    float maxHeight = 3.5f;
    Rigidbody rb;

    [SerializeField] GameObject duck;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 5f)
        {
            thisAnimation.Play();
            FlyUpwards();
        }

        if (transform.position.y < deathHeight)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager.thisManager.GameOver();
        }
    }

    bool triggeredPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PointTrigger") && !triggeredPoints)
        {
            triggeredPoints = true;
            GameManager.thisManager.UpdateScore(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PointTrigger") && triggeredPoints)
        {
            triggeredPoints = false;
        }
    }

    void FlyUpwards()
    {
        rb.AddForce(Vector3.up * flyForce, ForceMode.Impulse);
    }

    private void Die()
    {
        GameManager.thisManager.GameOver();
    }
}
