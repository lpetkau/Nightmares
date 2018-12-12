using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{

    [Header("Settings")]
    [Tooltip("The Camera Who Scans for light")]
    public Camera m_camLightScan;
    [Tooltip("Show the light value in the log")]
    public bool m_blogLightValue = false;
    [Tooltip("Time Between light val updates")]
    public float m_fUpdatetime = 0.1f;

    public static float m_flightValue;

    private const int c_iTextureSize = 1;

    private Texture2D m_texlight;
    private RenderTexture m_texTemp;
    private Rect m_rectLight;
    private Color m_LightPixel;

    private void Start()
    {
        StartLightDetection();
    }

    //Prepare all Needed Variables and start the light detection coroutine

    private void StartLightDetection()
    {
        m_texlight = new Texture2D(c_iTextureSize, c_iTextureSize, TextureFormat.RGB24, false);
        m_texTemp = new RenderTexture(c_iTextureSize, c_iTextureSize, 24);
        m_rectLight = new Rect(0f, 0f, c_iTextureSize, c_iTextureSize);

        StartCoroutine(LightDetectionUpdate(m_fUpdatetime));
    }

    //Update the light value

    private IEnumerator LightDetectionUpdate(float m_fUpdatetime)
    {
        while (true)
        {
            // SAet the target texture of the cam
            m_camLightScan.targetTexture = m_texTemp;
            //Render into the set target texture
            m_camLightScan.Render();

            // set the target texture as the active rendererd texture
            RenderTexture.active = m_texTemp;
            // read the active rendered texture
            m_texlight.ReadPixels(m_rectLight, 0, 0);
            //reset the active rendered texture
            RenderTexture.active = null;
            // reset the tar=get texture of the cam
            m_camLightScan.targetTexture = null;
            //read the textures in the middle of the texture.
            m_LightPixel = m_texlight.GetPixel(c_iTextureSize / 2, c_iTextureSize / 2);
            //calculate light value, based on color intensity
            m_flightValue = (m_LightPixel.r + m_LightPixel.g + m_LightPixel.b) / 3f;

            if (m_blogLightValue)
            {
                Debug.Log("Light Value: " + m_flightValue);
            }


            yield return new WaitForSeconds(m_fUpdatetime);
        }
    }
}