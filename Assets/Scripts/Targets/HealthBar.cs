using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  public Image foregroundImage;
  public Vector3 offset;

  public void SetHealth(float healthPercent)
  {
    foregroundImage.fillAmount = healthPercent;
    if (healthPercent < 0.2f)
    {
      foregroundImage.color = Color.red;
    }
    else
    {
      foregroundImage.color = Color.green;
    }
  }

  void Update()
  {
    // ��Ѫ�����������
    transform.LookAt(Camera.main.transform);
    transform.Rotate(0, 180, 0);
  }
}
