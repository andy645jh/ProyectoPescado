using System;
using UnityEngine;
using System.Collections;

namespace Elkin.Nemo
{
	public class MovementLineal : MonoBehaviour 
	{
		public bool moveRight=true;
		public float vel=50;
		public float range = 800;
		private Action<GameObject> _callbackOutBounds;
		private float _currentRange =0;
		private int _factor =1;
		// Use this for initialization
		void Start () {
			transform.localScale = Vector3.one;
			_currentRange = 0;
			_factor = moveRight ? 1 : -1;
			vel *= 10;
		}
		
		// Update is called once per frame
		void Update ()
		{
			_currentRange += Time.deltaTime * vel;
			Vector3 position = transform.localPosition;
			position.x += Time.deltaTime * vel * _factor;
			transform.localPosition = position;

			if(_currentRange>range)
			{
				_currentRange=0;
				if(_callbackOutBounds!=null) _callbackOutBounds.Invoke(gameObject);	
			}

		}

		public Action<GameObject> callbackOutBounds {
			get {
				return _callbackOutBounds;
			}
			set {
				_callbackOutBounds = value;
			}
		}


	}
}