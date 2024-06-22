using UnityEngine;

public class GunFollowCamera : MonoBehaviour
{
  public Transform cameraTransform; // 主相机

  void ChangeOrientation()
  {
    Vector3 cameraEulerAngles = cameraTransform.eulerAngles;

    // TODO: 枪械无法向上或向下
    transform.eulerAngles = cameraEulerAngles - new Vector3(0, 100, 0);
    // Debug.Log(transform.eulerAngles);
  }

  void Update()
  {
    ChangeOrientation();
  }
}
