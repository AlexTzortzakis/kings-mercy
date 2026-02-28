using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour {
	public Animator anim;

	[Tooltip("Tag of the object that can open the door")]
	public string openerTag = "Player";

	[Tooltip("Animator bool parameter to open the door")]
	public string openParam = "DoorOpen";

	[Tooltip("Animator bool parameter to close the door")]
	public string closeParam = "DoorClose";

	void Awake() {
		if (anim == null) {
			anim = GetComponentInChildren<Animator>();
		}

		if (anim == null) {
			Debug.LogWarning(name + ": Animator not found on this GameObject or its children.");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (!other.CompareTag(openerTag)) return;
		if (anim == null) return;

		anim.SetBool(openParam, true);
		anim.SetBool(closeParam, false);
	}

	void OnTriggerExit(Collider other) {
		if (!other.CompareTag(openerTag)) return;
		if (anim == null) return;

		anim.SetBool(openParam, false);
		anim.SetBool(closeParam, true);
	}
}
