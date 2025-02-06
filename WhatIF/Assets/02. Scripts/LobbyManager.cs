using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public AudioSource lobbyNarrationAudio;

    void Start()
    {
        if (lobbyNarrationAudio != null)
        {
            Invoke("PlayLobbyNarration", 3f);
        }
    }

    void PlayLobbyNarration()
    {
        if (lobbyNarrationAudio != null && !lobbyNarrationAudio.isPlaying)
        {
            lobbyNarrationAudio.Play();
        }
    }
}

