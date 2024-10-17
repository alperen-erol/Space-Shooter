using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float _speed = 4f;
    

    void Start()
    {
        float randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(Random.Range(-9f,9f), 7.5f);

        

    }

    // Update is called once per frame
    void Update()
    {
        float randomX = Random.Range(-8f, 8f);
        transform.Translate(Vector3.down*Time.deltaTime*_speed);
        if (transform.position.y <= -5.4)
        {
            transform.position = new Vector3(Random.Range(-9f, 9f), 7.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        

        
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        

        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null) {

                player.Damage();
            }
            Destroy(this.gameObject);
        }
    }
}
