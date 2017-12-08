using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace QSHP.Data
{
    public class PreData
    {
        List<PreChannel> userData = new List<PreChannel>();
        List<float> speeds = new List<float>();
        const int maxNum = 10;
        int tick = 0;
        int index = 0;
        string id = "std";
        bool autoMode = true;
        bool enable = false;

        float startSpeed = 5;
        float endSpeed = 50;
        float incSpeed = 5;
        float preLine = 5;

        public List<PreChannel> UserData
        {
            get
            {
                return userData;
            }

            set
            {
                userData = value;
            }
        }

        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }

        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public bool AutoMode
        {
            get
            {
                return autoMode;
            }

            set
            {
                autoMode = value;
            }
        }

        public float StartSpeed
        {
            get
            {
                return startSpeed;
            }

            set
            {
                startSpeed = value;
            }
        }

        public float EndSpeed
        {
            get
            {
                return endSpeed;
            }

            set
            {
                endSpeed = value;
            }
        }

        public float IncSpeed
        {
            get
            {
                return incSpeed;
            }

            set
            {
                incSpeed = value;
            }
        }

        public float PreLine
        {
            get
            {
                return preLine;
            }

            set
            {
                preLine = value;
            }
        }

        public bool Enable
        {
            get
            {
                return enable;
            }

            set
            {
                enable = value;
                if (enable)
                {
                    InitUserData();
                }
            }
        }
        [XmlIgnore]
        public int Tick
        {
            get
            {
                return tick;
            }

            set
            {
                tick = value;
            }
        }
        [XmlIgnore]
        public List<float> Speeds
        {
            get
            {
                return speeds;
            }

            set
            {
                speeds = value;
            }
        }
        public int Count
        {
            get
            {
                return speeds.Count;
            }
        }
        public PreChannel this[int i]
        {
            get
            {
                return UserData[i];
            }
        }

        public void InitUserData()
        {
            tick = 0;
            for (int i = UserData.Count; i < maxNum; i++)
            {
                UserData.Add(new PreChannel());
            }
        }

        public void InitPreDataSpeed()
        {
            tick = 0;
            Speeds.Clear();
            if(autoMode)//自动模式
            {
                if (incSpeed != 0&&preLine>0)
                {

                    float s = startSpeed;
                    float inc = incSpeed;
                    do
                    {
                        float abs = Math.Abs(startSpeed - endSpeed);
                        if (incSpeed > abs)
                        {
                            inc = abs;
                        }
                        for (int i = 0; i < preLine; i++)
                        {
                            Speeds.Add(s);
                        }
                        s += inc;
                    } while (s <= endSpeed);
                }
            }
            else
            {
                foreach (var item in userData)
                {
                    if(item.Speed>0&&item.Line>0)
                    {
                        for (int i = 0; i < item.Line; i++)
                        {
                            Speeds.Add(item.Speed);
                        }
                    }
                }
            }
        }

        public float GetPreDataSpeed()
        {
            if(tick<Count)
            {
                float s= speeds[tick++];
                if (s >= Count)
                {
                    Enable = false;
                }
                return s;
            }
            else
            {
                Enable = false;
                return 0;
            }
        }

        public void ResetPreCutTick()
        {
            InitPreDataSpeed();
        }
    }

    public class PreChannel
    {
        int line = 0;
        float speed = 5;

        public int Line
        {
            get
            {
                return line;
            }

            set
            {
                line = value;
            }
        }

        public float Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }
    }
    
}
