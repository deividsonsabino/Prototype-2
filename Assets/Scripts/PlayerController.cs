using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float speed = 10.0f;
    public float xRange = 10.0f;

    public GameObject projectilePrefab;

    public float zMin;
    public float zMax;

    public Transform projectileSpawnPoint;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (transform.position.z < zMin)
            transform.position = new Vector3(transform.position.x, transform.position.y, zMin);

        if (transform.position.z > zMax)
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
        }
    }
}
