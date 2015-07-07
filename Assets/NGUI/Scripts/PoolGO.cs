using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BelowTheGame.Unearthed
{
	public class PoolGO<T>
	{
		private List<T> _listAllCreated;
		private List<T> _listAllUsed;
		private List<T> _listAllNotUsed;

		public PoolGO ()
		{
			_listAllCreated = new List<T> ();
			_listAllUsed = new List<T> ();
			_listAllNotUsed = new List<T> ();
		}

		public void getObjectUsedAndNotUsed (int numberObjecUsed)
		{
			clearAllUsed ();
			clearAllNotUsed ();

			for(int index = 0; index < getCountListCreated(); index++)
			{
				if(index < numberObjecUsed)
				{
					addObjectListUsed (getObjecIndexListCreated (index));
				}
				else
				{
					addObjectListNotUsed (getObjecIndexListCreated (index));
				}
			}
		}

		public void setActiveObjectNotUsed (bool value)
		{
			MonoBehaviour classTemp = null;

			for(int index = 0; index < getCountListNotUsed(); index++)
			{
				classTemp = _listAllNotUsed [index] as MonoBehaviour;
				classTemp.gameObject.SetActive(value);
			}
		}

		#region Add List
		public void addObjectPool (T obj)
		{
			_listAllCreated.Add (obj);
			_listAllUsed.Add (obj);
		}

		public void addObjectListCreated (T obj)
		{
			_listAllCreated.Add (obj);
		}

		public void addObjectListUsed (T obj)
		{
			_listAllUsed.Add (obj);
		}

		public void addObjectListNotUsed (T obj)
		{
			_listAllNotUsed.Add (obj);
		}
		#endregion

		#region Count List
		public int getCountListCreated ()
		{
			return _listAllCreated.Count;
		}

		public int getCountListUsed ()
		{
			return _listAllUsed.Count;
		}

		public int getCountListNotUsed ()
		{
			return _listAllNotUsed.Count;
		}
		#endregion

		#region Clear List
		public void clearAllUsed ()
		{
			_listAllUsed.Clear ();
		}

		public void clearAllNotUsed ()
		{
			_listAllNotUsed.Clear ();
		}
		#endregion

		#region getObject
		public T getObjecIndexListCreated (int index)
		{
			return _listAllCreated [index];
		}

		public T getObjecIndexListUsed (int index)
		{
			return _listAllUsed [index];
		}

		public T getObjecIndexListNotUsed (int index)
		{
			return _listAllNotUsed [index];
		}
		#endregion

		#region Dispose
		public void dispose ()
		{
			disposeListCreated ();
			disposeListUsed ();
			disposeListNotUsed ();
		}

		private void disposeListCreated ()
		{
			for (int i = 0; i < _listAllCreated.Count; i++)
			{
				MonoBehaviour.Destroy(_listAllCreated[i] as Object);
			}

			//_listAllCreated = null;
		}

		private void disposeListUsed ()
		{
			for (int i = 0; i < _listAllUsed.Count; i++)
			{
				MonoBehaviour.Destroy(_listAllUsed[i] as Object);
			}
			
			//_listAllUsed = null;
		}

		private void disposeListNotUsed ()
		{
			for (int i = 0; i < _listAllNotUsed.Count; i++)
			{
				MonoBehaviour.Destroy(_listAllNotUsed[i] as Object);
			}
			
			//_listAllNotUsed = null;
		}
		#endregion

		public List<T> listAllCreated {
			get {
				return _listAllCreated;
			}
		}

		public List<T> listAllUsed {
			get {
				return _listAllUsed;
			}
		}

		public List<T> listAllNotUsed {
			get {
				return _listAllNotUsed;
			}
		}
	}
}