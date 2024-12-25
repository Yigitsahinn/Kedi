
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
    PlayerInput playerInput;
    InputAction moveAction;
    private bool facingright = true;
    private bool isWalking;
    
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }


    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 dir = moveAction.ReadValue<Vector2>();
        transform.position += dir * Time.deltaTime * speed;
        isWalking = dir != Vector3.zero;
        if (facingright && dir.x < 0) 
        {
            Flip();
        }
        else if(!facingright && dir.x > 0)
        {
            Flip();
        }

    }
   
    private void Flip()
    {
        facingright = !facingright;
        transform.Rotate(0, 180 , 0);
    }
    public bool IsWalking()
    {
        return isWalking;
    }
    
}
