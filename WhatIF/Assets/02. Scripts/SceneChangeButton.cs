using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    public void LoadMarketScene()
    {
        SceneManager.LoadScene("Markey_Test");
    }
}

