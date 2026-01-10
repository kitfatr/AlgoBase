using UnityEngine;
using System.Collections;

public class Model_mover : MonoBehaviour
{
	private Vector3 target;
	private Quaternion main, qtarget;
	private bool inTrig;
	public float speed, sens;
	
	void Start()
	{
		main = transform.rotation;
	}
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0) && Input.mousePosition.x < 500 && Input.mousePosition.y < 500)
		{
			inTrig = true;
		}
		else if (Input.GetMouseButton(0) && inTrig)
		{
			Quaternion now;
			
			target = new Vector3(-Input.mousePosition.x * sens + 500 * sens, -Input.mousePosition.y * sens + 280 * sens, 40000);
			// Debug.Log(target);
			
			now = transform.rotation;
			transform.LookAt(target);
			qtarget = transform.rotation;
			transform.rotation = now;
			
			transform.rotation = Quaternion.Slerp(transform.rotation, qtarget, Time.deltaTime * speed);
        }
		else if (Input.GetMouseButtonUp(0))
		{
			inTrig = false;
		}
		else
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, main, Time.deltaTime * speed);
		}
		
	}
}
