using System.Collections;
using UnityEngine;

namespace CM.Essentials.FSM
{
	public class TimeCondition : StateCondition
	{
		public float time = 3f;

		private bool _finishedTimer = false;

		public override void Enter()
		{
			_finishedTimer = false;
			StartCoroutine(Coroutine());
		}

		public override bool Condition()
		{
			if (_finishedTimer)
			{
				ChangeState();
				return false;
			}
			return true;
		}

		private IEnumerator Coroutine()
		{
			yield return new WaitForSeconds(time);
			_finishedTimer = true;
		}
	}
}