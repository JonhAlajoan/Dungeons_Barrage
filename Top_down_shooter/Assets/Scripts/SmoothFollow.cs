using UnityEngine;
using System.Collections;
using UnityEngine.PostProcessing;
public class SmoothFollow : MonoBehaviour {

    GameObject objectTarget;
    public Transform target;
	Transform aux;
	Transform aux2;
    public float cameraSpeed = 15;
    public float zOffset = 22;
	public float xOffset = 9;
    public bool smoothFollow = true;
	public Transform targetCrosshair;
	int flag = 0;

    private GameObject thisCamera;
    public PostProcessingProfile ppProfile;
    private Camera objectCameraPP;
    Transform cameraPos;

    void Start(){

		targetCrosshair = targetCrosshair.GetComponent<Transform> ();
        objectTarget = GameObject.FindGameObjectWithTag("PlayerHP");
        target = objectTarget.GetComponent<Transform>();

        objectCameraPP = Camera.main;
        ppProfile = objectCameraPP.GetComponent<PostProcessingBehaviour>().profile;

        aux = gameObject.transform;
		aux2 = target;
	}
	
    public void setCameraSpeed(float cameraSpeedLerp)
    {
        cameraSpeed = cameraSpeedLerp;
    }

	void LateUpdate () 
    {
		if(targetCrosshair && Input.GetKey(KeyCode.Space)){

			Vector3 newPos2 = transform.position;

			newPos2.x = Mathf.Clamp (targetCrosshair.position.x,target.position.x - 5,target.position.x + 10 ) - xOffset;
			newPos2.z = Mathf.Clamp (targetCrosshair.position.z, target.position.z - 5,target.position.z + 10  )  - zOffset;

			if (!smoothFollow)
				transform.position = newPos2;
			else
				transform.position = Vector3.Lerp (transform.position, newPos2, cameraSpeed * Time.deltaTime);



		}

        else if (target)
        {
            Vector3 newPos = transform.position;
            newPos.x = target.position.x;
            newPos.z = target.position.z - zOffset;
            newPos.y = target.position.y + 15;

            if (!smoothFollow) transform.position = newPos;
            else transform.position = Vector3.Lerp(transform.position, newPos, cameraSpeed * Time.deltaTime);
        }
	
	}

    public void Shake(float amplitude, float duration, float intensityChromaticAberration, float dampStartPercentage = 0.75f)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeCamera(amplitude, duration, intensityChromaticAberration, dampStartPercentage));
    }

    private IEnumerator ShakeCamera(float amplitude, float duration, float intensityChromaticAberration, float dampStartPercentage)
    {
        //ensure percentage is in a valid range
        dampStartPercentage = Mathf.Clamp(dampStartPercentage, 0.0f, 1.0f);

        float elapsedTime = 0.0f;
        float damp = 1.0f;

        //  Vector3 cameraOrigin = cameraPos.transform.position;
 

        while (elapsedTime < duration)
        {
            //Parte Que faz a aberração cromática ficar louca;
            ppProfile.chromaticAberration.enabled = true;
            var chromAberration = ppProfile.chromaticAberration.settings;
            chromAberration.intensity = intensityChromaticAberration;
            ppProfile.chromaticAberration.settings = chromAberration;

            elapsedTime += Time.deltaTime;

            float percentComplete = elapsedTime / duration;

            if (percentComplete >= dampStartPercentage && percentComplete <= 1.0f)
            {
                damp = 1.0f - percentComplete;
            }

            yield return null;

        }
        var chromaAberration = ppProfile.chromaticAberration.settings;
        ppProfile.chromaticAberration.enabled = false;

    }
}
