﻿using Math = MathLib.Math;

namespace CalculatorModel 
{
    /// <summary>
    /// Class representing calculator memory. 
    /// </summary>
    public class Memory 
    {
        private Stack<decimal> MemoryStack { get; init; }

        /// <summary>
        /// Initializes a new instance of <see cref="Memory"/> class.
        /// </summary>
        public Memory() 
        {
            MemoryStack = new();
        }

        /// <summary>
        /// Saves a value.
        /// </summary>
        /// <param name="value"></param>
        public void MS(decimal value) 
        {
            MemoryStack.Push(value);
        }

        /// <summary>
        /// Recalls a value.
        /// </summary>
        /// <returns></returns>
        public decimal MR() 
        {
            return MemoryStack.Peek();
        }

        /// <summary>
        /// Clears last saved value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void MC() 
        {
            MemoryStack.Pop();
        }

        /// <summary>
        /// Adds a value to the last saved value.
        /// If no value is saved, treats the last save value as a zero.
        /// </summary>
        /// <param name="value"></param>
        public void MPlus(decimal value) 
        {
            if(MemoryStack.Count == 0) MS(value);
            var topValue = MemoryStack.Pop();
            MemoryStack.Push(Math.Add(topValue, value));
        }

        /// <summary>
        /// Subtracts a value from the last saved value.
        /// If no value is saved, treats the last save value as a zero.
        /// </summary>
        /// <param name="value"></param>
        public void MMinus(decimal value) 
        {
            if(MemoryStack.Count == 0) MS(-value);
            var topValue = MemoryStack.Pop();
            MemoryStack.Push(Math.Subtract(topValue, value));
        }
    }
}
