/*Todd Lasley
 * CIS 200-10
 * 5/31/15
 * Class used to define objects of type AirPackage
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    //begin abstract class AirPackage, derived from Package
    public abstract class AirPackage : Package
    {
        //constants for what is heavy and large
        private const double heavy = 75.00;
        private const double large = 100.00;
        
        //constructor that will be used to create objects of type AirPackage
        public AirPackage(Address originAddress, Address destAddress, double length, double width,
            double height, double weight)
            : base(originAddress, destAddress, length, width, height, weight)
        {
        }//end constructor

        //method used to determine if package is considered heavy or not
        //if Weight is >= 75 lbs, it is considered heavy
        public bool IsHeavy()
        {
            if (Weight >= heavy)
                return true;
            else
                return false;
        }//end method IsHeavy

        //method used to determine if package is considered large or not
        //if length + width + height >= 100 inches, it is considered large
        public bool IsLarge()
        {
            if ((Length + Width + Height) >= large)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//end method IsLarge

        //override the ToString from Package
        public override String ToString()
        {
            return String.Format("{0}{3}Heavy?: {1}{3}Large?: {2}", 
                base.ToString(), IsHeavy(), IsLarge(), Environment.NewLine);
        }

    }//end class AirPackage
