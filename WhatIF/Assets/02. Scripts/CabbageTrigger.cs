using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public class CabbageTrigger : MonoBehaviour
{
    public GameObject cabbageSelectionPanel; // CabbageSelectionPanel
    public XRRayInteractor rayInteractor; // 컨트롤러 Ray Interactor
    public InputHelpers.Button activationButton = InputHelpers.Button.PrimaryButton; // A 버튼

    private XRController controller;
    private bool isUIActive = false;

    void Start()
    {
        // 게임 시작 시 선택 창 비활성화
        if (cabbageSelectionPanel != null)
        {
            cabbageSelectionPanel.SetActive(false);
        }

        controller = rayInteractor.GetComponent<XRController>();
    }

    void Update()
    {
        if (controller != null && rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Cabbage") && !isUIActive) // 양배추를 가리키는 경우
            {
                if (controller.inputDevice.IsPressed(activationButton, out bool isPressed) && isPressed)
                {
                    ShowSelectionUI();
                }
            }
        }
    }

    private void ShowSelectionUI()
    {
        if (cabbageSelectionPanel != null)
        {
            cabbageSelectionPanel.SetActive(true); // UI 활성화
            isUIActive = true;
        }
    }

    public void OnYesButtonClick()
    {
        Debug.Log("양배추를 선택했습니다!");
        cabbageSelectionPanel.SetActive(false); // UI 닫기
        isUIActive = false;
    }

    public void OnNoButtonClick()
    {
        Debug.Log("양배추 선택을 취소했습니다!");
        cabbageSelectionPanel.SetActive(false); // UI 닫기
        isUIActive = false;
    }
}