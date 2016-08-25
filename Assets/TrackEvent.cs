﻿using UnityEngine;

using  Vuforia;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class TrackEvent : MonoBehaviour,ITrackableEventHandler
{
	#region PRIVATE_MEMBER_VARIABLES

	private TrackableBehaviour mTrackableBehaviour;

	#endregion // PRIVATE_MEMBER_VARIABLES

	#region PUBLIC_MEMBER

	public GameObject target;
	public GameObject canvas;
	#endregion

	#region UNTIY_MONOBEHAVIOUR_METHODS

	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	#endregion // UNTIY_MONOBEHAVIOUR_METHODS



	#region PUBLIC_METHODS

	/// <summary>
	/// Implementation of the ITrackableEventHandler function called when the
	/// tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			OnTrackingFound();
		}
		else
		{
			OnTrackingLost();
		}
	}

	#endregion // PUBLIC_METHODS



	#region PRIVATE_METHODS


	private void OnTrackingFound()
	{
		target.SetActive (true);


		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
	}


	private void OnTrackingLost()
	{
		target.SetActive (false);

//		}

		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
	}

	#endregion // PRIVATE_METHODS

}
