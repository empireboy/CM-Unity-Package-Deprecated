using UnityEngine;

namespace CM.Shooter
{
	public class WeaponShootRaycastHit : MonoBehaviour
	{
		[SerializeField] private Transform _shootPoint;
		[SerializeField] private float _shootRange = 100;

		public delegate void RaycastHitHandler(RaycastHit hit);
		public event RaycastHitHandler OnRaycastHit;

		private void Start()
		{
			GetComponent<WeaponShoot>().OnShootStart += OnShoot;
		}

		private void OnShoot()
		{
			RaycastHit hit;

			if (Physics.Raycast(_shootPoint.position, _shootPoint.transform.forward, out hit, _shootRange))
			{
				Destroy(hit.transform.gameObject);
				if (OnRaycastHit != null)
					OnRaycastHit(hit);
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawRay(_shootPoint.position, _shootPoint.transform.forward * 100);
		}
	}
}