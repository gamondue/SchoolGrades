using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades
{
    internal partial class BusinessLayer
    {
        /// <summary>
        /// Business Layer: implements the business rules of the program indipendently from 
        /// the User's Interface
        /// Porting code from DbAndBusinness class and classes within BusinessLayer is work in progress 
        /// </summary>
        
        // create the next after the program that is using this has read the configuration file 
        DataLayer.DataLayer dl; // must be instantiated after reading config file! 

        /// <summary>
        /// Incapsulates the business rules for users' management
        /// part of the class that contains the constructors and the general methods
        /// </summary>
        ///  
        /// // ???? maybe I should NOT pass this parameter, it is database dependant ????
        internal BusinessLayer(string PathAndFile) 
        {
            dl = new DataLayer.DataLayer(PathAndFile);
        }
    }
}
