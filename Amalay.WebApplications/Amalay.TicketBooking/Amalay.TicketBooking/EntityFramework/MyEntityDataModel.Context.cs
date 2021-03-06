﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Amalay.TicketBooking.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AmalayDbEntities : DbContext
    {
        public AmalayDbEntities()
            : base("name=AmalayDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<USP_GetAvailableSeats_Result> USP_GetAvailableSeats(Nullable<int> planeId, Nullable<int> noOfSeats)
        {
            var planeIdParameter = planeId.HasValue ?
                new ObjectParameter("PlaneId", planeId) :
                new ObjectParameter("PlaneId", typeof(int));
    
            var noOfSeatsParameter = noOfSeats.HasValue ?
                new ObjectParameter("NoOfSeats", noOfSeats) :
                new ObjectParameter("NoOfSeats", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GetAvailableSeats_Result>("USP_GetAvailableSeats", planeIdParameter, noOfSeatsParameter);
        }
    
        public virtual int USP_BookSeat(Nullable<int> planeId, Nullable<int> rowIndex, Nullable<int> columnIndex, Nullable<int> seatLength)
        {
            var planeIdParameter = planeId.HasValue ?
                new ObjectParameter("PlaneId", planeId) :
                new ObjectParameter("PlaneId", typeof(int));
    
            var rowIndexParameter = rowIndex.HasValue ?
                new ObjectParameter("RowIndex", rowIndex) :
                new ObjectParameter("RowIndex", typeof(int));
    
            var columnIndexParameter = columnIndex.HasValue ?
                new ObjectParameter("ColumnIndex", columnIndex) :
                new ObjectParameter("ColumnIndex", typeof(int));
    
            var seatLengthParameter = seatLength.HasValue ?
                new ObjectParameter("SeatLength", seatLength) :
                new ObjectParameter("SeatLength", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_BookSeat", planeIdParameter, rowIndexParameter, columnIndexParameter, seatLengthParameter);
        }
    }
}
