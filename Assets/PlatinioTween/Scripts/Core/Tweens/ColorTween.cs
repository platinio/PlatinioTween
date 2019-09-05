using UnityEngine;

namespace Platinio.TweenEngine
{
    public class ColorTween : BaseTween
    {
        private Color from = Color.white;
        private Color to = Color.white;

        public ColorTween(Color from, Color to, float t, int id)
        {
            this.from = from;
            this.to = to;
            this.duration = t;
            this.id = id;
        }

        public override void Update(float deltaTime)
        {
           
            //wait a delay
            if (delay > 0.0f)
            {
                delay -= deltaTime;
                return;
            }

            base.Update( deltaTime );

            //start counting time
            currentTime += deltaTime;

            //if time ends
            if (currentTime >= duration)
            {
                if (onUpdateColor != null)
                    onUpdateColor( this.to );

                onComplete();
                return;
            }

            /*
            Vector3 to = new Vector3( this.to.r, this.to.g, this.to.b );
            Vector3 from = new Vector3( this.from.r, this.from.g, this.from.b );

            //get new value
            Vector3 change = to - from;
            Vector3 value = Equations.ChangeVector( currentTime, from, change, duration, ease );

            //get new value
            float alphaChange = this.to.a - this.from.a;
            float alphaValue = Equations.ChangeFloat( currentTime, this.from.a, alphaChange, duration, ease );
            */
            Color color = Color.LerpUnclamped(from , to , EasingFunctions.ChangeFloat(0.0f , 1.0f , currentTime / duration , ease));

            //call update if we have it
            if (onUpdateColor != null)
                onUpdateColor( color );
        }
    }

}

