using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tuote_tilaus
{
    public class TilausOtsikko
    {

        public int Id { get; set; }
        public string ItemName { get; set; }
        private DateTime orderDate;
        public DateTime OrderDate
        {
            get { return orderDate; }
            set
            {
                if(value <= DateTime.Today)
                {
                    orderDate = value;
                }
                else
                {
                    
                    throw  new ArgumentOutOfRangeException("tilauspvm ei voi olla tulevaisuudessa!");
                }
            }
        }
        public string Address { get; set; }
        public DateTime ArrivalDate { get; set; }


        


        public void SetId()
        {

        }
        public TilausOtsikko()
        {
            
        }
    }
}
