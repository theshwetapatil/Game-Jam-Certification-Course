using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform follow;
    public float lerpSpeed = 3f;

    private Vector3 offset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - follow.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowObject();
    }

    private void FollowObject()
    {
        Vector3 targetPos = follow.transform.position + offset;
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * lerpSpeed);

        Quaternion targetRot = Quaternion.LookRotation(follow.position - this.transform.position);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRot, Time.deltaTime * lerpSpeed);
    }
}
