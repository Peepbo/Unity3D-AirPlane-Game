using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

	void Update ()
	{
		Destroy(gameObject, 3f);
	}
}
