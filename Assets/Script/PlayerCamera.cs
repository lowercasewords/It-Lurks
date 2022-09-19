using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private PlayerModel playerModel;
    // Start is called before the first frame update
    void Start()
    {
        playerModel = transform.parent.gameObject.GetComponent<PlayerModel>();
    }
    private void Update()
    {
        playerModel.transform.Rotate(0, Input.GetAxis("Mouse X") * playerModel.RotateSpeed, 0, 0);
    }
}
