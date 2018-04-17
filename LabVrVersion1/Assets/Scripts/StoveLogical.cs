using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts
{

    class StoveLogical
    {
        //Varible
        const double Platinum = -4.4,
            Tin = -0.2,
            Lead = 0,
            Silver = 2.7,
            Copper = 3.2,
            Antimony = 4.3,
            RoomT = 25.0;
        private StringBuilder inforamaion;
        private double alpha;
        private GameObject targetMetal;
        private static StoveLogical instance;
        private GameObject Stove;
        private GameObject VMetr;
        private Transform Door;
        private Dictionary<Char, float[]> AreaOfStove;
        private float initAngleStoveDoor;
        private bool isLockDoor;
        private Transform Arrow;
        private float AngleArrow;
        private  System.Timers.Timer aTimer;
        private float ChangeAngle;
        IEnumerable<TableForGradirovanie> list;
        int currentIndex;
        bool isRunTimer;
        SpriteRenderer  display;
        //Consturctor
        private StoveLogical() { }

        //Methods

        public void Init(GameObject Stove, GameObject VMetr)
        {
            
            isRunTimer = false;
            inforamaion = new StringBuilder();
            isLockDoor = false;
            this.Stove = Stove;
            this.VMetr = VMetr;
            this.Arrow = VMetr.transform.GetChild(4);
            this.AngleArrow = Arrow.transform.position.z;
            ChangeAngle = AngleArrow;
            this.Door = Stove.transform.GetChild(8);
            initAngleStoveDoor = Door.transform.rotation.z;
            AreaOfStove = new Dictionary<char, float[]>();
            InitializerArea();
        }

        public void ShowDisplay()
        {
            if (isRunTimer)
            {
                
            }
        }

        public void RotateArrow()
        {
            if(isRunTimer)
            {
                
                isRunTimer = false;
                Arrow.transform.Rotate(0, 0, (ChangeAngle - AngleArrow)/10);
                AngleArrow += (ChangeAngle - AngleArrow) / 10;
            }
            
        }
        public string GetInformation()
        {
            return inforamaion.ToString();
        }
        public static StoveLogical getInstance()
        {
            if (instance == null)
                instance = new StoveLogical();
            return instance;
        }
        public void OpenDoor()
        {
            if (!isLockDoor)
            {
                float angle = 0;

                if (Door.transform.rotation.z > -0.5)
                {

                    angle = -1;
                }

                Door.transform.Rotate(new Vector3(0, 0, angle));
            }

        }
        public void LockUnlockDoor()
        {
            if (isLockDoor)
            {
                Door.transform.Rotate(new Vector3(0, 0, Door.rotation.z - initAngleStoveDoor));
                isLockDoor = true;
            }
            else
            {
                isLockDoor = false;
            }
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
            int i = 0;
            foreach (var item in AreaOfStove)
            {

                Debug.Log(item.Value[0]);
                Debug.Log(item.Value[1]);
                Debug.Log(gameObject.transform.position[i]);

                if (gameObject.transform.position[i] < item.Value[0] || gameObject.transform.position[i] > item.Value[1])
                {

                    return false;
                }
                i += 1;

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
                minValue = Stove.transform.position[i] - param * scale;
                maxValue = Stove.transform.position[i] + param * scale;
                float[] range = { minValue, maxValue };
                AreaOfStove.Add(coordinate[i], range);

            }
        }

        public IEnumerable<TableForGradirovanie> GetResult()
        {
            List<TableForGradirovanie> table = new List<TableForGradirovanie>();
            for (int i = 0; i < 130; i += 10)
            {
                table.Add(Experince(alpha, RoomT, i));
            }

            return table;
        }
        
        public void SetTartget(GameObject target)
        {
            this.targetMetal = target;
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            
          
        }

        private  void OnTimedEvent(System.Object source, ElapsedEventArgs e)
        {
            isRunTimer = true;
            // создаем таймер
            if (currentIndex==list.Count()-1)
            {
                aTimer.Stop();
            }
                inforamaion.Append(Environment.NewLine);
                inforamaion.Append(list.ElementAt(currentIndex).ToString());
            change((float)list.ElementAt(currentIndex).EZ);
            currentIndex++;
            

        }

        private void change(float param)
        {
            ChangeAngle= AngleArrow + param;
        }

        private TableForGradirovanie Experince(double alpha, double t1, double t2)
        {
            

            double EZ = alpha * (t2 - t1);
            TableForGradirovanie result = new TableForGradirovanie { Name= targetMetal.name, T1 = t1, T2 = t2, Alpha = alpha, EZ = EZ };
            
            return result;
        }

        public void BeginExpereince()
        {
            
            switch (targetMetal.name)
            {
                case "Platinum": alpha = Platinum; break;
                case "Tin": alpha = Tin; break;
                case "Lead": alpha = Lead; break;
                case "Silver": alpha = Silver; break;
                case "Copper": alpha = Copper; break;
                case "Antimony": alpha = Antimony; break;
            }
            currentIndex = 0;
            list = GetResult();
            SetTimer();
            
            
        }
    }
}
