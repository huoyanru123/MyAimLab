using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
  #region 相机相关变量

  public Camera playerCamera;
  public float mouseSensitivity = 2f; // 鼠标灵敏度
  public float maxLookAngle = 170f;   // 最大旋转角度
  public bool invertCamera = false;
  public bool cameraCanMove = true;

  // Internal Variables
  private float yaw = 0.0f;           // 航向角
  private float pitch = 0.0f;         // 俯仰角

  // 准星
  public bool lockCursor = true;
  public bool crosshair = true;
  public Sprite crosshairImage;
  public Color crosshairColor = Color.green;
  public Image crosshairObject;      // 准星图标

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

    if (crosshair)
    {
      crosshairObject.sprite = crosshairImage;
      crosshairObject.color = crosshairColor;
    }
    else
    {
      crosshairObject.gameObject.SetActive(false);
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
  }
}
