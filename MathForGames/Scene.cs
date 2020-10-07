using System;
using System.Collections.Generic;
using System.Text;

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
            Entity[] appendedArray = new Entity[_entity.Length + 1];
            for (int i = 0; i < appendedArray.Length; i++)
            {
                appendedArray[i] = _entity[i];
            }
            appendedArray[_entity.Length] = entity;
            _entity = appendedArray;
        }

        public void Start()
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {

        }

        public void End()
        {

        }

    }
}
