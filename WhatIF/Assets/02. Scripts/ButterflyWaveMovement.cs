using UnityEngine;

public class ButterflyWaveMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;       // �̵� �ӵ�
    public float waveAmplitude = 0.5f;  // ������ ����
    public float waveFrequency = 1.0f;  // ������ ��
    public float areaRadius = 5.0f;     // �̵� ����

    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        startPosition = transform.position;
        SetNewTargetPosition();
    }

    void Update()
    {
        // ��ǥ ��ġ�� �̵�
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0; // ���� ���⸸ ���
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;

        // ���� ����� ������ �߰�
        float verticalOffset = Mathf.Sin(Time.time * waveFrequency) * waveAmplitude;
        transform.position = new Vector3(transform.position.x, startPosition.y + verticalOffset, transform.position.z);

        // ��ǥ ��ġ�� ���������� ���ο� ��ǥ ����
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            SetNewTargetPosition();
        }
    }

    void SetNewTargetPosition()
    {
        // ������ ��ġ ����
        targetPosition = new Vector3(
            Random.Range(startPosition.x - areaRadius, startPosition.x + areaRadius),
            startPosition.y,
            Random.Range(startPosition.z - areaRadius, startPosition.z + areaRadius)
        );
    }
}

