using System;
using UnityEngine;


namespace GJ.Ranking
{
    [Serializable]
    internal class FixedLengthString
    {
        [SerializeField] private string value;
        [SerializeField] private int maxLength;


        public int MaxLength
        {
            get { return this.maxLength; }
        }


        public string Value
        {
            get { return this.value; }
            set
            {
                if (this.maxLength < value.Length)
                {
                    this.value = value.Substring(0, this.maxLength);
                }
                this.value = value;
            }
        }


        public FixedLengthString(int maxLength)
        {
            this.value = "";
            this.maxLength = maxLength;
        }


        public FixedLengthString(string value, int maxLength)
        {
            this.value = value;
            this.maxLength = maxLength;
        }
    }
}