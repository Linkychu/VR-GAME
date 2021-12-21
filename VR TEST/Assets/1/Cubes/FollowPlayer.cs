using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public float moveSpeed = 0.1f;
    public float SmoothLook = 30f;
    private Rigidbody rb;
    private Vector3 movement;
    private GameObject player;
    private GameManager _gameManager;

    private isFreezable _freezable;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        target = player.GetComponent<Transform>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        moveSpeed = moveSpeed + (_gameManager.waveCount / 2 );

        _freezable = GetComponent<isFreezable>();


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        
        Quaternion OriginalRot = transform.rotation;
        transform.LookAt(target);
        Quaternion NewRot = transform.rotation;
        transform.rotation = OriginalRot;
        transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, SmoothLook * Time.deltaTime);
        
        direction.Normalize();
        movement = direction;
        moveCharacter(movement);
    }
    private void FixedUpdate() 
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition((Vector3) transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
