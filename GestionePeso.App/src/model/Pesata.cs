using System;
using System.Collections.Generic;

namespace GestionePeso.App.Model
{
    public class Pesata
    {
        public DateTime Date { get; set; }
        public float Weight { get; set; }

        public string DateToStr
        {
            get
            {
                return Date.ToShortDateString();
            }
        }

        public Pesata(DateTime date, float weight)
        {
            Date = date;
            Weight = weight;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Date, Weight);
        }

        public static List<Pesata> CreateTestData()
        {
            return new List<Pesata>
            {
                new Pesata(DateTime.Now, 88),
                new Pesata(DateTime.Now.AddDays(-3), 87),
                new Pesata(DateTime.Now.AddDays(-1), 89),
                new Pesata(DateTime.Now.AddDays(-2), 88),
            };
        }
    }
}
