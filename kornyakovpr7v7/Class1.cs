using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kornyakovpr7v7
{
    class Triad
    {
        protected int _first,
            _second,
            _therd;

        public int First { get; set; }
        public int Second { get; set; }
        public int Therd { get; set; }

        public Triad(int first, int second, int therd)
        {
            _first = first;
            _second = second;
            _therd = therd;
        }

        public bool Sravnenie(Triad p2)
        {
            if (First > p2.First || (First == p2.First && Second > p2.Second && Therd > p2.Therd)) return true;
            else return false;
        }

        public void SetParams(int first, int second, int therd)
        {
            First = first + 10;
            Second = second + 10;
            Therd = therd + 10;

        }

        public static bool operator >(Triad p1, Triad p2) => (p1.First > p2.First || p1.First == p2.First) && p1.Second > p2.Second && p1.Therd > p2.Therd;

        public static bool operator <(Triad p1, Triad p2)
        {
            return p1.First < p2.First && (p1.Second < p2.Second || p1.Second == p2.Second) && (p1.Therd < p2.Therd || p1.Therd == p2.Therd);
        }

        public static Triad operator ++(Triad triad)
        {
            triad.First += 10;
            triad.Second += 10;
            triad.Therd += 10;

            return triad;
        }

    }

    class Data : Triad
    {
        public new int First
        {
            set
            {
                if (IsDayExist(value) == true) _first = value;
                else throw new DataDoesntExistException();
            }
        }
        public new int Second
        {
            set
            {
                if (IsMonthExist(value) == true)
                {
                    _second = value;
                }
                else throw new DataDoesntExistException();
            }
        }
        public new int Therd
        {
            set
            {
                if (value > 0)
                {
                    _therd = value;
                }
                else throw new DataDoesntExistException();
            }
        }

        public Data(int day, int month, int year) : base(day, month, year)
        {
            if (IsDayExist(day) == false)
            {
                throw new DataDoesntExistException();
            }
            if (IsMonthExist(month) == false)
            {
                throw new DataDoesntExistException();
            }
            if (year <= 0)
            {
                throw new DataDoesntExistException();
            }
        }

        private bool IsDayExist(int value)
        {
            if (value <= 31 && (_second == 1 || _second == 3 || _second == 5 || _second == 7 || _second == 8 || _second == 10 || _second == 12))
            {
                return true;
            }
            else if (value <= 30 && (_second == 4 || _second == 6 || _second == 9 || _second == 11))
            {
                return true;
            }
            else if (value <= 29 && _second == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsMonthExist(int value)
        {
            if ((value <= 12) || (value >= 1))
            {
                return true;
            }
            return false;
        }

        public static int CompareDate(Data d1, Data d2)
        {
            if (d1._therd > d2._therd)
            {
                return 1;
            }
            if (d2._therd > d1._therd)
            {
                return -1;
            }
            else if (d1._second > d2._second)
            {
                return 1;
            }
            else if (d1._second < d2._second)
            {
                return -1;
            }

            else if (d1._first > d2._first)
            {
                return 1;
            }
            else if (d1._first < d2._first)
            {
                return -1;
            }
            else return 0;
        }
    }

    class DataDoesntExistException : Exception
    {
        public DataDoesntExistException() : base("Такой даты не существует") { }
    }
}
