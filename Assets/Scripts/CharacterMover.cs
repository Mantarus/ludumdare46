using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public CharacterController2D characterController;
    
    private void Update()
    {
        var moveValue = Input.GetAxisRaw("Horizontal");
        characterController.Move(moveValue, Input.GetButtonDown("Jump"));
    }
}
