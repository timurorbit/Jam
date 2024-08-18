using MoreMountains.Tools;
using Unity.Mathematics;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
	/// <summary>
	/// An Action that shoots using the currently equipped weapon. If your weapon is in auto mode, will shoot until you exit the state, and will only shoot once in SemiAuto mode. You can optionnally have the character face (left/right) the target, and aim at it (if the weapon has a WeaponAim component).
	/// </summary>
	[AddComponentMenu("TopDown Engine/Character/AI/Actions/AIActionShoot2D")]
	//[RequireComponent(typeof(CharacterOrientation2D))]
	//[RequireComponent(typeof(CharacterHandleWeapon))]
	
	public class ShurikenMasterAttack : AIAction
	{
		public enum AimOrigins { Transform, SpawnPoint }
		public CharacterHandleWeapon TargetHandleWeaponAbility;

		[SerializeField] private GameObject bulletPrefab;

		[SerializeField]
		private int numberOfBullets;
 		protected CharacterOrientation2D _orientation2D;
		protected Character _character;
		protected WeaponAim _weaponAim;
		protected ProjectileWeapon _projectileWeapon;
		protected Vector3 _weaponAimDirection;
		protected int _numberOfShoots = 0;
		protected bool _shooting = false;

		/// <summary>
		/// On init we grab our CharacterHandleWeapon ability
		/// </summary>
		public override void Initialization()
		{
			if(!ShouldInitialize) return;
			base.Initialization();
			_character = GetComponentInParent<Character>();
			_orientation2D = _character?.FindAbility<CharacterOrientation2D>();
		}

		/// <summary>
		/// On PerformAction we face and aim if needed, and we shoot
		/// </summary>
		public override void PerformAction()
		{
			Shoot();
		}

		/// <summary>
		/// Sets the current aim if needed
		/// </summary>
		protected virtual void Update()
		{
			//do sth
		}

		/// <summary>
		/// Makes changes to the weapon to ensure it works ok with AI scripts
		/// </summary>
		

		/// <summary>
		/// Faces the target if required
		/// </summary>
		
		protected virtual void Shoot()
		{
			Debug.Log("Shooting...");
			float rotation = 0f;
			float step = 360 / (float)numberOfBullets;
			for (int i = 0; i < numberOfBullets; i++){
				Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, rotation));
				rotation += step;
				
			}
			
		}
		
		public override void OnEnterState()
		{
			base.OnEnterState();
			_shooting = true;
		}
		
		public override void OnExitState()
		{
			base.OnExitState();
			_shooting = false;
		}
	}
}