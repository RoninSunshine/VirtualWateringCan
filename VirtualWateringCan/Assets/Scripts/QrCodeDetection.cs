using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using PassthroughCameraSamples;
using ZXing;
using Meta.XR;

public class QrCodeDetection : MonoBehaviour
{


    [SerializeField] private WebCamTextureManager webCamManager; // To access camera image
    [SerializeField] private int scanFrameFrequency = 120; // Number of times per second the image is checked to find the QR Code
    [SerializeField] private EnvironmentRaycastManager raycastManager; // Convert a 2d position in the image in a 3d position in a world
    private BarcodeReader barcodeReader = new BarcodeReader();
    private bool isCameraReady;


    [System.Serializable] // System make the structure visible in the inspector
    public struct QrCodeTarget
    {
        public string QrCodeContent; // Content of the qr code
        public Transform Object; // Object associated with the qr code
    }

    [SerializeField] private List<QrCodeTarget> qrCodeTargets = new List<QrCodeTarget>(); // List of all the Qr Code targets
    private Dictionary<string, Transform> qrCodeTargetsDic = new Dictionary<string, Transform>(); // To avoid searching in the list 




    // Start is called before the first frame update
    IEnumerator Start()
    {
        foreach (var qrCodeTarget in qrCodeTargets) // Fill the dictionary
        {
            qrCodeTargetsDic.Add(qrCodeTarget.QrCodeContent, qrCodeTarget.Object);
        }

        while (webCamManager.WebCamTexture == null) //  Wait for the camera to be ready
        {
            yield return null;
        }

        isCameraReady = true;
    }

    void Update()
    {
        if (isCameraReady && Time.frameCount % scanFrameFrequency == 0)
        {
            WebCamTexture webCamTexture = webCamManager.WebCamTexture;

            if (webCamTexture == null || webCamTexture.width <= 16 || webCamTexture.height <= 16)
            {
                return;
            }

            Color32[] camPixels = webCamTexture.GetPixels32();

            Result result = barcodeReader.Decode(camPixels, webCamTexture.width, webCamTexture.height);

            if (result != null)
            {
                if (qrCodeTargetsDic.TryGetValue(result.Text, out Transform obj))
                {
                    Vector2Int qrCodeCenter = GetQrCodeCenter(result.ResultPoints, webCamTexture.height);
                    Pose pose = ConvertScreenPointToWorldPoint(qrCodeCenter);
                    obj.SetPositionAndRotation(pose.position, pose.rotation);
                }
            }
        }
    }


    // Find the center of the QrCode within the camera image
    private Vector2Int GetQrCodeCenter(ResultPoint[] resultPoints, int textureHeight)
    {
        if (resultPoints == null || resultPoints.Length == 0)
        {
            return Vector2Int.zero;
        }

        float sumX = 0;
        float sumY = 0;

        foreach (var point in resultPoints)
        {
            sumX += point.X;
            sumY += point.Y;
        }

        float x = sumX / resultPoints.Length;
        float y = sumY / resultPoints.Length;

        int centerX = Mathf.RoundToInt(x);
        int centerY = Mathf.RoundToInt(textureHeight - y);

        return new Vector2Int(centerX, centerY);
    }
    
    //Convert the 2d point of an image to a 3d point in world
     private Pose ConvertScreenPointToWorldPoint(Vector2Int screenPoint) 
    {
        Ray ray = PassthroughCameraUtils.ScreenPointToRayInWorld(webCamManager.Eye, screenPoint);
        if(raycastManager.Raycast(ray, out EnvironmentRaycastHit hitInfo)) 
        {
            Pose pose = new Pose(hitInfo.point, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
            return pose;
        }
        return Pose.identity;
    }




}
