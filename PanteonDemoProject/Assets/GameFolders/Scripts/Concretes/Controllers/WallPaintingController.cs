using System.Collections.Generic;
using PanteonDemoProject.Abstracts.GameState;
using PanteonDemoProject.Abstracts.Inputs;
using PanteonDemoProject.Concretes.Managers;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Controllers
{
    public class WallPaintingController : MonoBehaviour
    {
        [SerializeField] Camera _paintingCamera;
        [SerializeField] GameObject _brush;
        [SerializeField] Transform _rendererWall;
        [SerializeField] RenderTexture _wallRenderTexture;

        [SerializeField] int _objectPoolSize = 2000;

        Queue<GameObject> _objectPool;

        InputData _inputData;
        Vector3 _distanceBetweenWalls;

        int _basePixels = 0;
        int _paintedPixels = 0;


        void Awake()
        {
            _inputData = new InputData();
            _objectPool = new Queue<GameObject>(); // Creating a queue for object pool

            ObjectPooling();
        }

        void OnEnable()
        {
            GameManager.Instance.OnReadyToRun += ResetPool;
        }

        void Start()
        {
            _distanceBetweenWalls = _rendererWall.transform.position - transform.position;
        }

        void FixedUpdate()
        {
            if (_inputData.IsClicking && GameManager.Instance.GameState == GameStates.InPainting)
            {
                Ray ray = Camera.main.ScreenPointToRay(_inputData.MousePosition); // Casting a ray from screen to wall
                RaycastHit hit;
                Vector3 brushPosition = Vector3.zero;

                if (Physics.Raycast(ray, out hit))
                {
                    MeshCollider meshCollider = hit.collider as MeshCollider;
                    if (meshCollider == null)
                        return;

                    brushPosition = hit.point + _distanceBetweenWalls;

                    GameObject brushClone = GetPooledObject();

                    brushClone.transform.localPosition = brushPosition;
                    brushClone.transform.rotation = hit.transform.rotation;

                    UpdatePercentage();
                }
            }
        }

        void UpdatePercentage()
        {
            GameManager.Instance.InitializeOnPercentageIncrease(CalculatePaintingPercentage());
        }

        int CalculatePaintingPercentage()
        {
            RenderTexture.active = _wallRenderTexture; // activating unity render engine for creating a texture
            Texture2D renderTexture2D = new Texture2D(_wallRenderTexture.width, _wallRenderTexture.height); // Creating a Texture2D sized to wallRenderTexture in sight of paintingWallCamera
            renderTexture2D.ReadPixels(new Rect(0, 0, _wallRenderTexture.width, _wallRenderTexture.height), 0, 0); // Reading total pixel count of it
            renderTexture2D.Apply(); // Finish rendering
            RenderTexture.active = null;

            _basePixels = renderTexture2D.width * renderTexture2D.height; // Taking total pixel count as a value.
            _paintedPixels = 0;

            Color[] basePixelColors = renderTexture2D.GetPixels();

            // Detect how many pixels are painted red
            foreach (Color pixelColor in basePixelColors)
            {
                if (pixelColor.b == 0)
                {
                    _paintedPixels++;
                }
            }

            int percentage = Mathf.CeilToInt(_paintedPixels * 100 / basePixelColors.Length);

            if (percentage > 98.5f)
                GameManager.Instance.InitializeOnPaintingGameWon();

            return percentage;
        }

        void ObjectPooling()
        {
            for (int i = 0; i < _objectPoolSize; i++)
            {
                GameObject brushClone = Instantiate(_brush);

                _objectPool.Enqueue(brushClone);
            }
        }

        GameObject GetPooledObject()
        {
            GameObject brushClone = _objectPool.Dequeue();

            brushClone.SetActive(true);

            _objectPool.Enqueue(brushClone);

            return brushClone;
        }

        void ResetPool()
        {
            foreach (GameObject brushClone in _objectPool)
            {
                brushClone.SetActive(false);
                brushClone.transform.position = Vector3.zero;
            }
        }

        void OnDisable()
        {
            GameManager.Instance.OnReadyToRun -= ResetPool;
        }
    }
}