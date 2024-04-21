using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Token: 0x0200008A RID: 138
public class AchievementExampleScript : MonoBehaviour
{
	// Token: 0x0600011F RID: 287 RVA: 0x0000214C File Offset: 0x0000034C
	public AchievementExampleScript()
	{
	}

	// Token: 0x06000120 RID: 288 RVA: 0x0000C16C File Offset: 0x0000A36C
	private void Start()
	{
        this.Reset();
	}

	// Token: 0x06000121 RID: 289 RVA: 0x0000216C File Offset: 0x0000036C
	private void Update()
	{
	}

    private void Reset()
    {
        if (PlayerPrefs.GetInt(this.type) == 1)
		{
			this.achievementImage.color = new Color(255f, 255f, 255f);
            this.achievementText.text = this.UnlockedText;
			return;
		}
		this.achievementImage.color = new Color(0f, 0f, 0f);
        this.achievementText.text = this.lockedText;
    }

	// Token: 0x0400024A RID: 586
	public TextMeshProUGUI achievementText;

	// Token: 0x0400024B RID: 587
	public Image achievementImage;

    public string type;

    public string lockedText;

    public string UnlockedText;
}
