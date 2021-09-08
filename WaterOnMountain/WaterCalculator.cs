using System;

namespace WaterOnMountain
{
  public static class WaterCalculator
  {
    public static int MaxWater(int[] arrayOfIntegers)
    {
      // It won't continue if the arg is null...
      if (arrayOfIntegers == null)
        throw new ArgumentNullException(nameof(arrayOfIntegers));

      int lengthOfArray = arrayOfIntegers.Length;
      
      int accumulatedWater = 0;

      // For every element of the array...
      // except first and last element...
      for (int currentElement = 1; currentElement < lengthOfArray - 1; currentElement++)
      {

        // Find maximum element on its left...
        int maxOnLeft = arrayOfIntegers[currentElement];
        for (int leftIndex = 0; leftIndex < currentElement; leftIndex++)
        {
          maxOnLeft = Math.Max(maxOnLeft, arrayOfIntegers[leftIndex]);
        }

        // Find maximum element on its right...
        int maxOnRight = arrayOfIntegers[currentElement];
        for (int rightIndex = currentElement + 1; rightIndex < lengthOfArray; rightIndex++)
        {
          maxOnRight = Math.Max(maxOnRight, arrayOfIntegers[rightIndex]);
        }

        // Update maximum water value. Each column will add its capacity here...
        accumulatedWater += Math.Min(maxOnLeft, maxOnRight) - arrayOfIntegers[currentElement];
      }

      return accumulatedWater;
    }
  }
}
