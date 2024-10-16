using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.1f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("spawn manager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        calculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            fireLaser();
        }
    }
    void calculateMovement()
    {

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);


        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(horizontalInput, verticalInput) * Time.deltaTime * _speed);

        if (transform.position.x > 11.3 || transform.position.x < -11.3)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y);
        }
    }
    void fireLaser()
    {

        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, new Vector3(transform.position.x, (transform.position.y + 0.8f)), Quaternion.identity);
    }
    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
            _spawnManager.onPlayerDeath();
            Destroy(this.gameObject);
        }
    }
}
