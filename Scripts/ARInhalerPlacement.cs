using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARInhalerPlacement : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject inhalerPrefab;

    private GameObject placedInhaler;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            PlaceInhaler(touch.position);
        }
    }

    void PlaceInhaler(Vector2 screenPosition)
    {
        if (raycastManager.Raycast(
            screenPosition,
            hits,
            TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (placedInhaler == null)
            {
                placedInhaler = Instantiate(
                    inhalerPrefab,
                    hitPose.position,
                    hitPose.rotation
                );
            }
            else
            {
                placedInhaler.transform.position = hitPose.position;
            }
        }
    }
}