using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Datas
    {
        public int Id { get; set; }
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public double? Co { get; set; }
        public double? Pressure { get; set; }
        public DateTime? DataSaveTime { get; set; }

        //public Datas(Datas data)
        //{
        //    Temperature = data.Temperature;
        //    Humidity = data.Humidity;
        //    Co = data.Humidity;
        //    Pressure = data.Pressure;
        //    DataSaveTime = data.DataSaveTime;
        //}
    }
}
