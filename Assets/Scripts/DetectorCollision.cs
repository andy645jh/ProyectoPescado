using UnityEngine;
using System.Collections;

namespace Elkin.Nemo
{
	public class DetectorCollision : MonoBehaviour 
	{
		public string targetName ="";

		void OnTriggerEnter(Collider col)
		{
			Debug.Log ("Colision: " + col.gameObject.name);
			if(col.gameObject.tag==targetName) 
			{
				Debug.Log ("Colision Activada: " + col.gameObject.tag);
				//gameObject.SetActive(false);
			}
		}
	}
}