using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animation.Rigging;

public class CharacterAiming : MonoBehaviour
{
    public float turnSpeed = 15;
    public float aimDuration = 0.3f;
    Camera mainCamera;
    Rig aimLayer;

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }

    void Update(){
        if(Input.GetMouseButton(1)) {
            aimLayer.weight += Time.deltaTime / aimDuration;
        } else {
            aimLayer.weight -= Time.deltaTime / aimDuration;
        }
    }
}
