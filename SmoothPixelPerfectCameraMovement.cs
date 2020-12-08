using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode][RequireComponent(typeof(PixelPerfectCamera), typeof(Camera))]
public class SmoothPixelPerfectCameraMovement : MonoBehaviour
{
    private PixelPerfectCamera pcc;
    private Camera camera;

    private void OnValidate()
    {
        camera = GetComponent<Camera>();
        pcc = GetComponent<PixelPerfectCamera>();
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Vector2 screenWorldBounds = new Vector2(camera.orthographicSize * 2 * Screen.width / Screen.height, camera.orthographicSize * 2);
        Vector2 direction = new Vector2(Mathf.Round(transform.position.x * pcc.assetsPPU) / pcc.assetsPPU - transform.position.x, Mathf.Round(transform.position.y * pcc.assetsPPU) / pcc.assetsPPU - transform.position.y);
        Graphics.Blit(source, destination, Vector2.one, -(direction / screenWorldBounds));
    }
}
