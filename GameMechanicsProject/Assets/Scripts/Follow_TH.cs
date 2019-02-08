using UnityEngine;

public class Follow_TH : MonoBehaviour
{
	[SerializeField]
	private Transform littleTarget, bigTarget;

	[SerializeField]
	private float smoothSpeed =.125f;
	public Vector3 offset;

	private bool littleCam, bigCam;


	private void Start()
	{
		littleCam = true;
		bigCam = false;
	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.E))
		{
			if(littleCam == true)
			{
				littleCam = false;
				bigCam = true;

			}
			else if (littleCam == false)
			{
				bigCam = false;
				littleCam = true;

			}
		}
		

		if (littleCam)
		{
			Vector3 desiredPosition = littleTarget.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			transform.position = smoothedPosition;

			transform.LookAt(littleTarget);
		}

		if (bigCam)
		{
			Vector3 desiredPosition = bigTarget.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			transform.position = smoothedPosition;

			transform.LookAt(bigTarget);
		}
	}
}
