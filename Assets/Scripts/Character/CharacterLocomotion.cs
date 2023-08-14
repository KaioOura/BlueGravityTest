using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Vector2 Move;
    
    [SerializeField]
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MakeMovement();
    }

    public void MoveInput(Vector2 value)
    {
        Move = value;
    }

    private void MakeMovement()
    {
        _rigidbody2D.velocity = Move.normalized * speed;
    }
}
