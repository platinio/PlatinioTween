
namespace Platinio.TweenEngine
{
    public class ValueTween : BaseTween
    {
        #region PRIVATE
        private float from = 0.0f;
        private float to = 0.0f;
        #endregion

        #region PUBLIC
        public ValueTween(float from, float to, float t, int id)
        {
            this.from = from;
            this.to = to;
            this.duration = t;
            this.id = id;
        }

        /// <summary>
        /// called every frame
        /// </summary>
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

                if (onUpdateFloat != null)
                    onUpdateFloat( to );

                onComplete();
                return;
            }

            //get new value           
            float value = EasingFunctions.ChangeFloat(from , to , currentTime / duration , ease);

            //call update if we have it
            if (onUpdateFloat != null)
                onUpdateFloat( value );
        }
        #endregion
    }

}

