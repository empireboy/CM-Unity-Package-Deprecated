using CM.Shooting;
using UnityEngine;

public class ShootController : MonoBehaviour
{
	private ShootingType _shootingType;

	private bool _isExecuting = false;

	private float _timer = 0f;

	private float _totalShootingTime = 0f;

	//private float _exponentValue = 1f;

	public delegate void ShootHandler();
	public event ShootHandler ShootEvent;

	public void Execute(ShootingType shootingType)
	{
		_shootingType = shootingType;

		_isExecuting = true;
	}

	private void Update()
	{
		if (!_isExecuting)
			return;

		if (_timer > 0)
		{
			_timer -= Time.deltaTime;
		}
		else
		{
			// Shoot
			if (ShootEvent != null)
				ShootEvent.Invoke();

			_timer = _shootingType.fireRate.Evaluate(_totalShootingTime);

			_totalShootingTime += _timer;
		}
	}

	public static ShootController StartChecking(GameObject addComponentAt, ShootingType shootingType)
	{
		if (addComponentAt.GetComponent<ShootController>())
			return null;

		ShootController shootController = addComponentAt.AddComponent<ShootController>();
		shootController.Execute(shootingType);

		return shootController;
	}

	public void StopChecking()
	{
		Destroy(this);
	}
}