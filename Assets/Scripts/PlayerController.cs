using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    private float xRange = 12f;
    private float zRangeBottom = -0.02f;
    private float zRangeTop = 15f;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void SetTransformPositionX(float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    void SetTransformPositionZ(float z)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, z);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            SetTransformPositionX(-xRange);
        }
        if (transform.position.x > xRange)
        {
            SetTransformPositionX(xRange);
        }

        if (transform.position.z < -zRangeBottom)
        {
            SetTransformPositionZ(-zRangeBottom);
        }
        if (transform.position.z > zRangeTop)
        {
            SetTransformPositionZ(zRangeTop);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }


}
