using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;

    public EventTriggerController acceleration;
    public EventTriggerController deceleration;

    [SerializeField] private float _moveForce = 200f;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _wheelRotationSpeed = 30f;
    [SerializeField] List<GameObject> wheels = new List<GameObject>();

    [SerializeField] private TextMeshProUGUI _coinCounter;
    private int count;

    float axis = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //Physic Move
    void FixedUpdate()
    {
        float currentSpeed = rb.velocity.magnitude;

        if (acceleration.pointerDown && rb.velocity.magnitude < _maxSpeed)
        {
            rb.AddForce(Vector2.left * _moveForce);
            axis = 1;
        }

        if(deceleration.pointerDown && rb.velocity.magnitude < _maxSpeed)
        {
            rb.AddForce(Vector2.right * _moveForce);
            axis = -1;
        }

        foreach (GameObject whell in wheels)
        {
            whell.transform.Rotate(axis * Vector3.forward, currentSpeed * _wheelRotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("coin"))
        {
            count++;
            _coinCounter.text = count.ToString();
            Destroy(collision.gameObject);
        }
    }
}


