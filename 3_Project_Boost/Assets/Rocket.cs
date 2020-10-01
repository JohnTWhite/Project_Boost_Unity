using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody _rigidbody;
    AudioSource _audioSource;


    [SerializeField]  float rcsTime = 100f;
    [SerializeField] float mainTime = 100f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfThrusting();
        Rotate();
    }

    private void Rotate()
    {

        float rotationSpeed = rcsTime * Time.deltaTime;
        _rigidbody.freezeRotation = true; //take manual control of rotation

        if (Input.GetKey(KeyCode.A))
        {
           
            transform.Rotate(Vector3.forward * rotationSpeed);
        };
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed );
        };
        _rigidbody.freezeRotation = false; //release that control
    }

    private void CheckIfThrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(Vector3.up* mainTime);
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Stop();
        }
    }
}
