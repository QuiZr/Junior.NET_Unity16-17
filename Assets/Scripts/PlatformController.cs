using UnityEngine;
using System.Collections;
using System.Linq;

/// <summary>
/// This whole class will be splitted into two separate ones.
/// PlatformController will be responsible for actually moving the 
/// character but not for receiving input.
/// </summary>
public class PlatformController : MonoBehaviour
{
    // Public variables are shown in Unity's inspector and can be edited through it at any time
    [Tooltip("Max horizontal movement speed")]
    public int maxMoveSpeed = 5;

    public Transform groundCheck;

    // Same goes for private variables with SerializeField tag.
    [Tooltip("Force applied in y+ direction at jump")]
    [SerializeField]
    private int jumpForce = 40;

    // Rigibody tells Unity to enable physics on this game object.
    private Rigidbody2D thisRigidbody;

    // Use this for initialization (executes at object spawn).
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Will Sets acceleration of a character by moveValue * moveSpeed and can make it jump.
    /// Gravity, collisions etc. are handled by Unity's physics engine (Box2D).
    /// </summary>
    /// <param name="moveValue">Multiplier of max speed</param>
    /// <param name="wantToJump">True = jump if able to</param>
    public void Move(float moveValue, bool wantToJump)
    {
        bool canJump = false;

        // Make a raycast at groundCheck GameObject position and check
        // if any of the objects that we hit are'nt player.
        // If they aren't player then they are probably ground so we can jump.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.1f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                canJump = true;
                break;
            }
        }
        // We could also use Linq to do this but we haven't cover it yet.
        // Example:
        //canJump = colliders.Any((c) => { return c.gameObject != gameObject; });

        if (wantToJump && canJump)
        {
            thisRigidbody.AddForce(new Vector2(0, jumpForce));
        }

        // Horizontal movement
        Vector2 currentVelocity = thisRigidbody.velocity;
        Vector2 newVelocity = new Vector2(moveValue * maxMoveSpeed, currentVelocity.y);
        thisRigidbody.velocity = newVelocity;
    }
}
