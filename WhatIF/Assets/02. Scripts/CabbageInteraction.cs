using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CabbageInteraction : MonoBehaviour
{
    public GameObject cabbageSelectionPanel; // �г� ������Ʈ
    public Color highlightColor = Color.green; // Hover �� ����
    private Color originalColor;
    private Renderer cabbageRenderer;

    private bool isHovered = false;

    void Start()
    {
        // ������ Renderer ��������
        cabbageRenderer = GetComponent<Renderer>();
        originalColor = cabbageRenderer.material.color;

        // �г� ��Ȱ��ȭ
        if (cabbageSelectionPanel != null)
            cabbageSelectionPanel.SetActive(false);
    }

    // Ray�� Hover�� �� �� ȣ��
    public void OnRayEnter()
    {
        isHovered = true;
        cabbageRenderer.material.color = highlightColor; // ���� ����
    }

    // Ray�� Hover���� ���� �� ȣ��
    public void OnRayExit()
    {
        isHovered = false;
        cabbageRenderer.material.color = originalColor; // ���� ���� ����
    }

    // Hand Trigger�� ������ ���� ȣ��
    public void OnSelectEntered()
    {
        if (isHovered && cabbageSelectionPanel != null)
        {
            cabbageSelectionPanel.SetActive(true); // �г� Ȱ��ȭ
        }
    }
}



