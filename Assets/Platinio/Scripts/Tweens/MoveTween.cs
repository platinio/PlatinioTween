using UnityEngine;


namespace Platinio.TweenEngine
{
    public class MoveTween : BaseTween
    {
        #region PRIVATE
        private Transform obj = null;
        private Transform to = null;
        private Vector3 initialPos = Vector3.zero;
        #endregion

        #region PUBLIC
        public MoveTween(Transform obj, Transform to, float t, int id)
        {
            this.obj = obj;
            this.to = to;
            this.duration = t;
            this.initialPos = obj.position;
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
                obj.position = to.position;


                if (onUpdateTransform != null)
                    onUpdateTransform( obj );

                onComplete();
                return;
            }

            //get new value
            Vector3 change = to.position - initialPos;
            obj.position = Equations.ChangeVector( currentTime, initialPos, change, duration, ease );

            //call update if we have it
            if (onUpdateTransform != null)
                onUpdateTransform( obj );

        }
        #endregion        
    }

}

