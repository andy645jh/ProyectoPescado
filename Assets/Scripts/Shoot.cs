using UnityEngine;
using System.Collections;

namespace Elkin.Nemo
{
	public class Shoot : MonoBehaviour
	{
		public int amount=50;
		public float latency=0.05f;
		public GameObject bullet =null;
		public bool isAutomatic = false;

		private float _time = 0;
		private Stack _listBullets;

		void Start () 
		{
			_listBullets = new Stack();

			for(int i=0; i<amount; i++)
			{
				GameObject bulletTemp = (GameObject)Instantiate(bullet);
				bulletTemp.SetActive(false);
				bulletTemp.GetComponent<MovementLineal>().callbackOutBounds = outBounds;
				_listBullets.Push(bulletTemp);
			}
		}

		private void outBounds(GameObject bullet)
		{
			Debug.Log ("outBounds");
			bullet.SetActive (false);
			_listBullets.Push (bullet);
		}

		// Update is called once per frame
		void Update () 
		{
			if(isAutomatic) shootAutomatic();
			else shootManual ();
		}

		private void shootAutomatic()
		{
			if(_listBullets.Count>0)
			{
				Debug.Log("Input");
				float diff = Time.time-_time;
				
				if(diff>latency)
				{
					_time= Time.time;
					GameObject bulletTemp = (GameObject) _listBullets.Pop();
					bulletTemp.SetActive(true);
					bulletTemp.transform.parent = transform;
					bulletTemp.transform.localPosition = Vector2.zero;
					bulletTemp.transform.parent = transform.parent.parent;
				}
			}
		}

		private void shootManual()
		{
			if(Input.GetKey(KeyCode.X) && _listBullets.Count>0)
			{
				Debug.Log("Input");
				float diff = Time.time-_time;
				
				if(diff>latency)
				{
					_time= Time.time;
					GameObject bulletTemp = (GameObject) _listBullets.Pop();
					bulletTemp.SetActive(true);
					bulletTemp.transform.parent = transform;
					bulletTemp.transform.localPosition = Vector2.zero;
					bulletTemp.transform.parent = transform.parent.parent;
				}
			}
		}
	}
}