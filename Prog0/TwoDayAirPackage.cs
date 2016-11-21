/*Todd Lasley
 * CIS 200-10
 * 5/31/15
 * Class used to define objects of type TwoDayAirPackage
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    //begin class TwoDayAirPackage, derived from AirPackage
    public class TwoDayAirPackage : AirPackage
    {
        //backing field for Delivery
        private Delivery deliveryType;

        //constants used for...
        private const decimal volumeCost = .25M; //volume rate
        private const decimal weightCost = .25M; //weight rate
        private const decimal saverFactor = .9M; //rate paid if DeliveryType is Saver
        
        //enum used to store types Early and saver
        public enum Delivery {Early, Saver};

        //constructor used to create objects of type TwoDayAirPackage
        public TwoDayAirPackage(Address originAddress, Address destAddress, double length, double width,
            double height, double weight, Delivery deliveryType)
            : base(originAddress, destAddress, length, width, height, weight)
        {
            DeliveryType = deliveryType;
        }//end constructor
        
        //property for DeliveryType
        public Delivery DeliveryType
        {
            //get accessor
            get
            {
                return deliveryType;
            }//end get

            //set accessor
            set
            {
                deliveryType = value;
            }//end set
        }//end DeliveryType property

        //override CalcCost from base class
        public override decimal CalcCost()
        {
            //casting length, width, height, and weight to decimal
            decimal l = (decimal)Length;
            decimal w = (decimal)Width;
            decimal h = (decimal)Height;
            decimal wt = (decimal)Weight;

            //used to store base cost
            decimal baseCost = volumeCost * (l + w + h) + weightCost * wt;

            //checks to see if payer saves 10% or not
            if (DeliveryType == Delivery.Saver) //Are they a Saver?
            {
                return baseCost * saverFactor;
            }
            else //I guess they are not
            {
                return baseCost;
            }
        }//end method CalcCost

        //override ToString to print fields
        public override String ToString()
        {
            return String.Format("Two-Day Air Package{2}{0}{2}Total Cost: {1:C}",
                base.ToString(), CalcCost(), Environment.NewLine);
        }
    }//end class TwoDayAirPackage
