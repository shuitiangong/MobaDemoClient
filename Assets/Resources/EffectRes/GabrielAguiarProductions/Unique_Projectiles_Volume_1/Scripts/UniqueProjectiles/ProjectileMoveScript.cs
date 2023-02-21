using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveScript : MonoBehaviour {

	public float speed;
	//[Tooltip("From 0% to 100%")]
	//public float accuracy;
	//public float fireRate;
	public GameObject muzzlePrefab;
	public GameObject hitPrefab;
	public AudioClip shotSFX;
	public AudioClip hitSFX;
	public List<GameObject> trails;

	//private float speedRandomness;
	//private Vector3 offset;
	private bool collided;
	private Rigidbody rb;

	void Start () {	
		rb = GetComponent <Rigidbody> ();

        //特效出生前的效果
		//if (muzzlePrefab != null) {
		//	var muzzleVFX = Instantiate (muzzlePrefab, transform.position, Quaternion.identity);
		//	muzzleVFX.transform.forward = gameObject.transform.forward;
		//	var ps = muzzleVFX.GetComponent<ParticleSystem>();
		//	if (ps != null)
		//		Destroy (muzzleVFX, ps.main.duration);
		//	else {
		//		var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
		//		Destroy (muzzleVFX, psChild.main.duration);
		//	}
		//}

		if (shotSFX != null && GetComponent<AudioSource>()) {
			GetComponent<AudioSource> ().PlayOneShot (shotSFX);
		}
	}

	void FixedUpdate () {
        //+ offset
        if (speed != 0 && rb != null)
			rb.position += (transform.forward )  * (speed * Time.deltaTime);
	}

    //碰撞时销毁 ,EZ的R就不是碰撞的时候销毁 
    //固定时间销毁
	void OnCollisionEnter (Collision co) {
		if (co.gameObject.tag != "Bullet" && !collided) {
			collided = true;
			
            //触碰时候的音效
			if (shotSFX != null && GetComponent<AudioSource>()) {
				GetComponent<AudioSource> ().PlayOneShot (hitSFX);
			}

            //拖尾特效的销毁
			if (trails.Count > 0) {
				for (int i = 0; i < trails.Count; i++) {
					trails [i].transform.parent = null;
					var ps = trails [i].GetComponent<ParticleSystem> ();
					if (ps != null) {
						ps.Stop ();
						Destroy (ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
					}
				}
			}
		
            //移动速度设置为0
			speed = 0;
            //去动力 瞬间停止
			GetComponent<Rigidbody> ().isKinematic = true;

            //contacts:接触点列表
            //获取第一个接触点
            ContactPoint contact = co.contacts[0];
            //朝向和位置
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            if (hitPrefab != null) {
				var hitVFX = Instantiate (hitPrefab, pos, rot) as GameObject;

				var ps = hitVFX.GetComponent<ParticleSystem> ();
				if (ps == null) {
					var psChild = hitVFX.transform.GetChild (0).GetComponent<ParticleSystem> ();
					Destroy (hitVFX, psChild.main.duration);
				} else
					Destroy (hitVFX, ps.main.duration);
			}

            Destroy(gameObject);


            //StartCoroutine (DestroyParticle (0f));
        }
	}

	public IEnumerator DestroyParticle (float waitTime) {

		if (transform.childCount > 0 && waitTime != 0) {
			List<Transform> tList = new List<Transform> ();

			foreach (Transform t in transform.GetChild(0).transform) {
				tList.Add (t);
			}		

			while (transform.GetChild(0).localScale.x > 0) {
				yield return new WaitForSeconds (0.01f);
				transform.GetChild(0).localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
				for (int i = 0; i < tList.Count; i++) {
					tList[i].localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
				}
			}
		}
		
		yield return new WaitForSeconds (waitTime);
		Destroy (gameObject);
	}
}
