using UnityEngine;
using UnityEngine.UI;

public class lessons : MonoBehaviour
{
	private bool code_disabled;
	private int index;
	public Text title, para_alg, para_python, para_c, code_para_python, code_para_c;
	public Text c_title, c_para_alg, c_para_python, c_para_c, c_code_para_python, c_code_para_c;
	public GameObject python_plate, c_plate;
	public GameObject c_python_plate, c_c_plate;
	public Button prev, next;
	
	public GameObject cam;
	private bool next_doing, prev_doing;
	
	public void Set_Article(int i)
	{
		prev.interactable = true;
		next.interactable = true;
		code_disabled = false;
		index = i;
		
		//lessons articles goes here
		if (i == 0)
		{
			code_disabled = true;
			title.text = "Определение алгоритма";
			para_alg.text = "Алгоритм - это предназначенное для конкретного исполнителя описание последовательности действий, приводящих от исходных данных к требуемому результату.";
			prev.interactable = false;
		}
		else if (i == 1)
		{
			code_disabled = true;
			title.text = "Основы блок-схем";
			para_alg.text = "Просто текст для проверки";
			next.interactable = false;
		}
		else //test sign
		{
			title.text = "Warning!";
			para_alg.text = "If you reading this, something went wrong (or it was called by reqest)";
		}
		
		//code paragraph disabling
		if (code_disabled)
		{
			python_plate.SetActive(false);
			c_plate.SetActive(false);
		}
		else
		{
			python_plate.SetActive(true);
			c_plate.SetActive(true);
		}
	}
	
	public void Set_Article_Copy(int i)
	{
		prev.interactable = true;
		next.interactable = true;
		code_disabled = false;
		index = i;
		
		//lessons articles goes here
		if (i == 0)
		{
			code_disabled = true;
			title.text = "Определение алгоритма";
			para_alg.text = "Алгоритм - это предназначенное для конкретного исполнителя описание последовательности действий, приводящих от исходных данных к требуемому результату.";
			prev.interactable = false;
		}
		else if (i == 1)
		{
			code_disabled = true;
			c_title.text = "Основы блок-схем";
			c_para_alg.text = "Просто текст для проверки";
			prev.interactable = false;
		}
		else //test sign
		{
			c_title.text = "Warning!";
			c_para_alg.text = "If you reading this, something went wrong (or it was called by reqest)";
		}
		
		//code paragraph disabling
		if (code_disabled)
		{
			c_python_plate.SetActive(false);
			c_c_plate.SetActive(false);
		}
		else
		{
			c_python_plate.SetActive(true);
			c_c_plate.SetActive(true);
		}
	}
	
	public void Set_Article_Image(GameObject image)
	{
		//WIP
	}
	
	public void Set_Article_Next()
	{
		index++;
		next_doing = true;
		
		Set_Article_Copy(index);
	}
	
	public void Set_Article_Prev()
	{
		index--;
		prev_doing = true;
		
		Set_Article_Copy(index + 1);
		cam.transform.position = new(6000, 0, -10);
		
		Set_Article(index - 1);
	}
	
	void Update()
	{
		if (next_doing)
		{
			if (6000 == cam.transform.position.x)
			{
				Set_Article(index);
				cam.transform.position = new(4000, 0, -10);
				next_doing = false;
			}
		}
		if (prev_doing) {}
	}
}
