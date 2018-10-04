using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraShake : MonoBehaviour {

    private GameObject thisCamera;
    public PostProcessingProfile ppProfile;
    private Camera objectCameraPP;
    Transform cameraPos;

    void Start()
    {
        
        objectCameraPP = Camera.main;
        ppProfile = objectCameraPP.GetComponent<PostProcessingBehaviour>().profile;
        thisCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void LateUpdate()
    {
        cameraPos = thisCamera.GetComponent<Transform>();
    }

    public void Shake(float amplitude, float duration, float intensityChromaticAberration, float dampStartPercentage = 0.75f)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeCamera(amplitude, duration,intensityChromaticAberration, dampStartPercentage));
    }

    private IEnumerator ShakeCamera(float amplitude, float duration,float intensityChromaticAberration, float dampStartPercentage)
    {
        //ensure percentage is in a valid range
        dampStartPercentage = Mathf.Clamp(dampStartPercentage, 0.0f, 1.0f);
        
        float elapsedTime = 0.0f;
        float damp = 1.0f;

      //  Vector3 cameraOrigin = cameraPos.transform.position;
        Quaternion cameraOriginRotation = cameraPos.transform.rotation;

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

            Vector3 offsetValues = new Vector3 (Random.Range(cameraPos.transform.position.x * -2,cameraPos.transform.position.x *2),0,
                Random.Range(cameraPos.transform.position.z * -2f, cameraPos.transform.position.z * 2f));
         

            offsetValues *= amplitude * damp;

                cameraPos.transform.position = new Vector3(offsetValues.x, 15 , offsetValues.z - 10 );
            yield return null;
            
        }
        var chromaAberration = ppProfile.chromaticAberration.settings;
        ppProfile.chromaticAberration.enabled = false ;
      
    }

}
