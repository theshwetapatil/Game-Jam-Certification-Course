using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{
    public float acceleration = 0.1f;
    public float friction = 0.25f;
    public float maxSpeed = 1f;
    public float steerSensitivity = 1f;

    public float raycastLength = 2f;

    public LayerMask wallLayerMask;
    
    private float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Steer(Input.GetAxis("Horizontal"));

        if(Input.GetButton("Fire1"))
        {
            Accelerate(1f);
        }
        else
        {
            ApplyFriction();
        }

        ApplySpeed();
        CollisionCheck();
    }

    private void Accelerate(float amount)
	{
        speed += acceleration * amount * Time.deltaTime;
        speed = Mathf.Min(speed, maxSpeed);
	}

    public void Steer(float amount)
	{
        this.transform.rotation *= Quaternion.AngleAxis(amount * steerSensitivity, this.transform.up);
	}

    private void ApplyFriction()
	{
        speed -= friction * Time.deltaTime;
        speed = Mathf.Max(speed, 0);
	}

    public void ApplySpeed()
    {
        this.transform.position += this.transform.forward * speed * Time.deltaTime; 
    }

    private void CollisionCheck()
	{
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        
        RaycastHit hitOut;

        if (Physics.Raycast(ray, out hitOut, raycastLength, wallLayerMask.value))
        {
            Vector3 newDirection = Vector3.Reflect(this.transform.forward, hitOut.normal);

            this.transform.rotation = Quaternion.LookRotation(newDirection, this.transform.up);
        }
	}
}
