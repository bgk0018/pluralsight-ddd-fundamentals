using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontDesk.Core.SyncedAggregates;
using FrontDesk.Core.ValueObjects;
using UnitTests.Builders;
using Xunit;

namespace UnitTests
{
  public class EntityExampleTests
  {
    [Fact]
    public void ConstructorProvidesATransactionalBoundary()
    {
      var client = new ClientBuilder() // Fluent Builder pattern
        .WithDefaultValues()
        .Build();

      var doctor = new DoctorBuilder()
        .WithDefaultValues()
        .Build();

      var animalType = new AnimalType("Dog", "Big");

      var patient = new Patient(client.Id, "Big Boy", "Male", animalType, doctor.Id);
    }

    [Fact]
    public void MethodProvidesATransactionalBoundary()
    {
      var patient = new PatientBuilder()
        .WithDefaultValues()
        .Build();

      var originalName = patient.Name;

      patient.UpdateName("Scooby Doo");

      Assert.NotEqual(originalName, patient.Name);
    }

    [Fact]
    public void GettingTheCompilerInvolvedBreakingPrimitiveObsession()
    {
      var client = new ClientV2(ClientId.Next(), "fullName", "preferredName", "salutation", 1, "email@address.com");

      // ClientId is now typed!
      var patient = new PatientV2(client.Id, "name", "Male", new AnimalType("Species", "Breed"));

    }
  }
}
