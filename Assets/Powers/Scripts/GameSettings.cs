using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Powers
{
    public class GameSettings : MonoBehaviour
    {

        [Header("Setting Locations")]
        public Camera cam;
        public PlayerLook playerLook;
        public PostProcessLayer postLayer;
        public PostProcessProfile postProcessing;

        [Space(10)]

        [Header("General Settings")]
        public int cameraFOV = 90; //camera fov from 70 to 100
        public int mouseSensitivity = 3; //mouse sensitivity from 1 to 8
        public int antialiasing = 2; //0 is off, 1 is fxaa, 2 is smaa, 3 is msaa

        [Header("Audio Settings")]
        public float gameVolume = 1; //determines game volume

        [Header("Postprocessing Settings")]
        public bool aoEnabled = true; //when on, enable ambient occlusion
        public bool bloomEnabled = true; //when on, enable bloom
        public bool chromAbbEnabled = true; //when on, enable chrome abberation
        public bool motionBlurEnabled = true; //when on, enable motion blur
        public int motionBlurIntensity = 2; //0 is shutter speed 90, 1 is shutter speed 180, 2 is shutter speed 270
        public bool vignetteEnabled = true; //when on, enable vignette

        [Header("Shadow Settings")]
        public bool softShadows = true; //false is hard only, true is soft
        public int shadowQuality = 2; //0 is low, 1 is med, 2 is high
        public int shadowDistance = 2; //0 is low(25), 1 is med(50), 2 is high(75)

        private AmbientOcclusion aoObject;
        private Bloom bloomObject;
        private MotionBlur motionObject;
        private Vignette vignetteObject;

        // Start is called before the first frame update
        void Start()
        {
            aoObject = postProcessing.GetSetting<AmbientOcclusion>();
            bloomObject = postProcessing.GetSetting<Bloom>();
            motionObject = postProcessing.GetSetting<MotionBlur>();
            vignetteObject = postProcessing.GetSetting<Vignette>();
        }

        // Update is called once per frame
        void Update()
        {
            //this is where the general settings are handled
            #region General

            cam.fieldOfView = cameraFOV;
            playerLook.mouseSensitivity = mouseSensitivity;
            AudioListener.volume = gameVolume;

            #endregion

            //this region is where all the postprocessing settings are handled
            #region PostProcessing

            //enable antialiasing depending on setting
            if (antialiasing == 0) postLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
            else if (antialiasing == 1) postLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
            else if (antialiasing == 2) postLayer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
            else if (antialiasing == 3) postLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;

            if (antialiasing == 3) QualitySettings.antiAliasing = 4;
            else QualitySettings.antiAliasing = 0;

            //enable ao depending on setting
            if (aoEnabled) aoObject.enabled.Override(true);
            else aoObject.enabled.Override(false);

            //enable bloom depending on setting
            if (bloomEnabled) bloomObject.enabled.Override(true);
            else bloomObject.enabled.Override(false);

            //enable motion blur depending on setting
            if (motionBlurEnabled) motionObject.enabled.Override(true);
            else motionObject.enabled.Override(false);

            //set motion blur shutter angle depending on setting
            if (motionBlurIntensity == 0) motionObject.shutterAngle.Override(90);
            else if (motionBlurIntensity == 1) motionObject.shutterAngle.Override(180);
            else if (motionBlurIntensity == 2) motionObject.shutterAngle.Override(270);

            #endregion

            //this region is where all the shadow settings are handled
            #region Shadows

            //sets whether or not shadows can be soft depending on setting
            if (softShadows) QualitySettings.shadows = ShadowQuality.All;
            else QualitySettings.shadows = ShadowQuality.HardOnly;

            //sets shadow resolution depending on setting
            if (shadowQuality == 0) QualitySettings.shadowResolution = ShadowResolution.Low;
            else if (shadowQuality == 1) QualitySettings.shadowResolution = ShadowResolution.Medium;
            else if (shadowQuality == 2) QualitySettings.shadowResolution = ShadowResolution.High;

            //sets shadow distance depending on setting
            if (shadowDistance == 0) QualitySettings.shadowDistance = 25;
            else if (shadowDistance == 1) QualitySettings.shadowDistance = 50;
            else if (shadowDistance == 2) QualitySettings.shadowDistance = 75;

            #endregion

        }
    }
}
