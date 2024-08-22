using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FrontDesk.Core.SyncedAggregates;
using FrontDesk.Core.ValueObjects;
using PluralsightDdd.SharedKernel;
using PluralsightDdd.SharedKernel.Interfaces;

namespace UnitTests
{
  public class ClientId : ValueObject
  {
    public Guid Value { get; private set; }

    private ClientId()
    {
      Value = Guid.NewGuid();
    }

    public static ClientId Next()
    {
      return new ClientId();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }


  public class ClientV2 : BaseEntity<ClientId>, IAggregateRoot
  {
    public ClientV2(ClientId id)
    {
      Id = id;
      Patients = new List<Patient>();
    }

    public ClientV2(
      ClientId id,
      string fullName,
      string preferredName,
      string salutation,
      int preferredDoctorId,
      string emailAddress)
    {
      FullName = fullName;
      PreferredName = preferredName;
      Salutation = salutation;
      PreferredDoctorId = preferredDoctorId;
      EmailAddress = emailAddress;
    }

    //private Client() //required for EF
    //{
    //}

    public string FullName { get; private set; }
    public string PreferredName { get; private set; }
    public string Salutation { get; private set; }
    public string EmailAddress { get; private set; }
    public int PreferredDoctorId { get; private set; }
    public IList<Patient> Patients { get; private set; } = new List<Patient>();

    public override string ToString()
    {
      return FullName.ToString();
    }
  }

  public class PatientV2 : BaseEntity<ClientId>
  {
    public PatientV2(ClientId clientId, string name, string sex, AnimalType animalType, int? preferredDoctorId = null)
    {
      ClientId = clientId;
      Name = name;
      Sex = sex;
      AnimalType = animalType;
      PreferredDoctorId = preferredDoctorId;
    }

    private PatientV2() // required for EF
    {
    }

    public ClientId ClientId { get; private set; }
    public string Name { get; private set; }
    public string Sex { get; private set; }
    public AnimalType AnimalType { get; private set; }
    public int? PreferredDoctorId { get; private set; }

    public void UpdateName(string name)
    {
      Name = name;
    }

    public override string ToString()
    {
      return Name.ToString();
    }
  }
}
