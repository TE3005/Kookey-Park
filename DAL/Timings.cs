//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timings
    {
        public int TimingId { get; set; }
        public Nullable<int> UserRideId { get; set; }
        public Nullable<System.TimeSpan> OperatingTime { get; set; }
        public Nullable<int> CountTimings { get; set; }
    
        public virtual UserRide UserRide { get; set; }
        public virtual Rides Rides { get; set; }
    }
}
