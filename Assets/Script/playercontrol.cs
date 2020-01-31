using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalpoint;
    private float powerupstrenght = 15;
    public float speed = 5.0f;
    public GameObject powerupindicator;

    public bool haspowerup = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalpoint = GameObject.Find("Focal point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalpoint.transform.forward * forwardInput * speed * Time.deltaTime);

        powerupindicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            haspowerup = true;
            powerupindicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine((string) PowerupCountdownRoutine());
        }
    }

    IEnumerable PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        haspowerup = false;
        powerupindicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") && haspowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();Vector3 awayFromplayer = collision.gameObject.transform.position - transform.position;
            
            enemyRigidbody.AddForce(awayFromplayer * powerupstrenght, ForceMode.Impulse);
            Debug.Log("player collided with " + collision.gameObject + "with powerup set to " + haspowerup);
        }
    }
}