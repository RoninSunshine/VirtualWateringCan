# Unity Augmented Reality Application – Virtual Watering Can on QR Code

Unity augmented reality application that spawns a virtual watering can on a defined QR Code. \
When running the application, looking at a defined QR code will make the desired object appear.  
By default, this object is a watering can.  

This project was built using **Unity version 6000.0.38f1**.

---

## ⚠️ Warning
This project **only works on the Meta Quest 3** due to the use of the [**Passthrough Camera API.**](https://github.com/oculus-samples/Unity-PassthroughCameraApiSamples)
Running it through **Meta Quest Link** directly from the Unity editor and the Play button will **not work**.

---

## 🚀 How to Launch the Project

1. Open the project with Unity.  
2. From the main interface, go to **File → Build Profiles**.  
3. In the *Build Profiles* window, select the **Android** platform and click **Switch Platform**.  
4. In the same interface, go to **Platform Settings → Run Device** and select the connected headset.  
5. Click **Build And Run** to launch the application.  

---

## 🛠️ Project Components

- [**Passthrough Camera API**](https://github.com/oculus-samples/Unity-PassthroughCameraApiSamples) : Access to the Meta Quest camera.  
- **Zxing** : QR code detection and reading. ([Download link given by the tutorial](https://www.youtube.com/redirect?event=video_description&redir_token=QUFFLUhqbDNnLW5sWjRteEZER2hGb1JtZ0FmcVJma0s5UXxBQ3Jtc0trTWdrWDF2U21HTndvUDY3WmRXbDU1R3JaNlpGQ2F0NDNKckxxS0hlSkNTSV9yMmxmbjJGZDRTQTFfREtyNUVRNUtoRW5NVVd4LUR3Q0dLSzZDb3R2MW1IeXVxVnRTeFdMSVJrcnk0WmM4Mkxkc0JYaw&q=https%3A%2F%2Fdrive.google.com%2Fuc%3Fexport%3Ddownload%26id%3D1tQuPhWW_vGYubkHTMYv-bA5y_Vd06Btl&v=GAyt-LP7Bv8)) 

---

## ➕ Adding New QR Codes and new objects to spawn

It is possible to add/change the QR codes being detected and the objects spawnig:

1. In the scene called **SampleScene**, select the **QrCodeDetection** object from the hierarchy. \
In its **QrCodeTargets** field, you can add new `QrCodeTarget` objects.  
   - Each target contains:
     - The link to the QR code.  
     - The object that should appear when the QR code is detected.  
2. Click the **“+”** button to add new entries.   

---

## 🙌 Credits

- This project is based on the tutorial named [¿Como acceder a la cámara de Meta Quest 3 y 3s? - Passthrough Camera Api](https://www.youtube.com/watch?v=GAyt-LP7Bv8) from the YouTube channel [Unity Adventure](https://www.youtube.com/@UnityAdventure).  
- [3D watering can asset link](https://sketchfab.com/3d-models/watering-can-derivative-b2432b27683f46f48cc2b6d532bd5525)  
