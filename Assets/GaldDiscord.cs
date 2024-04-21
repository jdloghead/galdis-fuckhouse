using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GaldDiscord : MonoBehaviour
{
    public string discordInviteLink = "https://discord.gg/QuKPP62KZW";

    public void OpenDiscordInvite()
    {
        Application.OpenURL(discordInviteLink);
    }
}
