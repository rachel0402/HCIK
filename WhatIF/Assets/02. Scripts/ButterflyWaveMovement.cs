using UnityEngine;

public class ButterflyWaveMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;       // 이동 속도
    public float waveAmplitude = 0.5f;  // 물결의 높이
    public float waveFrequency = 1.0f;  // 물결의 빈도
    public float areaRadius = 5.0f;     // 이동 범위

    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        startPosition = transform.position;
        SetNewTargetPosition();
    }

    void Update()
    {
        // 목표 위치로 이동
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0; // 수평 방향만 계산
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;

        // 물결 모양의 움직임 추가
        float verticalOffset = Mathf.Sin(Time.time * waveFrequency) * waveAmplitude;
        transform.position = new Vector3(transform.position.x, startPosition.y + verticalOffset, transform.position.z);

        // 목표 위치에 도달했으면 새로운 목표 설정
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            SetNewTargetPosition();
        }
    }

    void SetNewTargetPosition()
    {
        // 랜덤한 위치 설정
        targetPosition = new Vector3(
            Random.Range(startPosition.x - areaRadius, startPosition.x + areaRadius),
            startPosition.y,
            Random.Range(startPosition.z - areaRadius, startPosition.z + areaRadius)
        );
    }
}

