using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public CharacterController2D characterController;
    
    private void Update()
    {
        var moveValue = Input.GetAxisRaw("Horizontal");
        var dash = Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift);
        characterController.Move(moveValue, dash,Input.GetButtonDown("Jump"));
    }
}
