/*Todd Lasley
 * CIS 200-10
 * 5/31/15
 * Class used to define objects of type Package
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    //begin class Package, derived from class Parcel
    public abstract class Package : Parcel
    {
        private double length; //stores the length of the package
        private double width; //stores the width of the package
        private double height; //stores the height of the package
        private double weight; //stores the weight of the package
        
        //constructor that will be used to create objects of type Package
        public Package(Address originAddress, Address destAddress, double length, double width,
            double height, double weight) : base (originAddress, destAddress)
        {
            Length = length; //links to Length property that is created below
            Width = width; //links to width property
            Height = height; //links to height property
            Weight = weight; //links to weight property
        }// end constructor
    
    //properties for...
        //Length
        public double Length
        {
            //get accessor
            get { return length; } //end get
            
            //set accessor
            set
            {
                if (value > 0)
                    length = value;
                else
                    throw new ArgumentOutOfRangeException("Length", Length, "Length must be greater than zero");
            }//end set
        }//end property Length

        //Width
        public double Width
        {
            //get accessor
            get { return width; } //end get

            //set accessor
            set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Width", Width, "Width must be greater than zero");
                }
            }//end set
        }//end property Width

        //Height
        public double Height
        {
            //get accessor
            get { return height;  } //end get

            //set accessor
            set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Height", Height, "Height must be greater than zero");
                }
            }//end set
        }//end property Height

        //Weight
        public double Weight
        {
            //get accessor
            get { return weight;  } //end get

            //set accessor
            set
            {
                if (value > 0)
                    weight = value;
                else
                    throw new ArgumentOutOfRangeException("Weight", Weight, "Weight must be greater than zero");
            }//end set
        }//end property Weight

        //override ToString to display fields
        public override String ToString()
        {
            return String.Format("{0}{5}Length: {1}{5}Width: {2}{5}Height: {3}{5}Weight: {4}", base.ToString(), Length, Width, 
                Height, Weight, Environment.NewLine);
        }
    }//end class Package
