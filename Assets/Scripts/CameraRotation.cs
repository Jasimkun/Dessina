using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 5f;    // 회전 속도

    private float yaw = 0f;             // 수평 회전
    private float pitch = 0f;           // 수직 회전

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;                       //마우스 커서를 잠굼
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");                        //마우스의 수평 방향 입력 받아옴
        float mouseY = Input.GetAxis("Mouse Y");                        //마우스의 수직 방향 입력 받아옴

        yaw += mouseX * rotationSpeed * Time.deltaTime;                 // 수평 회전

        pitch -= mouseY * rotationSpeed * Time.deltaTime;               // 수직 회전, -를 곱해 반전

        pitch = Mathf.Clamp(pitch, -90f, 90f);                          // pitch가 90도 이상, -90도 이하로 회전하지 않도록 제한

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);          // 회전 적용
    }
}
