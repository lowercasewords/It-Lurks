using Unity;
using UnityEngine;
using UnityEditor;

public class PlayerModel : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField]
    private float _walkSpeed = 2f;
    /** <summary> Moving right, left, and backwards </summary> */
    [SerializeField]
    private float _sideSpeed = 1f;
    [SerializeField]
    private float _runSpeed = 5f;
    [SerializeField]
    private float _rotateSpeed = 20f;
    public float RotateSpeed { get { return _rotateSpeed; } }
    //[SerializeField]
    //private float _walkSpeedLim = 0.3f;
    //[SerializeField]
    //private float _runSpeedLim = 3f;
   
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
        Debug.Log(playerRigidbody.velocity.magnitude);
    }
    private void Move()
    {
        Debug.Log("Move is called");
        float horizSpeed = Input.GetAxis("Horizontal");
        float vertSpeed = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(
                horizSpeed,
                0,
                vertSpeed);
        if(force.magnitude > 1)
        {
            force /= force.magnitude;
        }
        force *= Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;
        Vector3 localVel = transform.InverseTransformDirection(playerRigidbody.velocity);
        localVel = force;
        playerRigidbody.velocity = transform.TransformDirection(localVel);
    }
}