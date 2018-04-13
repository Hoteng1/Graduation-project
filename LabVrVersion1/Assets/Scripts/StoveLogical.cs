using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class StoveLogical
    {
        private static StoveLogical instance;
        private GameObject Stove;
        private GameObject VMetr;
        private Transform Door;
        private Dictionary<Char, float[]> AreaOfStove;
        private StoveLogical() { }
        public void Init(GameObject Stove, GameObject VMetr)
        {
            this.Stove = Stove;
            this.VMetr = VMetr;
            this.Door = Stove.transform.GetChild(8);
            AreaOfStove = new Dictionary<char, float[]>();
            InitializerArea();
        }
        public static StoveLogical getInstance()
        {
            if (instance == null)
                instance = new StoveLogical();
            return instance;
        }
        public void OpenDoor()
        {
            float angle = 0;
            if (Door.transform.rotation.z > -0.5)
            {
                
                angle = -1;
            }

            Door.transform.Rotate(new Vector3(0, 0, angle));
        }
        public void CloseDoor()
        {
            float angle = 0;
            if (Door.transform.rotation.z < 0)
            {
                
                angle = 1;
            }

            Door.transform.Rotate(new Vector3(0, 0, angle));
        }

        public bool isIncludeObject(GameObject gameObject)
        {
            foreach (var item in AreaOfStove)
            {
                for (int i = 0; i < AreaOfStove.Count; i++)
                {
                    Debug.Log(item.Value[0]);
                    Debug.Log(item.Value[1]);
                    Debug.Log(gameObject.transform.position[i]);
                    
                    if (gameObject.transform.position[i] < item.Value[0] || gameObject.transform.position[i] > item.Value[1])
                    {
                        
                        return false;
                    }
                }

            }
            return true;
        }

        private void InitializerArea()
        {
            float minValue;
            float maxValue;
            float scale;
            char[] coordinate = { 'x', 'y', 'z' };
            int param = 10;
            for (int i = 0; i < coordinate.Length; i++)
            {
                scale = Stove.transform.localScale[i];
                minValue = Stove.transform.position[i] - param*scale ;
                maxValue = Stove.transform.position[i] + param*scale ;
                float[] range = { minValue, maxValue };
                AreaOfStove.Add(coordinate[i], range);
               
            }
        }
    }
}
