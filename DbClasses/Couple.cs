﻿namespace SchoolGrades.DbClasses
{
    class Couple
    {
        int key;
        object value;
        //private int v;
        //private DateTime dateTime;

        public Couple()
        {
        }

        public int Key { get => key; set => key = value; }
        public object Value { get => value; set => this.value = value; }
    }
}
