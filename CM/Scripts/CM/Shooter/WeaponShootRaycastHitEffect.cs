using UnityEngine;

namespace CM.Shooter
{
	[RequireComponent(typeof(WeaponShootRaycastHit))]
	public class WeaponShootRaycastHitEffect : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem _prefab;

		[SerializeField]
		private LayerMask _layerMask;

		private void Start()
		{
			GetComponent<WeaponShootRaycastHit>().OnRaycastHit += OnRaycastHit;
		}

		private void OnRaycastHit(RaycastHit hit)
		{
			if (!_layerMask.Contains(hit.transform.gameObject.layer))
				return;

			ParticleSystem bloodPrefab = Instantiate(_prefab);
			bloodPrefab.transform.position = hit.point;
		}
	}
}