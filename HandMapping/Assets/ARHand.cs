using UnityEngine;

public class ARHand {
    private Vector3[] landmarks;
    public float currentDepth = 0f;
    private Camera cam;

    public ARHand() {
        landmarks = new Vector3[21];
        cam = Camera.main;
    }
    
    private ARHand(Vector3[] landmarks) {
        this.landmarks = landmarks;
    }

    public void ParseFrom(float[] arr, float c) {
        if (null == arr || arr.Length < 63) return;

        for (int i = 0; i < 21; i++) {
            float xScreen = Screen.width * ((arr[i * 3 + 1] - 0.5f * (1 - c)) / c);
            float yScreen = Screen.height * (arr[i * 3]);
            this.landmarks[i] = cam.ScreenToWorldPoint(new Vector3(xScreen, yScreen, arr[i * 3 + 2] / 80 + 0.4f));
        }
    }

    public Vector3 GetLandmark(int index) => this.landmarks[index];
    public Vector3[] GetLandmarks() => this.landmarks;
    public ARHand Clone() {
        return new ARHand((Vector3[])landmarks.Clone());
    }

}