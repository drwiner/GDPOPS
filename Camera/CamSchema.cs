﻿using BoltFreezer.Camera.CameraEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoltFreezer.Camera
{
    [Serializable]
    public class CamSchema
    {

        public FramingType scale = FramingType.None;

        public string targetLocation;

        public Orient targetOrientation = Orient.None;

        public Hangle hangle = Hangle.None;

        public Vangle vangle = Vangle.None;

        // Used to reconstruct camera w/o specific target; alternatively, give sample target
        public float distance;
        public float height;

        public CamSchema(FramingType _scale, string _tLoc, Orient _tOrient, Hangle _hangle, Vangle _vangle, float _distance, float _height)
        {
            scale = _scale;
            targetLocation = _tLoc;
            targetOrientation = _tOrient;
            hangle = _hangle;
            vangle = _vangle;
            distance = _distance;
            height = _height;
        }

        public CamSchema Duplicate()
        {
            return new CamSchema(scale, targetLocation, targetOrientation, hangle, vangle, distance, height);
        }

        public override string ToString()
        {
            return string.Format("Shot({0}.{1}.{2}.{3}.{4}", scale, targetLocation, targetOrientation, hangle, vangle);
        }

        public static int OrientToInt(Orient orient)
        {
            if (orient.Equals(Orient.None))
            {
                return -1;
            }
            var theRest = orient.ToString().Split('o')[1];
            return Int32.Parse(theRest);
        }

        public static int HangleToInt(Hangle hangle)
        {
            if (hangle.Equals(Hangle.None))
            {
                return -1;
            }
            var theRest =  hangle.ToString().Split('h')[1];
            return Int32.Parse(theRest);
        }

        public static int VangleToInt(Vangle vangle)
        {
            if (vangle.Equals(Vangle.None))
            {
                return -1;
            }
            if (vangle == Vangle.Low)
            {
                return -30;
            }
            if (vangle == Vangle.Eye)
            {
                return 0;
            }
            if (vangle == Vangle.High)
            {
                return 30;
            }
            return 0;
        }

        public bool IsConsistent(CamSchema cas)
        {
            if (scale != FramingType.None)
            {
                if (scale != cas.scale)
                {
                    //Debug.Log("not same scale");
                    return false;
                }
            }

            if (targetLocation != "" && targetLocation != null)
            {
                if (targetLocation != cas.targetLocation)
                {
                    //Debug.Log("not same location");
                    return false;
                }
            }

            if (targetOrientation != Orient.None)
            {
                if (targetOrientation != cas.targetOrientation)
                {
                    //Debug.Log("not same target Orient");
                    return false;
                }
            }

            if (!hangle.Equals(Hangle.None))
            {
                if (hangle != cas.hangle)
                {
                    //Debug.Log("not same hangle");
                    return false;
                }
            }

            if (!vangle.Equals(Vangle.None))
            {
                if (vangle != cas.vangle)
                {
                    //Debug.Log("not same vangle");
                    return false;
                }
            }

            return true;
        }

        public CamSchema Clone()
        {
            return new CamSchema(scale, targetLocation, targetOrientation, hangle, vangle, distance, height);
        }
    }
}
