# Unity Augmented Reality Application – Virtual Watering Can on QR Code

Unity augmented reality application that spawns a virtual watering can on a defined QR Code
When running the application, looking at a defined QR code will make the desired object appear.  
By default, this object is a watering can.  

This project was built using **Unity version 6000.0.38f1**.

---

## ⚠️ Warning
This project **only works on the Meta Quest 3** due to the use of the **Passthrough Camera API**.  
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

- **Passthrough Camera API** : Access to the Meta Quest camera.  
- **Zxing** : QR code detection and reading.  

---

## ➕ Adding New QR Codes and new object to spawn

It is possible to add/change the QR codes being detected and the objects spawnig:

1. In the **SampleScene**, select the **QrCodeDetection** object from the hierarchy.  
2. In its **QrCodeTargets** field, you can add new `QrCodeTarget` objects.  
   - Each target contains:
     - The link to the QR code.  
     - The object that should appear when the QR code is detected.  
3. Click the **“+”** button to add new entries.  

---

## 🙌 Credits

- This project is based on the tutorial named [¿Como acceder a la cámara de Meta Quest 3 y 3s? - Passthrough Camera Api](https://www.youtube.com/watch?v=GAyt-LP7Bv8) from the YouTube channel [Unity Adventure](https://www.youtube.com/@UnityAdventure).  
- [3D watering can asset link](https://sketchfab.com/3d-models/watering-can-derivative-b2432b27683f46f48cc2b6d532bd5525)  
