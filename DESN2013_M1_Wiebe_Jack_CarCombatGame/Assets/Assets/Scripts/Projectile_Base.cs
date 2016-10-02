using UnityEngine;
using System.Collections;

public abstract class Projectile_Base : MonoBehaviour {

	public abstract void Bullet_Hit (GameObject instigator, GameObject target, float dmg);

}
