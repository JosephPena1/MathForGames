using System;

namespace MathForGames
{
    class Scene
    {
        private Actor[] _actor;

        public Scene()
        {
            _actor = new Actor[0];
        }

        public void AddActor(Actor actor)
        {
            //create a new array with a size one greater than old array
            Actor[] appendedArray = new Actor[_actor.Length + 1];
            //copy the values from the old array to the new array
            for (int i = 0; i < _actor.Length; i++)
            {
                appendedArray[i] = _actor[i];
            }
            //set the last value in the new array to be the actor we want to add
            appendedArray[_actor.Length] = actor;
            //set old array to hold values of the new array
            _actor = appendedArray;
        }

        public bool RemoveActor(int index)
        {
            //checks if the array was out of bounds
            if (index < 0 || index >= _actor.Length)
            {
                return false;
            }

            bool entityRemoved = false;
            //create a new array with a size one less than the old array
            Actor[] tempArray = new Actor[_actor.Length - 1];
            //creates variable to access tempArray index
            int j = 0;
            //copy values from old array into new array
            for (int i = 0; i < _actor.Length; i++)
            {
                //If the current index is not the index that needs to be removed
                //add the value into the old array and increment j
                if (i != index)
                {
                    tempArray[j] = _actor[i];
                    j++;
                }
                else
                {
                    entityRemoved = true;
                }
            }
            //set old array to the new array
            _actor = tempArray;
            return entityRemoved;
        }

        public bool RemoveActor(Actor actor)
        {
            if (actor == null)
            {
                return false;
            }

            bool entityRemoved = false;

            Actor[] newArray = new Actor[_actor.Length - 1];

            int j = 0;

            for (int i = 0; i < _actor.Length; i++)
            {
                if (actor != _actor[i])
                {
                    newArray[j] = _actor[i];
                    j++;
                }
                else
                {
                    entityRemoved = true;
                }
            }

            _actor = newArray;
            return entityRemoved;
        }

        public virtual void Start()
        {
            for (int i = 0; i < _actor.Length; i++)
            {
                _actor[i].Start();
            }
        }

        public virtual void Update()
        {
            for (int i = 0; i < _actor.Length; i++)
            {
                _actor[i].Update();
            }
        }

        public virtual void Draw()
        {
            for (int i = 0; i < _actor.Length; i++)
            {
                _actor[i].Draw();
            }
        }

        public virtual void End()
        {
            for (int i = 0; i < _actor.Length; i++)
            {
                _actor[i].End();
            }
        }

    }
}