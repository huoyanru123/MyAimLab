using UnityEngine;

public class TargetFManager : MonoBehaviour
{
  public GameObject targetPrefab;
  public Transform player;
  private GameObject currentTarget;

  // ����Ŀ��
  void Start()
  {
    SpawnTarget();
  }

  // Ŀ��ݻٺ�����
  public void TargetDestroyed()
  {
    currentTarget = null;
    SpawnTarget();
  }

  // Ŀ������
  private void SpawnTarget()
  {
    if (currentTarget != null) return;

    float size = Random.Range(0.5f, 2f);
    float speed = Random.Range(0.5f, 1f);
    Vector3 position = player.position + Random.onUnitSphere * Random.Range(5f, 10f);
    position.y = Mathf.Abs(position.y);

    currentTarget = Instantiate(targetPrefab, position, Quaternion.identity);
    currentTarget.GetComponent<TargetFController>().Initialize(size, speed);
  }
}
