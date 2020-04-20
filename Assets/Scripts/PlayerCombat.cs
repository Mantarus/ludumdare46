using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator characterAnimator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            characterAnimator.SetTrigger("Attack");
        }
    } 
}
