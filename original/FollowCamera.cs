using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public Transform follow;
    public float lerpSpeed = 3f;

    private Vector3 offset = Vector3.zero;

	void Start () {
        offset = this.transform.position - follow.position;
	}
	
	void LateUpdate () {
        FollowObject();

    }

    private void FollowObject ()
    {
        Vector3 targetPos = follow.transform.position + offset;
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * lerpSpeed);

        Quaternion targetRot = Quaternion.LookRotation(follow.position - this.transform.position);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRot, Time.deltaTime * lerpSpeed);
    }
}
