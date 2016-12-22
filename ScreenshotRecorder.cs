using UnityEngine;
using System.Collections;

public class ScreenshotRecorder : MonoBehaviour
{

    // Place this on the camera you want to render.
    // Scale the Game view to the desired output size.
    // Supersize Factor will multiply the game view size.

    [Tooltip("Whether or not to record screens in play mode")]
    public bool recordOnPlay = true;

    [Tooltip("The framerate in which to render the image")]
    public int framerate = 60;

    [Tooltip("The factor by which to scale up the final image output. Will produce a clearer image, but takes longer to render.")]
    public int supersizeFactor = 1;

    [Tooltip("The folder in which to save the frames. Must already exist inside the project's root folder.")]
    public string folderName = "trailer";

    [Tooltip("The name of the files. Will be appended with an incremental number, and the extension.")]
    public string fileName = "trailer-frame";

    [Tooltip("The file type, without the dot.")]
    public string suffix = "png";

    string filename = "";

    void Awake()
    {
        Time.captureFramerate = framerate;
        filename = folderName + "/" + fileName;
    }

    void Update()
    {
        if (recordOnPlay)
        {
            string frame = Time.frameCount.ToString("0000");
            Application.CaptureScreenshot(filename + frame + "." + suffix, supersizeFactor);
        }
    }
}