using UnityEngine;

public class DoorTriggerByTag : MonoBehaviour
{
    public string leftDoorTag = "LeftDoor"; // 왼쪽 문 태그
    public string rightDoorTag = "RightDoor"; // 오른쪽 문 태그
    public float openDistance = 0.7f; // 문이 열리는 거리
    public float openSpeed = 2.0f; // 문 열리는 속도

    private GameObject leftDoor;
    private GameObject rightDoor;
    private Vector3 leftDoorClosedPosition;
    private Vector3 leftDoorOpenPosition;
    private Vector3 rightDoorClosedPosition;
    private Vector3 rightDoorOpenPosition;
    private bool isOpening = false;

    void Start()
    {
        // 태그를 통해 문 오브젝트 찾기
        leftDoor = GameObject.FindWithTag(leftDoorTag);
        rightDoor = GameObject.FindWithTag(rightDoorTag);

        if (leftDoor != null)
        {
            leftDoorClosedPosition = leftDoor.transform.position;
            leftDoorOpenPosition = new Vector3(leftDoorClosedPosition.x - openDistance, leftDoorClosedPosition.y, leftDoorClosedPosition.z); // x만 이동
            Debug.Log($"Left Door Positions: Closed = {leftDoorClosedPosition}, Open = {leftDoorOpenPosition}");
        }

        if (rightDoor != null)
        {
            rightDoorClosedPosition = rightDoor.transform.position;
            rightDoorOpenPosition = new Vector3(rightDoorClosedPosition.x + openDistance, rightDoorClosedPosition.y, rightDoorClosedPosition.z); // x만 이동
            Debug.Log($"Right Door Positions: Closed = {rightDoorClosedPosition}, Open = {rightDoorOpenPosition}");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isOpening = true;
            Debug.Log("Trigger Enter: isOpening = " + isOpening);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isOpening = false;
            Debug.Log("Trigger Exit: isOpening = " + isOpening);
        }
    }

    void Update()
    {
        if (leftDoor != null && rightDoor != null)
        {
            Vector3 leftTargetPosition = isOpening ? leftDoorOpenPosition : leftDoorClosedPosition;
            Vector3 rightTargetPosition = isOpening ? rightDoorOpenPosition : rightDoorClosedPosition;

            // 문 이동
            leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftTargetPosition, openSpeed * Time.deltaTime);
            rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightTargetPosition, openSpeed * Time.deltaTime);

            // 디버그 로그로 확인
            Debug.Log($"Left Door Position: {leftDoor.transform.position}, Target: {leftTargetPosition}");
            Debug.Log($"Right Door Position: {rightDoor.transform.position}, Target: {rightTargetPosition}");
        }
    }
}

