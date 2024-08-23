using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontDesk.Core.ValueObjects;
using Xunit;

namespace UnitTests
{
  public class ValueObjectExampleTests
  {
    [Fact]
    public void ObjectsHaveReferenceEquality()
    {
      var myObject = new object();

      var myObject2 = myObject;

      Assert.Equal(myObject, myObject2);
    }

    [Fact]
    public void ObjectsDoNotHaveStructuralEquality()
    {

      var myObject = new object();

      var myObject2 = new object();

      Assert.NotEqual(myObject, myObject2);
    }

    [Fact]
    public void DogsAreNotEqual()
    {
      var bulldog = new AnimalType("Dog", "Bull Dog");
      var dachshund = new AnimalType("Dog", "Dachshund");

      Assert.NotEqual(bulldog, dachshund);
    }

    [Fact]
    public void DogsAreEqual()
    {
      var bulldog = new AnimalType("Dog", "Bull Dog");
      var otherBulldog = new AnimalType("Dog", "Bull Dog");

      Assert.Equal(bulldog, otherBulldog);
    }

    [Fact]
    public void DogsAreImmutable()
    {
      var immutableDog = new AnimalType("Dog", "Chihuahua");

      // Show Compiler Error

      // immutableDog.Species = "Cat";
    }

    [Fact]
    public void DogsAreMaybeEqual()
    {
      var bulldog = new AnimalType("Dog", "Bull Dog");
      var weirdBulldog = new AnimalType("Dog", "BuLl DoG");

      Assert.Equal(bulldog, weirdBulldog); //Maybe?
    }

    [Fact]
    public void SomeDogsAreMoreEqualThanOthers()
    {
      var bulldog = new AnimalType("Dog", "Bull Dog");
      var weirdBulldog = new AnimalType("DOG", "BuLl DoG");

      // Modified doggy equality

      //protected override IEnumerable<object> GetEqualityComponents()
      //{
      //  yield return Breed.ToLowerInvariant().Replace(" ", "");
      //  yield return Species.ToLowerInvariant().Replace(" ", "");
      //}

      Assert.Equal(bulldog, weirdBulldog);
    }
  }
}
