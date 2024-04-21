using System;
using UnityEngine;

// Token: 0x02000036 RID: 54
public class NotebookScript : MonoBehaviour
{
	// Token: 0x060000F8 RID: 248 RVA: 0x00007612 File Offset: 0x00005812
	private void Start()
	{
		this.up = true;
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x0000761C File Offset: 0x0000581C
	private void Update()
	{
		if (this.gc.mode == "endless")
		{
			if (this.respawnTime > 0f)
			{
				if ((base.transform.position - this.player.position).magnitude > 60f)
				{
					this.respawnTime -= Time.deltaTime;
				}
			}
			else if (!this.up)
			{
				base.transform.position = new Vector3(base.transform.position.x, 4f, base.transform.position.z);
				this.up = true;
				this.audioDevice.Play();
			}
		}
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f && Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f)), out raycastHit) && (raycastHit.transform.tag == "Notebook" & Vector3.Distance(this.player.position, base.transform.position) < this.openingDistance))
		{
			base.transform.position = new Vector3(base.transform.position.x, -20f, base.transform.position.z);
			this.up = false;
			this.respawnTime = 120f;
			this.gc.CollectNotebook();
			this.gc.player.stamina = 100f;
			if (this.gc.notebooks == 2)
			{
				this.gc.ActivateSpoopMode();
				this.bsc.GetAngry(this.bsc.angerRate);
			}
			if (this.gc.notebooks == 7 & this.gc.mode == "story")
			{
				this.audioDevice.PlayOneShot(this.gc.aud_AllNotebooks, 0.8f);
			}
		}
	}

	// Token: 0x060000FA RID: 250 RVA: 0x0000783D File Offset: 0x00005A3D
	public NotebookScript()
	{
	}

	// Token: 0x04000189 RID: 393
	public float openingDistance;

	// Token: 0x0400018A RID: 394
	public GameControllerScript gc;

	// Token: 0x0400018B RID: 395
	public BaldiScript bsc;

	// Token: 0x0400018C RID: 396
	public float respawnTime;

	// Token: 0x0400018D RID: 397
	public bool up;

	// Token: 0x0400018E RID: 398
	public Transform player;

	// Token: 0x0400018F RID: 399
	public GameObject learningGame;

	// Token: 0x04000190 RID: 400
	public AudioSource audioDevice;
}