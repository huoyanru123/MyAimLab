using UnityEngine;

public class GunFollowCamera : MonoBehaviour
{
  public Transform cameraTransform; // �����

  void ChangeOrientation()
  {
    Vector3 cameraEulerAngles = cameraTransform.eulerAngles;

    // TODO: ǹе�޷����ϻ�����
    transform.eulerAngles = cameraEulerAngles - new Vector3(0, 100, 0);
    // Debug.Log(transform.eulerAngles);
  }

  void Update()
  {
    ChangeOrientation();
  }
}
