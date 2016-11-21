/*Todd Lasley
 * CIS 200-10
 * 5/31/15
 * Class used to define objects of type GroundPackage.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    //begin class GroundPackage, derived from class Package
    public class GroundPackage : Package
    {
        private int zoneDistance; //zone distance between origin and destination
        private const decimal volumeCost = .20M; //used in CalcCost with regards to volume of package
        private const decimal weightCost = .05M; //used in CalcCost with regards to weight of package
        
        //constructor that will be used to create objects of type GroundPackage
        public GroundPackage(Address originAddress, Address destAddress, double length, double width,
            double height, double weight)
            : base(originAddress, destAddress, length, width, height, weight)
        {
        }//end constructor

        //ZoneDistance Property
        //calculated by finding the positive difference between the first digits
        //of the origin zip code and destination zip code
        public int ZoneDistance
        {
            //get accessor
            get
            {
                return zoneDistance;
            }//end get
        }//end ZoneDistance property

        //method used to get the ZoneDistance
        private int getZone()
        {
            return Math.Abs((OriginAddress.Zip/10000) - (DestinationAddress.Zip/10000));
        }//end method ZoneDistance

        //override CalcCost from Parcel
        public override decimal CalcCost()
        {
            //we need to cast the double types of length, width, height, and weight to decimal
            //temp varibiables to store the cast
            decimal l = (decimal)Length; //cast length
            decimal w = (decimal)Width; //cast width
            decimal h = (decimal)Height; //cast height
            decimal wt = (decimal)Weight; //cast weight
            decimal zone = (decimal)getZone();
            //return the result
            return volumeCost * (l + w + h) + weightCost * (getZone() + 1) * w;
        }//end CalcCost

        //override the ToString from parent class
        public override String ToString()
        {
            return String.Format("Ground Package{3}{0}{3}Zone: {1}{3}Cost: {2:C}", 
                base.ToString(), getZone(), CalcCost(), Environment.NewLine);
        }

    }//end class GroundPackage
