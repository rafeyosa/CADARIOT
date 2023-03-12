using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphController : MonoBehaviour {
    [SerializeField] private Sprite cicleSprite;
    private RectTransform graphContainer;
    public float paddingLeft;
    public float paddingTop;
    public float paddingRight;
    public float paddingBottom;
    public GraphData graphData;

    void Awake() {
        graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();
    }

    void Update() {
        foreach (Transform objMen in graphContainer) {
             Destroy(objMen.gameObject);
        }
        var graph = graphData.GetInstance();
        ShowGraph(graph.GraphList, graph.min, graph.max);
    }

    private void ShowGraph(List<float> valueList, float min, float max) {
        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;
        float yMinimum = min;
        float yMaximun = max;
        float xMaximun = 100f;

        DrawGraph(graphWidth, graphHeight);

        GameObject lastCircleGameObject = null;
        int length = valueList.Count;
        for (int i = 0; i < length; i++) {
            float xPosition = i * (xMaximun / (length-1)) * ((graphWidth - (paddingLeft + paddingRight)) / xMaximun) + paddingLeft;
            float yPosition = (valueList[i] - yMinimum) * (graphHeight - (paddingTop + paddingBottom)) / (yMaximun - yMinimum) + paddingBottom;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            if (lastCircleGameObject !=  null) {
                CreateDotConnection(
                    lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, 
                    circleGameObject.GetComponent<RectTransform>().anchoredPosition,
                    circleGameObject.GetComponent<RectTransform>().sizeDelta
                );
            }
            lastCircleGameObject = circleGameObject;
        }
    }

    private void DrawGraph(float graphWidth, float graphHeight) {
        float leftPos = 0 + paddingLeft;
        float topPos = graphHeight - paddingTop;
        float rightPos = graphWidth - paddingRight;
        float bottomPos = 0 + paddingBottom;
        float thick = 5 * (graphHeight / 100);

        Vector2 startBottomPoint = new Vector2(leftPos, bottomPos);
        Vector2 topPoint = new Vector2(leftPos, topPos);
        Vector2 endPoint = new Vector2(rightPos, bottomPos);
        Vector2 thickPoint = new Vector2(thick, thick);

        CreateDotConnection(
            topPoint,
            startBottomPoint,
            thickPoint
        );
        CreateDotConnection(
            startBottomPoint,
            endPoint,
            thickPoint
        );
    }

    private GameObject CreateCircle(Vector2 anchoredPosition) {
        float graphHeight = graphContainer.sizeDelta.y;
        float circleSize = 5 * (graphHeight / 100);
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = cicleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(circleSize, circleSize);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB, Vector2 size) {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        float thick = 40 * (size.y / 100);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, thick);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
    }

    private static float GetAngleFromVectorFloat(Vector3 dir) {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
            n += 360;

        return n;
    }
}
