using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CabbageInteraction : MonoBehaviour
{
    public GameObject cabbageSelectionPanel; // 패널 오브젝트
    public Color highlightColor = Color.green; // Hover 시 색상
    private Color originalColor;
    private Renderer cabbageRenderer;

    private bool isHovered = false;

    void Start()
    {
        // 배추의 Renderer 가져오기
        cabbageRenderer = GetComponent<Renderer>();
        originalColor = cabbageRenderer.material.color;

        // 패널 비활성화
        if (cabbageSelectionPanel != null)
            cabbageSelectionPanel.SetActive(false);
    }

    // Ray가 Hover에 들어갈 때 호출
    public void OnRayEnter()
    {
        isHovered = true;
        cabbageRenderer.material.color = highlightColor; // 색상 변경
    }

    // Ray가 Hover에서 나올 때 호출
    public void OnRayExit()
    {
        isHovered = false;
        cabbageRenderer.material.color = originalColor; // 원래 색상 복원
    }

    // Hand Trigger를 눌렀다 떼면 호출
    public void OnSelectEntered()
    {
        if (isHovered && cabbageSelectionPanel != null)
        {
            cabbageSelectionPanel.SetActive(true); // 패널 활성화
        }
    }
}



