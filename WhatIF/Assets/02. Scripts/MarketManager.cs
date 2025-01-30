using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MarketManager : MonoBehaviour
{
    // 패널과 버튼을 담을 변수들
    public GameObject beefPanel, cheesePanel, breadPanel, finalPanel;
    public GameObject beefAlarm, cheeseAlarm, breadAlarm;
    public GameObject result0Panel, result25Panel, result50Panel, result75Panel, result100Panel;

    public Button beefButton, beanBeefButton;
    public Button cheeseButton, oilButton;
    public Button breadButton, veganBreadButton;
    public Button paperboxButton, recyclingbagButton;

    public Button result0Button, result25Button, result50Button, result75Button, result100Button;

    private int badIngredientCount = 0;

    void Start()
    {
        // 초기 상태 설정
        beefAlarm.SetActive(false);
        cheeseAlarm.SetActive(false);
        breadAlarm.SetActive(false);
        result0Panel.SetActive(false);
        result25Panel.SetActive(false);
        result50Panel.SetActive(false);
        result75Panel.SetActive(false);
        result100Panel.SetActive(false);

        // 버튼 클릭 이벤트 연결
        beefButton.onClick.AddListener(() => SelectBadIngredient(beefPanel, beefAlarm));
        beanBeefButton.onClick.AddListener(() => SelectGoodIngredient(beefPanel));

        cheeseButton.onClick.AddListener(() => SelectBadIngredient(cheesePanel, cheeseAlarm));
        oilButton.onClick.AddListener(() => SelectGoodIngredient(cheesePanel));

        breadButton.onClick.AddListener(() => SelectBadIngredient(breadPanel, breadAlarm));
        veganBreadButton.onClick.AddListener(() => SelectGoodIngredient(breadPanel));

        paperboxButton.onClick.AddListener(() => SelectBadIngredient(finalPanel, null));
        recyclingbagButton.onClick.AddListener(() => SelectGoodIngredient(finalPanel));
    }

    void SelectBadIngredient(GameObject panel, GameObject alarm)
    {
        panel.SetActive(false);
        if (alarm != null) alarm.SetActive(true);
        badIngredientCount++;
        CheckFinalSelection();
    }

    void SelectGoodIngredient(GameObject panel)
    {
        panel.SetActive(false);
        CheckFinalSelection();
    }

    void CheckFinalSelection()
    {
        if (!finalPanel.activeSelf)
        {
            switch (badIngredientCount)
            {
                case 4:
                    result100Panel.SetActive(true);
                    result100Button.onClick.AddListener(() => LoadScene("Result100"));
                    break;
                case 3:
                    result75Panel.SetActive(true);
                    result75Button.onClick.AddListener(() => LoadScene("Result75"));
                    break;
                case 2:
                    result50Panel.SetActive(true);
                    result50Button.onClick.AddListener(() => LoadScene("Result50"));
                    break;
                case 1:
                    result25Panel.SetActive(true);
                    result25Button.onClick.AddListener(() => LoadScene("Result25"));
                    break;
                case 0:
                    result0Panel.SetActive(true);
                    result0Button.onClick.AddListener(() => LoadScene("Result0"));
                    break;
            }
        }
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}