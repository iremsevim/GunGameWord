using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;
public class SwitchCamera : GameSingleActor<SwitchCamera>
{
    public List<CameraProfile> cameraProfiles;
   [System.Serializable]
    public class CameraProfile
    {
        public CameraType cameraType;
        public GameObject cinemachinecam;
    }
    public void Switch(CameraType camera)
    {
        cameraProfiles.ForEach(X => X.cinemachinecam.SetActive(false));
       CameraProfile findedcamera= cameraProfiles.Find(x => x.cameraType == camera);
        if(findedcamera.cinemachinecam)
        {
            findedcamera.cinemachinecam.SetActive(true);
        }
    }
    public enum CameraType
    {
        firstCamera,
        keysCamera
    }
}
