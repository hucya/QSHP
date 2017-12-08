using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QSHP.HW.Spindle
{
    public class SpindleEventArgs : EventArgs
    {
        private float workCur = 0;

        public float WorkCur
        {
            get { return workCur; }
            set { workCur = value; }
        }
        private float workSpeed = 0;

        public float WorkSpeed
        {
            get { return workSpeed; }
            set { workSpeed = value; }
        }
        private bool updateSucessful;

        public bool UpdateSucessful
        {
            get { return updateSucessful; }
            set { updateSucessful = value; }
        }
        private string status = string.Empty;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private int errCode = 0;

        public int ErrCode
        {
            get { return errCode; }
            set { errCode = value; }
        }
    }
}
