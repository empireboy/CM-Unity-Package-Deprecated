using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CM.Essentials.FSM
{
	public class StateMachine : MonoBehaviour
	{
		[SerializeField] private string _defaultStateName = "DefaultState";

		private Dictionary<string, State> _states = new Dictionary<string, State>();
		private State _currentState;

		private void Start()
		{
			// Add every state to a dictionary
			foreach (Transform stateTransform in transform)
			{
				State newState = new State();
				newState.SetTitle(stateTransform.name);
				newState.actions.AddRange(stateTransform.GetComponents<StateAction>());
				newState.condition = stateTransform.GetComponent<StateCondition>();
				_states.Add(newState.Title, newState);
			}

			// Try to get the current state
			_currentState = TryToGetStateByName(_defaultStateName);

			// Change the state
			if (_currentState != null)
				ChangeState(_currentState);
		}

		private IEnumerator Coroutine()
		{
			// State enter
			foreach (StateAction stateAction in _currentState.actions)
				stateAction.Enter();
			if (_currentState.condition != null)
				_currentState.condition.Enter();

			while (_currentState.condition.Condition())
			{
				// State update
				foreach (StateAction stateAction in _currentState.actions)
					stateAction.ActionUpdate();
				yield return null;
			}

			// State leave
			foreach (StateAction stateAction in _currentState.actions)
				stateAction.Leave();
			if (_currentState.condition != null)
				_currentState.condition.Leave();
		}

		public void ChangeState(State newState)
		{
			_currentState = newState;
			if (_currentState != null)
				StartCoroutine(Coroutine());
		}

		public void ChangeState(string newStateName)
		{
			_currentState = TryToGetStateByName(newStateName);
			if (_currentState != null)
				StartCoroutine(Coroutine());
		}

		public State TryToGetStateByName(string stateName)
		{
			State newState = null;
			// Try to get the state
			try
			{
				newState = _states[stateName];
			}
			catch
			{
				Debug.LogWarning("The state: " + stateName + " doesn't exist");
			}
			return newState;
		}
	}
}