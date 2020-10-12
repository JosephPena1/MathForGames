using System;

namespace MathForGames
{
    class Scene
    {
        private Entity[] _entity;

        public Scene()
        {
            _entity = new Entity[0];
        }

        public void AddEntity(Entity entity)
        {
            //create a new array with a size one greater than old array
            Entity[] appendedArray = new Entity[_entity.Length + 1];
            //copy the values from the old array to the new array
            for (int i = 0; i < _entity.Length; i++)
            {
                appendedArray[i] = _entity[i];
            }
            //set the last value in the new array to be the actor we want to add
            appendedArray[_entity.Length] = entity;
            //set old array to hold values of the new array
            _entity = appendedArray;
        }

        public bool RemoveEntity(int index)
        {
            //checks if the array was out of bounds
            if (index < 0 || index >= _entity.Length)
            {
                return false;
            }

            bool entityRemoved = false;
            //create a new array with a size one less than the old array
            Entity[] tempArray = new Entity[_entity.Length - 1];
            //creates variable to access tempArray index
            int j = 0;
            //copy values from old array into new array
            for (int i = 0; i < _entity.Length; i++)
            {
                //If the current index is not the index that needs to be removed
                //add the value into the old array and increment j
                if (i != index)
                {
                    tempArray[j] = _entity[i];
                    j++;
                }
                else
                {
                    entityRemoved = true;
                }
            }
            //set old array to the new array
            _entity = tempArray;
            return entityRemoved;
        }

        public bool RemoveEntity(Entity entity)
        {
            if (entity == null)
            {
                return false;
            }

            bool entityRemoved = false;

            Entity[] newArray = new Entity[_entity.Length - 1];

            int j = 0;

            for (int i = 0; i < _entity.Length; i++)
            {
                if (entity != _entity[i])
                {
                    newArray[j] = _entity[i];
                    j++;
                }
                else
                {
                    entityRemoved = true;
                }
            }

            _entity = newArray;
            return entityRemoved;
        }

        public virtual void Start()
        {
            for (int i = 0; i < _entity.Length; i++)
            {
                _entity[i].Start();
            }
        }

        public virtual void Update()
        {
            for (int i = 0; i < _entity.Length; i++)
            {
                _entity[i].Update();
            }
        }

        public virtual void Draw()
        {
            for (int i = 0; i < _entity.Length; i++)
            {
                _entity[i].Draw();
            }
        }

        public virtual void End()
        {
            for (int i = 0; i < _entity.Length; i++)
            {
                _entity[i].End();
            }
        }

    }
}
