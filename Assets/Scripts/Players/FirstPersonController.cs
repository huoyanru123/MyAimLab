using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
  #region 相机相关变量

  public Camera playerCamera;
  public float mouseSensitivity = 0.8f; // 鼠标灵敏度
  public float maxLookAngle = 170f;   // 最大旋转角度
  public bool invertCamera = false;
  public bool cameraCanMove = true;

  // Internal Variables
  private float yaw = 0.0f;           // 航向角
  private float pitch = 0.0f;         // 俯仰角
  
  public bool lockCursor = true;

  #endregion

  private void Awake()
  {
    //crosshairObject = GetComponentInChildren<Image>();
  }

  private void Start()
  {
    if (lockCursor)
    {
      Cursor.lockState = CursorLockMode.Locked;
    }
  }

  private void Update()
  {
    #region Camera

    // 视角移动
    if (cameraCanMove)
    {
      yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;

      if (!invertCamera)
      {
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
      }
      else
      {
        pitch += mouseSensitivity * Input.GetAxis("Mouse Y");
      }

      // 将视角限制在范围内
      pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

      transform.localEulerAngles = new Vector3(0, yaw, 0);
      playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
    }

    #endregion

    #region Shoot
    if (Input.GetButton("Fire1"))
    {
      Shoot();
    }
    #endregion
  }

  private void Shoot()
  {
    RaycastHit hit;
    float baseDamage = 2.5f;
    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
    {
      TargetFController target = hit.transform.GetComponent<TargetFController>();
      if (target != null)
      {
        // 计算交点到圆柱体中心的距离
        float distance = Vector3.Distance(hit.point, target.transform.position);
        // 根据距离计算伤害，距离越近，伤害越高
        float damage = baseDamage*(Mathf.Max(0,5-distance)*0.05f+1f);
        target.TakeDamage(damage);
      }
    }
  }
}
