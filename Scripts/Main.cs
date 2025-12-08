using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
	private Vector3 to;
	private bool isCamMoving, reversed_vec = false;
	private float LERP_border = 1f;
	public GameObject cam;
	public float camSpeed;
	
	private int counter = 0;
	
	public Dropdown drp_ScMode, drp_ScResolution;
	private bool fullscreen;
	
	void Start()
	{
		SettingsLoad();
	}
	
    public void Exit()
	{
		Debug.Log("Exiting");
		Application.Quit();
	}
	
	public void LERP_move(float tofloat)
	{
		to = new(tofloat, 0f, -10f);
		isCamMoving = true;
		
		if (cam.transform.position.x > to.x)
		{
			reversed_vec = true;
		}
		else
		{
			reversed_vec = false;
		}
		
		// Debug.Log(to);
		// Debug.Log(cam);
	}
	
	void Update()
	{
		if (isCamMoving)
		{
			//Debug.Log("reversed_vec: " + reversed_vec);
			cam.transform.position = Vector3.Lerp(cam.transform.position, to, Time.deltaTime * camSpeed);
			
			if (reversed_vec == false)
			{
				if (cam.transform.position.x >= to.x - LERP_border)
				{
					isCamMoving = false;
					cam.transform.position = to;
				}
			}
			if (reversed_vec == true)
			{
				if (cam.transform.position.x <= to.x + LERP_border)
				{
					isCamMoving = false;
					cam.transform.position = to;
				}
			}
		}
	}
	
	public void Card(GameObject title)
	{
		counter++;
		
		if (counter == 5)
		{
			Debug.Log("secret");
		}
	}
	
	//Settings functions
	
	public void SetScreenMode()
	{
		if (drp_ScMode.value == 0)
		{
			Screen.fullScreen = false;
			fullscreen = false;
		}
		else
		{
			Screen.fullScreen = true;
			fullscreen = true;
		}
		Debug.Log("Format changed!\nFullscreen: " + fullscreen);
	}
	
	public void SetScreenResolution()
	{
		if (drp_ScResolution.value == 0)
		{
			Screen.SetResolution(1920, 1080, fullscreen);
		}
		else if (drp_ScResolution.value == 1)
		{
			Screen.SetResolution(1600, 1200, fullscreen);
		}
		else if (drp_ScResolution.value == 2)
		{
			Screen.SetResolution(1280, 960, fullscreen);
		}
		else if (drp_ScResolution.value == 3)
		{
			Screen.SetResolution(1280, 720, fullscreen);
		}
		else if (drp_ScResolution.value == 4)
		{
			Screen.SetResolution(854, 480, fullscreen);
		}
		else if (drp_ScResolution.value == 5)
		{
			Screen.SetResolution(640, 480, fullscreen);
		}
		Debug.Log("Resolution changed!\nResolution preset: " + drp_ScResolution.value);
	}
	
	public void SettingsSave()
	{
		PlayerPrefs.SetInt("stg_ScMode", drp_ScMode.value);
		PlayerPrefs.SetInt("stg_ScResolution", drp_ScResolution.value);
		Debug.Log("Settings saved!");
	}
	
	public void SettingsLoad()
	{
		drp_ScMode.value = PlayerPrefs.GetInt("stg_ScMode");
		drp_ScResolution.value = PlayerPrefs.GetInt("stg_ScResolution");
		
		SetScreenMode();
		SetScreenResolution();
		
		Debug.Log("Settings loaded!");
	}
	
	public void OpenWedPage(string url)
	{
		System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
	}
}
