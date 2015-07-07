using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour 
{
	private UITexture _texture;
	// Use this for initialization
	void Start ()
	{
		_texture =GetComponent<UITexture> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Rect rect = _texture.uvRect;
		rect.x += Time.deltaTime * 0.03F;
		_texture.uvRect = rect;
	}
}
