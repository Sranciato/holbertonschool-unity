using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetFound : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public GameObject gmail, twitter, linkedIn, medium, myName;
    private Animator aGmail, aTwitter, aLinkedIn, amedium, aMyName;
    void Start()
    {
        aGmail = gmail.GetComponent<Animator>();
        aTwitter = twitter.GetComponent<Animator>();
        aLinkedIn = linkedIn.GetComponent<Animator>();
        amedium = medium.GetComponent<Animator>();
        aMyName = myName.GetComponent<Animator>();
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
			// Play audio when target is found
			Debug.Log("FOUND TARGET");
            aTwitter.Play("twit", -1, 0f);
            aLinkedIn.Play("link", -1, 0f);
            amedium.Play("medi", -1, 0f);
            aMyName.Play("name", -1, 0f);
            aGmail.Play("New Animation", -1, 0f);
        }
        else
        {
			// Stop audio when target is lost
			Debug.Log("LOST");
        }
    }	
}
