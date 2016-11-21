/*Todd Lasley
 * CIS 200-10
 * 5/31/15
 * Class used to define objects of type NextsDayAirPackage
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    //begin class NextDayAirPackage, derived from AirPackage
    class NextDayAirPackage : AirPackage
    {
        //backing field for express fee
        private decimal expressFee;
        
        //constants for
        private const decimal volumeCost = .40M; //volume rate
        private const decimal weightCost = .30M; //weight rate
        private const decimal heavyCharge = .25M; //charge if package is considered heavy
        private const decimal largeCharge = .25M; //charge if package is considered large

        //constructor used to create objects of type NextDayAirPackage
        public NextDayAirPackage(Address originAddress, Address destAddress, double length, double width,
            double height, double weight, decimal expressFee)
            : base(originAddress, destAddress, length, width, height, weight)
        {
            ExpressFee = expressFee;
        }//end constructor

        //ExpressFee Property
        public decimal ExpressFee
        {
            //default get accessor
            get
            {
                return expressFee;
            }//end get

            //set accessor
            private set
            {
                if (value > 0)
                    expressFee = value;
                else
                    throw new ArgumentOutOfRangeException("ExpressFee", expressFee, "ExpressFee must be greater than zero");
            }//end set
        }//end ExpressFee property

        //override CalcCost from base class
        public override decimal CalcCost()
        {
            //casting length, width, height, and weight to decimal
            decimal l = (decimal)Length;
            decimal w = (decimal)Width;
            decimal h = (decimal)Height;
            decimal wt = (decimal)Weight;

            //base cost if no additional charges
            decimal baseCost = volumeCost*(l + w + h) + weightCost * wt + ExpressFee;
            //cost if considered heavy
            decimal weightFee = heavyCharge * wt + ExpressFee;
            //cost if considered large
            decimal sizeFee = largeCharge * (l + w + h) + ExpressFee;

            //use if-else logic to determine what final cost will be
            if (IsHeavy() && IsLarge()) //is it heavy and large?
            {
                return baseCost + weightFee + sizeFee;
            }
            else if (IsHeavy()) //is it just heavy?
            {
                return baseCost + weightFee;
            }
            else //is it just large?
            {
                return baseCost + sizeFee;
            }
        }//end method CalcCost

        //override ToString to print fields
        public override String ToString()
        {
            return String.Format("Next-Day Air Package{3}{0}{3}Express Fee: {1:C}{3}Total Cost: {2:C}",
                base.ToString(), ExpressFee, CalcCost(), Environment.NewLine);
        }
    }//end class NextDayAirPackage 
