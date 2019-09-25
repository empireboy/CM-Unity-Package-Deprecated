using CM.Shooting;
using UnityEngine;

public class ShootController : MonoBehaviour
{
	private ShootingType _shootingType;

	private bool _isExecuting = false;

	private float _timer = 0f;
	private int _burstCounter = 0;

	public delegate void ShootHandler();
	public event ShootHandler ShootEvent;

	public void Execute(ShootingType shootingType)
	{
		_shootingType = shootingType;

		_timer = 1 / shootingType.fireRate;

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
			// Increase Burst Fire Counter
			if (_shootingType.burstFire)
			{
				_burstCounter++;
				_timer = 1 / _shootingType.fireRate;
			}

			// Finished Burst Fire and Time Between Burst
			if (_burstCounter >= _shootingType.shotsPerBurst + 1 || _shootingType.timeBetweenBurst <= 0)
			{
				StopChecking();
				return;
			}

			// Finished Burst Fire
			if (_burstCounter >= _shootingType.shotsPerBurst)
			{
				_timer = _shootingType.timeBetweenBurst;
			}

			// Shoot
			ShootEvent?.Invoke();

			// Finished Normal Fire
			if (!_shootingType.burstFire)
			{
				StopChecking();
			}
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