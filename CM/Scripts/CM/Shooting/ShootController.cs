using CM.Shooting;
using UnityEngine;

public class ShootController : MonoBehaviour
{
	private ShootingType _shootingType;

	private bool _isExecuting = false;

	private float _timer = 0f;

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
			// Shoot
			if (ShootEvent != null)
				ShootEvent.Invoke();

			StopChecking();
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