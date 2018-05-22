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
        const double RoomT = 25.0;
        private StringBuilder inforamaion;
        private double alpha = 53.5;
        private static StoveLogical instance;
        private GameObject Stove;
        private GameObject VMetr;
        private Transform Door;
        private float initAngleStoveDoor;
        private bool isLockDoor;
        private Transform Arrow;
        private float AngleArrow;
        private System.Timers.Timer aTimer;
        private float ChangeAngle;
        IEnumerable<TableForGradirovanie> list;
        int currentIndex;
        int tempure;
        System.Random rand;
        //Consturctor
        private StoveLogical() { }
  
        //Methods

        public void Init(GameObject Stove, GameObject VMetr)
        {


            rand = new System.Random();
            isLockDoor = false;
            this.Stove = Stove;
            this.VMetr = VMetr;
            this.Arrow = VMetr.transform.GetChild(4);
            this.AngleArrow = 0;
            ChangeAngle = Arrow.transform.localRotation.z;
            this.Door = Stove.transform.GetChild(7);
            initAngleStoveDoor = Door.transform.localRotation.z;
            tempure = 0;
            
         

        }

        public void ShowDisplay(TextMesh text)
        {
            text.text = "T: " + tempure.ToString();
        }

        public void RotateArrow()
        {
            Arrow.transform.Rotate(0, 0, AngleArrow);
            Arrow.transform.Rotate(0, 0, ChangeAngle);
            AngleArrow = -ChangeAngle;
            Debug.Log(Arrow.rotation.z);
          

        }
        public string GetInformation()
        {
            if(inforamaion!=null)
            return inforamaion.ToString();

            return null;
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

                isLockDoor = false;
            }
            else
            {

                isLockDoor = true;
                Door.transform.localRotation = new Quaternion(Door.transform.localRotation.x, Door.transform.localRotation.y, initAngleStoveDoor, Door.transform.localRotation.w);
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

        

        public IEnumerable<TableForGradirovanie> GetResult()
        {
            List<TableForGradirovanie> table = new List<TableForGradirovanie>();
            for (int i = 0; i < 130; i += 10)
            {
                table.Add(Experince(alpha, RoomT, i));
            }

            return table;
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

        private void OnTimedEvent(System.Object source, ElapsedEventArgs e)
        {

            // создаем таймер
            if (currentIndex == list.Count() - 1)
            {
                aTimer.Stop();
                LockUnlockDoor();
                tempure = 0;
            }
            inforamaion.Append(Environment.NewLine);
            inforamaion.Append(list.ElementAt(currentIndex).ToString());
            Change((float)list.ElementAt(currentIndex).EZ);
            tempure += 10;
            currentIndex++;


        }

        private void Change(float param)
        {
            ChangeAngle = (param/10000)*12;
        }

        private TableForGradirovanie Experince(double alpha, double t1, double t2)
        {

            double temp = alpha + Convert.ToDouble(rand.Next(5));
            double EZ = temp * (t2 - t1);
            TableForGradirovanie result = new TableForGradirovanie {T1 = t1, T2 = t2, Alpha = temp, EZ = EZ };

            return result;
        }

        public void BeginExpereince()
        {

          
            inforamaion = new StringBuilder();
            currentIndex = 0;
            list = GetResult();
            SetTimer();
            LockUnlockDoor();
           

        }
    }
}
