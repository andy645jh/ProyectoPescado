using UnityEngine;
using System.Collections;

namespace Elkin.Nemo
{
	public class Movement : MonoBehaviour
	{
		public GameObject spawn;
		private float vel = 500;


		void Start ()
		{

		}

		// Update is called once per frame
		void Update () 
		{		
			float dirX = Input.GetAxis ("Horizontal");	
			float dirY = Input.GetAxis ("Vertical");
			Vector2 position = transform.localPosition;

			if(position.y<500 && dirY>0) 
			{
				position.y += Time.deltaTime*vel*dirY;				
			}else
			if (position.y>-500 && dirY<0)			
			{
				position.y += Time.deltaTime*vel*dirY;		
			}

			if(position.x<933 && dirX>0) 
			{
				position.x += Time.deltaTime*vel*dirX;				
			}else
				if (position.x>-933 && dirX<0)			
			{
				position.x += Time.deltaTime*vel*dirX;		
			}

			transform.localPosition=position;

		}
	}
}