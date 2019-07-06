using UnityEngine;

namespace Platinio
{
    public enum PivotPreset
    {
        UpperLeft,
        UpperCenter,
        UpperRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        LowerLeft,
        LowerCenter,
        LowerRight        
    }

    /// <summary>
    /// This script help you convert anchored positions to absolute positions, so you can animate and position exactly ui elements witouh messing around with anchors
    /// </summary>
    

    //use this to position UI in absolute coordenates
    //0.0 , 1.0 _______________________1.0 , 1.0
    //          |                      |
    //          |                      |                  
    //          |                      |
    //          |                      |
    //0.0 , 0.0 |______________________| 1.0 , 0.0

    public static class RectTransformHelper
    {
        private static RectTransform targetCanvas = null;

        public static Vector2 FromAbsolutePositionToAnchoredPosition(this RectTransform rect, Vector2 point, RectTransform canvas, PivotPreset anchor = PivotPreset.MiddleCenter)
        {            
            Vector2 centerAnchor = ( rect.anchorMax + rect.anchorMin ) * 0.5f;          
            return Vector2.Scale( point - centerAnchor, canvas.rect.size ) + Vector2.Scale( rect.rect.size, GetAnchorOffSet( anchor ) );
        }

        public static Vector2 FromAbsolutePositionToAnchoredPosition(this RectTransform rect, Vector2 point, PivotPreset anchor = PivotPreset.MiddleCenter)
        {
            Vector2 centerAnchor = ( rect.anchorMax + rect.anchorMin ) * 0.5f;
            return Vector2.Scale( point - centerAnchor, RequestCanvas().rect.size ) + Vector2.Scale( rect.rect.size, GetAnchorOffSet( anchor ) );
        }

        public static Vector2 FromAbsolutePositionToAnchoredPosition(this RectTransform rect, Vector2 point, RectTransform canvas, Vector2 pivot)
        {
            Vector2 centerAnchor = ( rect.anchorMax + rect.anchorMin ) * 0.5f;
            return Vector2.Scale( point - centerAnchor, canvas.rect.size ) + Vector2.Scale( rect.rect.size, pivot * 0.5f );
        }

        public static Vector2 FromAbsolutePositionToAnchoredPosition(this RectTransform rect, Vector2 point, Vector2 pivot)
        {
            Vector2 centerAnchor = ( rect.anchorMax + rect.anchorMin ) * 0.5f;
            return Vector2.Scale( point - centerAnchor, RequestCanvas().rect.size ) + Vector2.Scale( rect.rect.size, pivot * 0.5f );
        }

        public static Vector2 FromAnchoredPositionToAbsolutePosition(this RectTransform rect, RectTransform canvas , PivotPreset anchor = PivotPreset.MiddleCenter)
        {
            Vector2 centerAnchor = ( rect.anchorMax + rect.anchorMin ) * 0.5f;
            return new Vector2( rect.anchoredPosition.x / canvas.rect.size.x, rect.anchoredPosition.y / canvas.rect.size.y ) + Vector2.Scale( rect.rect.size, GetAnchorOffSet( anchor ) );
        }

        public static Vector2 FromAnchoredPositionToAbsolutePosition(this RectTransform rect, RectTransform canvas , Vector2 pivot)
        {
            Vector2 centerAnchor = ( rect.anchorMax + rect.anchorMin ) * 0.5f;
            return new Vector2( rect.anchoredPosition.x / canvas.rect.size.x, rect.anchoredPosition.y / canvas.rect.size.y ) + Vector2.Scale( rect.rect.size, pivot * 0.5f);
        }

        public static Vector2 FromAnchoredPositionToAbsolutePosition(this RectTransform rect, PivotPreset anchor = PivotPreset.MiddleCenter)
        {
            Vector2 centerAnchor = ( rect.anchorMax + rect.anchorMin ) * 0.5f;
            return new Vector2( rect.anchoredPosition.x / RequestCanvas().rect.size.x, rect.anchoredPosition.y / RequestCanvas().rect.size.y ) + Vector2.Scale( rect.rect.size, GetAnchorOffSet( anchor ) );
        }

        public static Vector2 FromAnchoredPositionToAbsolutePosition(this RectTransform rect, Vector2 pivot)
        {
            Vector2 centerAnchor = ( rect.anchorMax + rect.anchorMin ) * 0.5f;
            return new Vector2( rect.anchoredPosition.x / RequestCanvas().rect.size.x, rect.anchoredPosition.y / RequestCanvas().rect.size.y ) + Vector2.Scale( rect.rect.size, pivot * 0.5f );
        }

        private static RectTransform RequestCanvas()
        {
            //we have a canvas in cache?
            if (targetCanvas != null)
                return targetCanvas;

            Canvas canvas = null;

            //just return the first encounter canvas
            canvas = GameObject.FindObjectOfType<Canvas>();

            if (canvas != null)
            {
                targetCanvas = canvas.GetComponent<RectTransform>();
                return targetCanvas;
            }
                

            return null;
        }

        private static Vector2 GetAnchorOffSet(PivotPreset anchor)
        {
            switch (anchor)
            {
                case PivotPreset.UpperLeft:
                return new Vector2( 0.5f, -0.5f );
                case PivotPreset.UpperCenter:
                return new Vector2( 0.0f, -0.5f );
                case PivotPreset.UpperRight:
                return new Vector2( -0.5f, -0.5f );
                case PivotPreset.MiddleLeft:
                return new Vector2( 0.5f, 0.0f );
                case PivotPreset.MiddleCenter:
                return new Vector2( 0.0f, 0.0f );
                case PivotPreset.MiddleRight:
                return new Vector2( -0.5f, 0.0f );
                case PivotPreset.LowerLeft:
                return new Vector2( 0.5f, 0.5f );
                case PivotPreset.LowerCenter:
                return new Vector2( 0.0f, 0.5f );
                case PivotPreset.LowerRight:
                return new Vector2( -0.5f, 0.5f );
            }

            return Vector2.zero;

        }

        
    }
}

