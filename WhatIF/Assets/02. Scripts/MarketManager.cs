using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MarketManager : MonoBehaviour
{
    // 패널과 버튼을 담을 변수들
    public GameObject vegetablePanel, beefPanel, cheesePanel, breadPanel, finalPanel;
    public GameObject beefAlarm, cheeseAlarm, breadAlarm, alarmTV;
    public GameObject result0Panel, result25Panel, result50Panel, result75Panel, result100Panel;

    public Button cabbageButton, carrotButton;
    public Button beefButton, beanBeefButton;
    public Button cheeseButton, oilButton;
    public Button breadButton, veganBreadButton;
    public Button paperboxButton, recyclingbagButton;

    public Button result0Button, result25Button, result50Button, result75Button, result100Button;

    public AudioSource vegetableBeforeAudio, vegetableAfterAudio, beefAlarmAudio, paperboxAlarmAudio, cheeseAlarmAudio, buttonClickAudio;

    private int badIngredientCount = 0;

    void Start()
    {
        // 초기 상태 설정
        vegetablePanel.SetActive(true);
        beefPanel.SetActive(false);
        cheesePanel.SetActive(false);
        breadPanel.SetActive(false);
        finalPanel.SetActive(false);

        beefAlarm.SetActive(false);
        cheeseAlarm.SetActive(false);
        breadAlarm.SetActive(false);
        alarmTV.SetActive(false);
        result0Panel.SetActive(false);
        result25Panel.SetActive(false);
        result50Panel.SetActive(false);
        result75Panel.SetActive(false);
        result100Panel.SetActive(false);

        // 튜토리얼 시작 오디오를 3초 지연 후 재생
        if (vegetableBeforeAudio != null)
        {
            Invoke("PlayVegetableBeforeAudio", 3f);
        }

        // 버튼 클릭 이벤트 연결
        cabbageButton.onClick.AddListener(() => HandleTutorialButtonClick(vegetablePanel, beefPanel));
        carrotButton.onClick.AddListener(() => HandleTutorialButtonClick(vegetablePanel, beefPanel));

        beefButton.onClick.AddListener(() => HandleButtonClick(() => SelectBadIngredientWithAlarm(beefPanel, beefAlarm, alarmTV, beefAlarmAudio, breadPanel)));
        beanBeefButton.onClick.AddListener(() => HandleButtonClick(() => SelectGoodIngredient(beefPanel, breadPanel)));

        cheeseButton.onClick.AddListener(() => HandleButtonClick(() => SelectBadIngredientWithAlarm(cheesePanel, cheeseAlarm, null, cheeseAlarmAudio, finalPanel)));
        oilButton.onClick.AddListener(() => HandleButtonClick(() => SelectGoodIngredient(cheesePanel, finalPanel)));

        breadButton.onClick.AddListener(() => HandleButtonClick(() => SelectBadIngredient(breadPanel, breadAlarm, cheesePanel)));
        veganBreadButton.onClick.AddListener(() => HandleButtonClick(() => SelectGoodIngredient(breadPanel, cheesePanel)));

        paperboxButton.onClick.AddListener(() => HandleButtonClick(() => SelectBadIngredientWithSound(finalPanel, paperboxAlarmAudio)));
        recyclingbagButton.onClick.AddListener(() => HandleButtonClick(() => SelectGoodIngredient(finalPanel, null)));
    }

    void PlayVegetableBeforeAudio()
    {
        if (vegetableBeforeAudio != null)
        {
            vegetableBeforeAudio.Play();
        }
    }

    void HandleTutorialButtonClick(GameObject currentPanel, GameObject nextPanel)
    {
        currentPanel.SetActive(false);
        if (nextPanel != null)
        {
            nextPanel.SetActive(true);
        }
        if (vegetableAfterAudio != null && !vegetableAfterAudio.isPlaying)
        {
            vegetableAfterAudio.Play();
        }
    }

    void HandleButtonClick(System.Action action)
    {
        if (buttonClickAudio != null && !buttonClickAudio.isPlaying)
        {
            buttonClickAudio.Play();
        }
        action.Invoke();
    }

    void SelectBadIngredient(GameObject panel, GameObject alarm, GameObject nextPanel)
    {
        panel.SetActive(false);
        if (alarm != null) alarm.SetActive(true);
        if (nextPanel != null) nextPanel.SetActive(true);
        badIngredientCount++;
        CheckFinalSelection();
    }

    void SelectBadIngredientWithAlarm(GameObject panel, GameObject alarm, GameObject tv, AudioSource audio, GameObject nextPanel)
    {
        panel.SetActive(false);
        if (alarm != null) alarm.SetActive(true);
        if (tv != null) tv.SetActive(true);
        if (audio != null && !audio.isPlaying) audio.Play();
        if (nextPanel != null) nextPanel.SetActive(true);
        badIngredientCount++;
        CheckFinalSelection();
    }

    void SelectBadIngredientWithSound(GameObject panel, AudioSource audio)
    {
        panel.SetActive(false);
        if (audio != null && !audio.isPlaying) audio.Play();
        badIngredientCount++;
        CheckFinalSelection();
    }

    void SelectGoodIngredient(GameObject panel, GameObject nextPanel)
    {
        panel.SetActive(false);
        if (nextPanel != null) nextPanel.SetActive(true);
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




