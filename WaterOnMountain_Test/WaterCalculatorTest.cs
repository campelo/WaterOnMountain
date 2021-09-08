using Shouldly;
using System;
using System.Collections;
using System.Collections.Generic;
using WaterOnMountain;
using Xunit;

namespace WaterOnMountain_Test
{
  public class WaterCalculatorTest
  {
    [Theory]
    [ClassData(typeof(Data))]
    public void ForAllScenarios_ShouldCalculateCorrectResult(int[] array, int expectedResult)
    {
      //Arrange

      //Action
      var result = WaterCalculator.MaxWater(array);

      //Assert
      result.ShouldBe(expectedResult);
    }

    [Fact]
    public void Calculating_WithNullArray_ShouldThrowArgumentNullException()
    {
      //Arrange
      //Action
      //Assert
      Should.Throw<ArgumentNullException>(() => WaterCalculator.MaxWater(null));
    }

  }

  internal class Data : IEnumerable<object[]>
  {
    public IEnumerator<object[]> GetEnumerator()
    {
      List<object[]> list = new List<object[]>
      {
        new object[] { new int[] { }, 0 },
        new object[] { new int[] { 0 }, 0 },
        new object[] { new int[] { 1,0 }, 0 },
        new object[] { new int[] { 1,0,1 }, 1 },
        new object[] { new int[] { 2,0,1 }, 1 },
        new object[] { new int[] { 1,2,1 }, 0 },
        new object[] { new int[] { 1,2,3,4,3,2,5,4,5,3,4 }, 5 },
        new object[] { new int[] { 6,1,4,2,5,1,4,2,3,1,5 }, 22 },
        new object[] { new int[] { 6,1,4,2,5,1,4,2,3,1,3 }, 14 },
      };
      foreach (object[] obj in list)
      {
        yield return obj;
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}
