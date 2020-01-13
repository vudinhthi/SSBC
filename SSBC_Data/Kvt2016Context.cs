using System;
using System.Collections.Generic;

//===============
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Reflection;

namespace SSBC_Data
{
    public partial class SourceContext
    {
        protected void InitializeMapping(DbModelBuilder modelBuilder)
        {
        }

        public class MSG
        {
            public Boolean IsError { get; set; }
            public String MsgInformation { get; set; }

            public MSG()
            {
            }

            public MSG(String Status, bool error)
            {
                IsError = error;
                switch (Status)
                {
                    case "Added":
                        MsgInformation = IsError == true ? "Không thể thêm mới. Có lỗi" : "Đã thêm mới";
                        break;

                    case "Modified":
                        MsgInformation = IsError == true ? "Có lỗi" : "Đã cập nhật";
                        break;

                    case "Deleted":
                        MsgInformation = IsError == true ? "Có lỗi" : "Đã Xóa!";
                        break;
                }
            }
        }

        public class Action
        {
            public static DateTime FirstDayOfMonth(DateTime value)
            {
                return new DateTime(value.Year, value.Month, 1);
            }

            public static string Evaluate(string expression)
            {
                try
                {
                    var loDataTable = new DataTable();
                    var loDataColumn = new DataColumn("Eval", typeof(double), expression);
                    loDataTable.Columns.Add(loDataColumn);
                    loDataTable.Rows.Add(0);
                    return Convert.ToString(loDataTable.Rows[0]["Eval"]);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    return expression;
                }
            }

            public static int DaysInMonth(DateTime value)
            {
                return DateTime.DaysInMonth(value.Year, value.Month);
            }

            public static DateTime LastDayOfMonth(DateTime value)
            {
                return new DateTime(value.Year, value.Month, DaysInMonth(value));
            }

            public static int GetWeeksInYear(int year)
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date1 = new DateTime(year, 12, 31);
                Calendar cal = dfi.Calendar;
                return cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
                                                    dfi.FirstDayOfWeek);
            }

            public static int GetWeekNumber(DateTime dtPassed)
            {
                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                return weekNum;
            }

            public static DateTime FirstdayOfWeek(DateTime dtPassed)
            {
                DateTime Firstday = dtPassed.AddDays(-(int)dtPassed.DayOfWeek);
                return Firstday;
            }

            public static DateTime EnddayOfWeek(DateTime dtPassed)
            {
                DateTime Firstday = dtPassed.AddDays(-(int)dtPassed.DayOfWeek);
                DateTime Endday = Firstday.AddDays(6);
                return Endday;
            }

            public static string CreateAutoID()
            {
                return Guid.NewGuid().ToString("N");
            }

            public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
            {
                for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                    yield return day;
            }

            public static DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);

                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }

            #region Button

            public static bool IsVisible_Button_Delete(String ObjectState)
            {
                bool _value = false;
                switch (ObjectState)
                {
                    case "Added":
                        _value = false;
                        break;

                    case "Modified":
                        _value = false;
                        break;

                    case "Deleted":
                        _value = true;
                        break;

                    case "Saved":
                        _value = true;
                        break;
                }
                return _value;
            }

            public static bool IsVisible_Button_AddvsEdit(String ObjectState)
            {
                bool _value = false;
                switch (ObjectState)
                {
                    case "Added":
                        _value = false;
                        break;

                    case "Modified":
                        _value = false;
                        break;

                    case "Deleted":
                        _value = true;
                        break;

                    case "Saved":
                        _value = true;
                        break;
                }
                return _value;
            }

            public static bool IsVisible_Button_SavevsCancel(String ObjectState)
            {
                bool _value = false;
                switch (ObjectState)
                {
                    case "Added":
                        _value = true;
                        break;

                    case "Modified":
                        _value = true;
                        break;

                    case "Deleted":
                        _value = false;
                        break;

                    case "Saved":
                        _value = false;
                        break;
                }
                return _value;
            }

            #endregion Button
        }
    }
}