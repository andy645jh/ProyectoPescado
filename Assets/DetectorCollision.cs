using UnityEngine;
using System.Collections;

namespace Elkin.Nemo
{
	public class DetectorCollision : MonoBehaviour 
	{

		void OnTriggerEnter(Collider col)
		{
			//Debug.Log ("Colision: " + col.gameObject.name);
		}
	}
}