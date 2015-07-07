using System;
using UnityEngine;
using System.Collections;

namespace Elkin.Nemo
{
	public class MovementLineal : MonoBehaviour 
	{
		private float vel=500;
		private float _range = 800;
		private Action<GameObject> _callbackOutBounds;
		private float _currentRange =0;

		// Use this for initialization
		void Start () {
			transform.localScale = Vector3.one;
			_currentRange = 0;
		}
		
		// Update is called once per frame
		void Update ()
		{
			_currentRange += Time.deltaTime * vel;
			Vector3 position = transform.localPosition;
			position.x += Time.deltaTime * vel;
			transform.localPosition = position;

			if(_currentRange>_range)
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

		public float range {
			get {
				return _range;
			}
			set {
				_range = value;
			}
		}
	}
}