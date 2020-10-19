using System;

namespace MathForGames
{
    class Scene
    {
        private Actor[] _actors;

        public bool Started { get; private set; }

        public Scene()
        {
            _actors = new Actor[0];
        }

        public void AddActor(Actor actor)
        {
            //create a new array with a size one greater than old array
            Actor[] appendedArray = new Actor[_actors.Length + 1];
            //copy the values from the old array to the new array
            for (int i = 0; i < _actors.Length; i++)
            {
                appendedArray[i] = _actors[i];
            }
            //set the last value in the new array to be the actor we want to add
            appendedArray[_actors.Length] = actor;
            //set old array to hold values of the new array
            _actors = appendedArray;
        }

        public bool RemoveActor(int index)
        {
            //checks if the array was out of bounds
            if (index < 0 || index >= _actors.Length)
            {
                return false;
            }

            bool actorRemoved = false;
            //create a new array with a size one less than the old array
            Actor[] tempArray = new Actor[_actors.Length - 1];
            //creates variable to access tempArray index
            int j = 0;
            //copy values from old array into new array
            for (int i = 0; i < _actors.Length; i++)
            {
                //If the current index is not the index that needs to be removed
                //add the value into the old array and increment j
                if (i != index)
                {
                    tempArray[j] = _actors[i];
                    j++;
                }
                else
                {
                    actorRemoved = true;
                    if (_actors[i].Started)
                        _actors[i].End();
                }
            }
            //set old array to the new array
            _actors = tempArray;
            return actorRemoved;
        }

        public bool RemoveActor(Actor actor)
        {
            if (actor == null)
            {
                return false;
            }

            bool actorRemoved = false;

            Actor[] newArray = new Actor[_actors.Length - 1];

            int j = 0;

            for (int i = 0; i < _actors.Length; i++)
            {
                if (actor != _actors[i])
                {
                    newArray[j] = _actors[i];
                    j++;
                }
                else
                {
                    actorRemoved = true;
                    if (actor.Started)
                        actor.End();
                }
            }

            _actors = newArray;
            return actorRemoved;
        }

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                if (!_actors[i].Started)
                    _actors[i].Start();

                _actors[i].Update();
            }
        }

        public virtual void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Draw();
            }
        }

        public virtual void End()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                if (_actors[i].Started)
                    _actors[i].End();
            }

            Started = false;
        }

    }
}