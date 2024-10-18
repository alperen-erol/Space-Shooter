using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed=3.0f;

    
    [SerializeField]
    private int powerupID;
    //0 for tripleshot
    //1 for speed


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.down * Time.deltaTime*_speed);
        if (transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            if (player != null) {

                if (powerupID == 0)
                {
                    player.TripleShotAcquired();
                }
                else if (powerupID == 1)
                {
                    player.SpeedAcquired();
                }
                

            }

            Destroy(this.gameObject);

        }
    }
}
