using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using FrontDesk.Core.ScheduleAggregate;
using FrontDesk.Core.SyncedAggregates;
using PluralsightDdd.SharedKernel;
using UnitTests;
using UnitTests.Builders;
using Xunit;

namespace UnitTests
{
  public class AggregateExampleTests
  {
    [Fact]
    public void UsingJustIds()
    {
      var schedule = new ScheduleBuilder()
        .WithDefaultValues()
        .Build();

      var appointmentType = new AppointmentTypeBuilder()
        .WithDefaultValues()
        .Build();

      var client = new ClientBuilder()
        .WithDefaultValues()
        .Build();

      var doctor = new DoctorBuilder()
        .WithDefaultValues()
        .Build();

      var patient = new PatientBuilder()
        .WithDefaultValues()
        .Build();

      var room = new RoomBuilder()
        .WithDefaultValues()
        .Build();

      var today = new DateTimeOffset(DateTime.Now);
      var range = new DateTimeOffsetRange(today, today.AddDays(1));

      var appointment = new Appointment(new Guid(), appointmentType.Id, schedule.Id, client.Id, doctor.Id, patient.Id, room.Id, range, "My apointment");
    }

    [Fact]
    public void UsingFullTypes()
    {
      var schedule = new ScheduleBuilder()
        .WithDefaultValues()
        .Build();

      var appointmentType = new AppointmentTypeBuilder()
        .WithDefaultValues()
        .Build();

      var client = new ClientBuilder()
        .WithDefaultValues()
        .Build();

      var doctor = new DoctorBuilder()
        .WithDefaultValues()
        .Build();

      var patient = new PatientBuilder()
        .WithDefaultValues()
        .Build();

      var room = new RoomBuilder()
        .WithDefaultValues()
        .Build();

      var today = new DateTimeOffset(DateTime.Now);
      var range = new DateTimeOffsetRange(today, today.AddDays(1));

      var appointment = new Appointment(new Guid(), appointmentType, schedule.Id , client, doctor, patient, room, range, "My apointment");
    }
  }
}
