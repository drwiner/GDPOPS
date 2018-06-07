﻿using BoltFreezer.Camera.CameraEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoltFreezer.Camera
{
    [Serializable]
    public class CamTargetSchema
    {
        public Orient orient = Orient.None;

        public string location = "";

        public List<ActionSeg> ActionSegs = new List<ActionSeg>();

        public CamTargetSchema()
        {

        }

        public CamTargetSchema(Orient _orient, string _location, List<ActionSeg> _actionSegs)
        {
            orient = _orient;
            location = _location;
            ActionSegs = _actionSegs;
        }

        public CamTargetSchema(Orient _orient, List<ActionSeg> _actionSegs)
        {
            orient = _orient;
            ActionSegs = _actionSegs;
        }

        public CamTargetSchema(List<ActionSeg> _actionSegs)
        {
            ActionSegs = _actionSegs;
        }

        public int OrientInt
        {
            get {
                if (orient.Equals(Orient.None))
                {
                    return -1;
                }
                var rest = orient.ToString().Split('O')[1];
                return Int32.Parse(rest);
            }
        }


        public CamTargetSchema Clone()
        {
            return new CamTargetSchema(orient, location, ActionSegs);
        }
    }
}
