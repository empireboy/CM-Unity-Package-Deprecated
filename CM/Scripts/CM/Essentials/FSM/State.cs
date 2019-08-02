using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials.FSM
{
	[System.Serializable]
	public class State
	{
		[SerializeField] private string _title;
		public string Title { get => _title; }
		public List<StateAction> actions = new List<StateAction>();
		public StateCondition condition;

		public void SetTitle(string title)
		{
			_title = title;
		}
	}
}