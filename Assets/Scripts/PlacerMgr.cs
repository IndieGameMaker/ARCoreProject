using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class PlacerMgr : MonoBehaviour
{
    public Camera arCamera;
    public GameObject andy;

    void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (Input.touchCount < 1 || touch.phase != TouchPhase.Began)
        {
            return;
        }
        
        //손가락 하나 이상 터치/ 터치 시작일 경우 실행
        TrackableHit hit;
        TrackableHitFlags flags = TrackableHitFlags.PlaneWithinPolygon 
                                | TrackableHitFlags.FeaturePointWithSurfaceNormal;

        if (Frame.Raycast(touch.position.x, touch.position.y, flags, out hit))
        {
            //Anchor 생성
            var anchor = hit.Trackable.CreateAnchor(hit.Pose);
            //Andy 캐릭터 생성 (생성한 앵커 하위로 생성)
            GameObject obj = Instantiate(andy, hit.Pose.position, hit.Pose.rotation, anchor.transform);
            
        }

    }
}
