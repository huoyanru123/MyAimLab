using UnityEngine;

public class TargetFController : MonoBehaviour
{
  private float health;
  private float maxHealth;
  public float speed = 0.5f;

  private bool isClockWise = true;
  private bool isChangeDir = true;

  private Transform player;
  private Vector3 axis = Vector3.up;

  private float timer = 0f;
  private float intervalChangeDir = 0.5f;

  public GameObject healthBarPrefab;
  private GameObject healthBarInstance;
  private HealthBar healthBar;

  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    UpdateChangeDirInterval();

    // 创建并初始化血条
    healthBarInstance = Instantiate(healthBarPrefab, transform.position + new Vector3(0, 2, 0), Quaternion.identity, transform);
    healthBar = healthBarInstance.GetComponent<HealthBar>();
  }

  public void Initialize(float size, float moveSpeed)
  {
    transform.localScale = new Vector3(size, size, size);
    maxHealth = health = size * 2000; // 假设血量与大小相关
    speed = moveSpeed;
  }

  void Update()
  {
    MoveAround();
    timer += Time.deltaTime;
    ChangeDir();

    // 更新血条位置和状态
    if (healthBar != null)
    {
      healthBar.SetHealth(health / maxHealth);
    }
  }

  private void UpdateChangeDirInterval()
  {
    if (Random.Range(0f, 1f) <= 0.5f)
    {
      isChangeDir = false;
      intervalChangeDir = 1.2f;
    }
    else
    {
      isChangeDir = true;
      if (Random.Range(0f, 1f) <= 0.3f)
        intervalChangeDir = Random.Range(0.2f, 1.2f);
      else
        intervalChangeDir = Random.Range(1.2f, 3f);
    }
  }

  private void ChangeDir()
  {
    if (!isChangeDir)
      return;
    else
    {
      if (timer > intervalChangeDir)
      {
        timer = 0f;
        isClockWise = !isClockWise;
        UpdateChangeDirInterval();
      }
    }
  }

  private void MoveAround()
  {
    float direction = isClockWise ? 1 : -1;
    transform.RotateAround(player.position, axis, direction * speed * Time.deltaTime * 50);
  }

  public void TakeDamage(float damage)
  {
    health -= damage;
    if (health <= 0)
    {
      Destroy(gameObject);
      FindObjectOfType<TargetFManager>().TargetDestroyed();
    }
  }
}
