using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class CabbageSelection : MonoBehaviour
{
    public GameObject cabbageSelectionPanel; // CabbageSelectionPanel 연결
    public XRRayInteractor rayInteractor;  // Right Controller의 Ray Interactor 연결

    private XRController controller; // XR Controller (Device-based)를 자동으로 찾기
    private bool isPanelActive = false;

    void Start()
    {
        // Right Controller에 있는 XR Controller (Device-based) 자동으로 가져오기
        controller = FindObjectOfType<XRController>();

        if (controller == null)
        {
            Debug.LogError("XR Controller (Device-based)를 찾을 수 없습니다! Right Controller를 확인하세요.");
        }
    }

    void Update()
    {
        if (controller != null && controller.inputDevice.isValid)
        {
            // A 버튼 입력 감지
            if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed) && isPressed)
            {
                ShowSelectionPanel();
            }
        }
    }

    void ShowSelectionPanel()
    {
        // 사용자가 양배추를 가리키고 있을 때만 패널을 활성화
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Cabbage")) // 양배추 태그 확인
            {
                cabbageSelectionPanel.SetActive(true);
                isPanelActive = true;
            }
        }
    }

    public void SelectCabbage()
    {
        Debug.Log("양배추 선택됨!");
        cabbageSelectionPanel.SetActive(false);
    }

    public void CancelSelection()
    {
        Debug.Log("양배추 선택 취소");
        cabbageSelectionPanel.SetActive(false);
    }
}
