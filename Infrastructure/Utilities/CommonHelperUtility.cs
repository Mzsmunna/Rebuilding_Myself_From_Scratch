using Domain.Entities;
using Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities
{
    public static class CommonHelperUtility
    {
        public static string GenerateSubmitId()
        {
            string submitId = string.Empty;

            while (submitId.Length != 8)
            {
                Thread.Sleep(1);
                submitId = (DateTime.UtcNow.Subtract(new DateTime(2000, 1, 1))).TotalSeconds.GetHashCode().ToString("X");
            }
            return submitId;
        }

        public static bool IsDateTime(string txtDate)
        {
            DateTime tempDate;
            return DateTime.TryParse(txtDate, out tempDate);
        }

        public static string GetRegexValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return Regex.Replace(value, "[^a-zA-Z0-9_.()]+", "");
            }
            return value;
        }

        public static double GetUnixTime(DateTime dateTime)
        {
            var value = (dateTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return value;
        }

        private static DateTime? GetUTCKindDate(DateTime? date, bool isUnspecified = false)
        {
            DateTime parsed;
            if (date.HasValue)
            {
                if (date.Value.Kind != DateTimeKind.Utc)
                {
                    parsed = date.Value;

                    if (isUnspecified)
                    {
                        parsed = DateTime.SpecifyKind(parsed, DateTimeKind.Local);
                        parsed = TimeZoneInfo.ConvertTimeToUtc(parsed, TimeZoneInfo.Local);
                    }
                    else
                    {
                        parsed = DateTime.SpecifyKind(parsed, DateTimeKind.Utc);
                    }

                    return parsed;
                }
                else if (date.Value.Kind == DateTimeKind.Unspecified)
                {
                    parsed = date.Value;

                    parsed = DateTime.SpecifyKind(parsed, DateTimeKind.Local);
                    parsed = TimeZoneInfo.ConvertTimeToUtc(parsed, TimeZoneInfo.Local);

                    return parsed;
                }
                else
                {
                    return date;
                }
            }
            else
            {
                return null;
            }
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        public static string GenerateSubmitId(string type)
        {
            string submitId = string.Empty;

            while (submitId.Length != 8)
            {
                Thread.Sleep(1);
                submitId = (DateTime.UtcNow.Subtract(new DateTime(2000, 1, 1))).TotalSeconds.GetHashCode().ToString("X");
            }
            return submitId;
        }

        public static String GenerateEmailToClientCintentName()
        {
            String fileName = string.Empty;
            DateTime currentDate = GetCurrentTimeInEST();

            fileName = String.Format("EmailToClientContent_{0}.txt", currentDate.ToString("yyyy_MM_dd"));

            return fileName;
        }

        public static Boolean HasSpecialCharacter(String stringToMatch)
        {
            return !Regex.IsMatch(stringToMatch, @"^[a-z A-Z 0-9 \s]+$", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.CultureInvariant);
        }

        public static string CleanText(String stringToclean)
        {
            return stringToclean.Trim();
        }

        public static DateTime? GetDateFromString(string date, bool isTwoDigitYear = false, string currentDateFormat = null)
        {
            if (!string.IsNullOrEmpty(date))
            {
                if (!string.IsNullOrEmpty(currentDateFormat))
                {
                    if (currentDateFormat.ToLower().Contains("yyyymmdd"))
                    {
                        date = date.Insert(4, "/");
                        date = date.Insert(7, "/");
                    }
                    else if (currentDateFormat.ToLower().Contains("mmddyy")
                          || currentDateFormat.ToLower().Contains("ddmmyy")
                    //|| currentDateFormat.ToLower().Contains("mmddyyyy")
                    //|| currentDateFormat.ToLower().Contains("ddmmyyyy")
                    )
                    {
                        date = date.Insert(2, "/");
                        date = date.Insert(5, "/");
                    }
                    else if (currentDateFormat.ToLower().Contains("ddmmmyy"))
                    {
                        date = date.Insert(2, "/");
                        date = date.Insert(6, "/");
                    }
                    else if (currentDateFormat.ToLower().Contains("ddmmmmyy"))
                    {
                        date = date.Insert(2, "/");
                        date = date.Insert(7, "/");
                    }
                }

                DateTime parsed;
                var myCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();

                var formats = new string[]
                {
                    "yyyy:MM:dd HH:mm:ss",
                    "yyyy/MM/dd HH:mm:ss",
                    "yyyy-MM-dd HH:mm:ss",
                    "yyyy:MM:dd",
                    "yyyy/MM/dd",
                    "yyyy-MM-dd",
                    "MM:dd:yyyy HH:mm:ss",
                    "MM/dd/yyyy HH:mm:ss",
                    "MM-dd-yyyy HH:mm:ss",
                    "MM:dd:yyyy",
                    "MM/dd/yyyy",
                    "MM-dd-yyyy",
                    "dd:MM:yyyy HH:mm:ss",
                    "dd/MM/yyyy HH:mm:ss",
                    "dd-MM-yyyy HH:mm:ss",
                    "dd:MM:yyyy",
                    "dd/MM/yyyy",
                    "dd-MM-yyyy",

                    "dd-MM-yy HH:mm:ss tt",
                    "dd-MM-yy hh:mm:ss tt",
                    "dd-MM-yy h:mm:ss tt",
                    "dd-MMM-yy HH:mm:ss tt",
                    "dd-MMM-yy hh:mm:ss tt",
                    "dd-MMM-yy h:mm:ss tt",
                    "dd-MMMM-yy HH:mm:ss tt",
                    "dd-MMMM-yy hh:mm:ss tt",
                    "dd-MMMM-yy h:mm:ss tt",
                };

                if (DateTime.TryParseExact(
                       date,
                       formats,
                       myCulture, //System.Globalization.CultureInfo.InvariantCulture,
                       DateTimeStyles.AssumeLocal, // Please note AssumeLocal might be wrong here...
                       out parsed)
                 )
                {
                    //parsed = DateTime.Parse(date, new CultureInfo("en-US", true));

                    if (isTwoDigitYear)
                    {
                        //myCulture = new CultureInfo("en-US", true);
                        myCulture.Calendar.TwoDigitYearMax = 2021;
                    }

                    parsed = DateTime.Parse(date, myCulture);
                    //parsed = parsed.ToUniversalTime();
                    parsed = DateTime.SpecifyKind(parsed, DateTimeKind.Utc);
                    return parsed;
                }
                else
                {
                    // Log error, perhaps?
                    try
                    {
                        parsed = DateTime.ParseExact(date, "MM/dd/yyyy HH:mm:ss tt", myCulture);
                        return parsed;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public static string TwoDigitYearIntoFour(string date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                date = date.Replace('/', '-');
                var year = date.Split('-').LastOrDefault();
                var mmddyyyy = new List<string>(date.Split(','));

                if (!string.IsNullOrEmpty(year))
                {
                    if (year.Length == 2 && mmddyyyy.Count == 3)
                    {
                        int nYear;

                        if (Int32.TryParse(year, out nYear) && nYear >= 22)
                        {
                            mmddyyyy[2] = "19" + year;
                            date = mmddyyyy[0] + mmddyyyy[1] + mmddyyyy[2];
                        }
                    }
                }

                return date;
            }
            else
            {
                // Log error, perhaps?
                return null;
            }
        }

        public static DateTime GetCurrentTimeInEST()
        {
            var timeUtc = DateTime.UtcNow;
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
        }

        public static DateTime GetESTTimeFromUTC(DateTime timeUtc)
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
        }

        public static string GetPropertyValueByKey(List<Field> properties, string key)
        {
            foreach (var item in properties)
            {
                if (item.Key == key)
                {
                    return item.Value;
                }
            }
            return "";
        }

        public static string SolveCasingIssue(string value, CasingType casingType)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            if (!string.IsNullOrEmpty(value))
            {
                if (casingType.Equals(CasingType.ToLowerCase))
                {
                    return textInfo.ToLower(value);
                }
                else if (casingType.Equals(CasingType.ToUpperCase))
                {
                    return textInfo.ToUpper(value);
                }
                else if (casingType.Equals(CasingType.ToTitleCase))
                {
                    return textInfo.ToTitleCase(value);
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static DateTime[] GetStartEndDate(DateTime dateTime, bool isMongo)
        {
            DateTime startDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0);
            DateTime endDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999);
            if (isMongo)
            {
                return new[]
                {
                    TimeZoneInfo.ConvertTimeToUtc(startDate).AddHours(-4),
                    TimeZoneInfo.ConvertTimeToUtc(endDate).AddHours(-4)
                };
            }
            else
            {
                return new[]
                {
                    startDate,
                    endDate
                };
            }
        }

        public static DateTime[] GetPreviousDayDate()
        {
            DateTime start = DateTime.UtcNow.AddDays(-1);

            DateTime previousStartDate = new DateTime(start.Year, start.Month, start.Day, 0, 0, 0);
            DateTime previousEndDate = new DateTime(start.Year, start.Month, start.Day, 23, 59, 59);

            DateTime[] dateTimes = { previousStartDate, previousEndDate };
            return dateTimes;
        }

        public static DateTime[] GetCurrentYearStartAndEndDate(bool isMongo)
        {
            DateTime startDate = new DateTime(DateTime.UtcNow.Year, 1, 1, 0, 0, 0);
            DateTime endDate = new DateTime(DateTime.UtcNow.Year, 12, 31, 23, 59, 59);

            if (isMongo)
            {
                return new[]
                {
                    TimeZoneInfo.ConvertTimeToUtc(startDate).AddHours(-5),
                    TimeZoneInfo.ConvertTimeToUtc(endDate).AddHours(-5)
                };
            }
            else
            {
                return new[]
                {
                    startDate,
                    endDate
                };
            }
        }

        public static string GetPropertiesValue(List<Field> fields, string key)
        {
            foreach (var field in fields)
            {
                if (key == field.Key)
                    return field.Value;
            }
            return "";
        }

        public static string GetSortedStringForCommaSeparatedNumbers(string list)
        {
            if (!string.IsNullOrEmpty(list))
            {
                var splitedString = list.Split(',');
                int[] response = new int[0];
                response = splitedString.Select(i => int.Parse(i)).ToArray();
                Array.Sort(response);
                return string.Join(",", response.Select(element => element.ToString()));
            }
            return list;
        }

        public static string GetUniqueNumber()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            var FormNumber = BitConverter.ToUInt32(buffer, 0) ^ BitConverter.ToUInt32(buffer, 4) ^ BitConverter.ToUInt32(buffer, 8) ^ BitConverter.ToUInt32(buffer, 12);
            return FormNumber.ToString("X");

        }

        public static T TrimStringData<T>(T objectModel, string replace = "", bool removeExtraSpace = false) where T : class
        {
            //if(!string.IsNullOrEmpty(prospectMeta.Admin_Notes))
            //    prospectModel.Admin_Notes = Regex.Replace(prospectMeta.Admin_Notes, @"\t|\n|\r", "");

            foreach (var property in objectModel.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(string))
                {
                    object value = property.GetValue(objectModel, null);

                    if (value == null)
                    {
                        value = "";
                    }

                    value = Regex.Replace(value.ToString(), @"\t|\n|\r", replace);
                    //value = Regex.Replace(value.ToString(), @"\t|\n|\r|'    '", replace);
                    //value = value?.ToString().Replace(Environment.NewLine, replace);

                    value = value.ToString().Trim();

                    if (removeExtraSpace)
                    {
                        //value = Regex.Replace(value.ToString(), @"\s+", " ");
                        //value = Regex.Replace(value.ToString(), @"\s+", " ", RegexOptions.Multiline);

                        RegexOptions options = RegexOptions.None;
                        Regex regex = new Regex("[ ]{2,}", options);
                        value = regex.Replace(value.ToString(), " ");
                    }

                    property.SetValue(objectModel, value);
                }
                else if (property.PropertyType.IsClass && property.PropertyType.Assembly == typeof(T).Assembly) //property.PropertyType.Assembly.FullName == typeof(T).Assembly.FullName)
                {
                    object value = property.GetValue(objectModel, null);
                    value = TrimStringData(value);
                }
            }

            return objectModel;
        }

        //Dynamic Entity Data Mapping
        public static T CompareDataAndMap<T>(T objectMapTo, T objectMapFrom, List<string> ignoreProperties, bool allowEmptyValueToMap = false) where T : class, new()
        {
            if (objectMapTo == null)
                objectMapTo = new T();

            if (objectMapFrom == null)
                objectMapFrom = new T();

            foreach (PropertyInfo property in objectMapTo.GetType().GetProperties())
            {
                if (!ignoreProperties.Contains(property.Name))
                {
                    //var propertyType = property.PropertyType;
                    //var baseType = property.PropertyType.BaseType;

                    if (property.PropertyType.IsClass == false
                        || property.PropertyType.IsPrimitive
                        || property.PropertyType == typeof(int)
                        || property.PropertyType == typeof(int?)
                        || property.PropertyType == typeof(long)
                        || property.PropertyType == typeof(long?)
                        || property.PropertyType == typeof(float)
                        || property.PropertyType == typeof(float?)
                        || property.PropertyType == typeof(double)
                        || property.PropertyType == typeof(double?)
                        || property.PropertyType == typeof(decimal)
                        || property.PropertyType == typeof(decimal?)
                        || property.PropertyType == typeof(Decimal)
                        || property.PropertyType == typeof(Decimal?)
                        || property.PropertyType == typeof(String)
                        || property.PropertyType == typeof(string)
                        || property.PropertyType == typeof(bool)
                        || property.PropertyType == typeof(bool?)
                        || property.PropertyType == typeof(Boolean)
                        || property.PropertyType == typeof(Boolean?)
                        //|| property.PropertyType == typeof(Nullable)
                        //|| property.PropertyType == typeof(Nullable<>)
                        || property.PropertyType == typeof(DateTime)
                        || property.PropertyType == typeof(DateTime?))
                    {
                        object to = property.GetValue(objectMapTo, null);
                        object from = property.GetValue(objectMapFrom, null);

                        if (to == null)
                        {
                            to = "";
                        }

                        if (from == null)
                        {
                            from = "";
                        }

                        if (to.Equals(from))
                        {
                            //do something
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(from.ToString()) || allowEmptyValueToMap)
                            {
                                to = from;
                                property.SetValue(objectMapTo, to);
                            }
                        }
                    }
                    else if (property.PropertyType.IsClass && property.PropertyType.Assembly == typeof(T).Assembly) //property.PropertyType.Assembly.FullName == typeof(T).Assembly.FullName)
                    {
                        object value1 = property.GetValue(objectMapTo, null);
                        object value2 = property.GetValue(objectMapFrom, null);

                        CompareDataAndMap(value1, value2, ignoreProperties, allowEmptyValueToMap);
                    }
                    else if (property.PropertyType.IsGenericType && (property.PropertyType.GetGenericTypeDefinition() == typeof(List<>)))
                    {
                        object objectMapToList = property.GetValue(objectMapTo, null);
                        object objectMapFromList = property.GetValue(objectMapFrom, null);

                        Type type = property.PropertyType.GetGenericArguments().FirstOrDefault();

                        //var listType = property.PropertyType.GetGenericArguments().FirstOrDefault().Name;

                        Type listType = typeof(List<>).MakeGenericType(type);
                        IList objectMapToListData = (IList)Activator.CreateInstance(listType);
                        IList objectMapFromListData = (IList)Activator.CreateInstance(listType);

                        if (objectMapToList != null)
                            objectMapToListData = (IList)objectMapToList;

                        if (objectMapFromList != null)
                            objectMapFromListData = (IList)objectMapFromList;

                        if ((objectMapToListData != null && objectMapToListData.Count > 0) || (objectMapFromListData != null && objectMapFromListData.Count > 0))
                        {
                            int objectMapToListCount = 0;
                            int objectMapFromListCount = 0;
                            int maxLoop = 0;

                            if (objectMapToListData != null)
                                objectMapToListCount = objectMapToListData.Count;

                            if (objectMapFromListData != null)
                                objectMapFromListCount = objectMapFromListData.Count;

                            if (objectMapToListCount >= objectMapFromListCount)
                                maxLoop = objectMapToListCount;
                            else
                                maxLoop = objectMapFromListCount;

                            for (int i = 0; i <= maxLoop; i++)
                            {
                                object objectMapToValue = null;
                                object objectMapFromValue = null;

                                if (i < objectMapToListCount)
                                    objectMapToValue = objectMapToListData[i];
                                else
                                    objectMapToValue = Activator.CreateInstance(type);

                                if (i < objectMapFromListCount)
                                    objectMapFromValue = objectMapFromListData[i];
                                else
                                    objectMapFromValue = Activator.CreateInstance(type);

                                CompareDataAndMap(objectMapToValue, objectMapFromValue, ignoreProperties, allowEmptyValueToMap);
                            }
                        }
                    }
                }
            }

            return objectMapTo;
        }

        //Dynamic Entity Compare
        public static List<ModifiedField> CompareData<T>(T currentObject, T previousObject, List<string> ignoreProperties = null, string parentObjectName = "") where T : class, new()
        {
            if (currentObject == null)
                currentObject = new T();

            if (previousObject == null)
                previousObject = new T();

            if (ignoreProperties == null)
                ignoreProperties = new List<string>();

            List<ModifiedField> modifiedFields = new List<ModifiedField>();

            foreach (PropertyInfo property in currentObject.GetType().GetProperties())
            {
                if (!ignoreProperties.Contains(property.Name))
                {
                    object currentObjectValue = property.GetValue(currentObject, null);
                    object previousObjectValue = property.GetValue(previousObject, null);
                    string currentObjectName = string.Empty;

                    if (currentObjectValue != null || previousObjectValue != null)
                    {
                        if (string.IsNullOrEmpty(parentObjectName))
                        {
                            currentObjectName = new String(typeof(T).Name);
                        }
                        else
                        {
                            currentObjectName = new String(parentObjectName);
                        }

                        if (property.PropertyType.IsClass == false
                            || property.PropertyType.IsPrimitive
                            || property.PropertyType == typeof(int)
                            || property.PropertyType == typeof(int?)
                            || property.PropertyType == typeof(long)
                            || property.PropertyType == typeof(long?)
                            || property.PropertyType == typeof(float)
                            || property.PropertyType == typeof(float?)
                            || property.PropertyType == typeof(double)
                            || property.PropertyType == typeof(double?)
                            || property.PropertyType == typeof(decimal)
                            || property.PropertyType == typeof(decimal?)
                            || property.PropertyType == typeof(Decimal)
                            || property.PropertyType == typeof(Decimal?)
                            || property.PropertyType == typeof(String)
                            || property.PropertyType == typeof(string)
                            || property.PropertyType == typeof(bool)
                            || property.PropertyType == typeof(bool?)
                            || property.PropertyType == typeof(Boolean)
                            || property.PropertyType == typeof(Boolean?)
                            //|| property.PropertyType == typeof(Nullable)
                            //|| property.PropertyType == typeof(Nullable<>)
                            || property.PropertyType == typeof(DateTime)
                            || property.PropertyType == typeof(DateTime?))
                        {
                            var modifiedField = GetModifiedField(currentObjectValue, previousObjectValue, property, currentObjectName);

                            if (modifiedField != null)
                                modifiedFields.Add(modifiedField);
                        }
                        else if (property.PropertyType.IsClass && property.PropertyType.Assembly == typeof(T).Assembly) //property.PropertyType.Assembly.FullName == typeof(T).Assembly.FullName)
                        {
                            if (currentObjectValue == null)
                                currentObjectValue = Activator.CreateInstance(property.PropertyType);

                            if (previousObjectValue == null)
                                previousObjectValue = Activator.CreateInstance(property.PropertyType);

                            modifiedFields.AddRange(CompareData(currentObjectValue, previousObjectValue, ignoreProperties, currentObjectName + "." + property.Name));
                        }
                        else if (property.PropertyType.IsGenericType && (property.PropertyType.GetGenericTypeDefinition() == typeof(List<>)))
                        {
                            object currentObjectList = property.GetValue(currentObject, null);
                            object previousObjectList = property.GetValue(previousObject, null);

                            //var list = entity.GetType().GetProperty(property.Name).GetValue(entity, null);
                            //Type[] typeLists = property.PropertyType.GetGenericArguments();

                            Type type = property.PropertyType.GetGenericArguments().FirstOrDefault();

                            var listType = property.PropertyType.GetGenericArguments().FirstOrDefault().Name;

                            var InlineAllowedType = new List<string>(new string[] { "int", "long", "float", "double", "decimal", "string", "bool", "boolean", "datetime" });

                            Type lisType = typeof(List<>).MakeGenericType(type);
                            IList currentObjectListData = (IList)Activator.CreateInstance(lisType);
                            IList previousObjectListData = (IList)Activator.CreateInstance(lisType);

                            if (currentObjectList != null)
                                currentObjectListData = (IList)currentObjectList;

                            if (previousObjectList != null)
                                previousObjectListData = (IList)previousObjectList;

                            if ((currentObjectListData != null && currentObjectListData.Count > 0) || (previousObjectListData != null && previousObjectListData.Count > 0))
                            {
                                if (InlineAllowedType.Contains(listType?.ToLower()))
                                {
                                    if (!string.IsNullOrEmpty(listType) && listType.ToLower().Equals("datetime"))
                                    {
                                        if (currentObjectListData != null && currentObjectListData.Count > 0)
                                            currentObjectValue = string.Join("; ", currentObjectListData.Cast<DateTime>().Select(n => n.ToString()).ToArray()); //"MM/dd/yyyy"
                                        else
                                            currentObjectValue = "";

                                        if (previousObjectListData != null && previousObjectListData.Count > 0)
                                            previousObjectValue = string.Join("; ", previousObjectListData.Cast<DateTime>().Select(n => n.ToString()).ToArray()); //"MM/dd/yyyy"
                                        else
                                            previousObjectValue = "";
                                    }
                                    else
                                    {
                                        if (currentObjectListData != null && currentObjectListData.Count > 0)
                                            currentObjectValue = string.Join("; ", currentObjectListData.Cast<object>().Select(n => n.ToString()).ToArray());
                                        else
                                            currentObjectValue = "";

                                        if (previousObjectListData != null && previousObjectListData.Count > 0)
                                            previousObjectValue = string.Join("; ", previousObjectListData.Cast<object>().Select(n => n.ToString()).ToArray());
                                        else
                                            previousObjectValue = "";
                                    }

                                    var modifiedField = GetModifiedField(currentObjectValue, previousObjectValue, property, currentObjectName);

                                    if (modifiedField != null)
                                    {
                                        //modifiedField.PropertyType = "List<" + lisType + ">";
                                        modifiedFields.Add(modifiedField);
                                    }
                                }
                                else
                                {
                                    int currentObjectListCount = 0;
                                    int previousObjectListCount = 0;
                                    int maxLoop = 0;

                                    if (currentObjectListData != null)
                                        currentObjectListCount = currentObjectListData.Count;

                                    if (previousObjectListData != null)
                                        previousObjectListCount = previousObjectListData.Count;

                                    if (currentObjectListCount >= previousObjectListCount)
                                        maxLoop = currentObjectListCount;
                                    else
                                        maxLoop = previousObjectListCount;

                                    for (int i = 0; i <= maxLoop; i++)
                                    {
                                        string nestedObjectName = string.Empty;

                                        if (i < currentObjectListCount)
                                            currentObjectValue = currentObjectListData[i];
                                        else
                                            currentObjectValue = Activator.CreateInstance(type);

                                        if (i < previousObjectListCount)
                                            previousObjectValue = previousObjectListData[i];
                                        else
                                            previousObjectValue = Activator.CreateInstance(type);

                                        if (maxLoop > 1)
                                            nestedObjectName = currentObjectName + "." + property.Name + "_" + (i + 1);
                                        else
                                            nestedObjectName = currentObjectName + "." + property.Name;

                                        modifiedFields.AddRange(CompareData(currentObjectValue, previousObjectValue, ignoreProperties, nestedObjectName));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return modifiedFields;
        }

        private static ModifiedField GetModifiedField(object currentObjectValue, object previousObjectValue, PropertyInfo property, string currentObjectName = "")
        {
            string customPropertyName = string.Empty;
            bool currentHasValue = false;
            bool previousHasValue = false;

            if (currentObjectValue == null)
                currentObjectValue = "";
            else
                currentHasValue = true;

            if (previousObjectValue == null)
                previousObjectValue = "";
            else
                previousHasValue = true;

            if (!string.IsNullOrEmpty(currentObjectName))
                customPropertyName = new String(currentObjectName + "." + property.Name);
            else
                customPropertyName = new String(property.Name);

            //DateTime Property
            if (property.PropertyType == typeof(DateTime)
            || property.PropertyType == typeof(DateTime?))
            {
                string currentObjectDate = currentObjectValue.ToString();
                string previousObjectDate = previousObjectValue.ToString();

                if (currentHasValue && previousHasValue)
                {
                    DateTime? currentDate = (DateTime?)currentObjectValue;
                    DateTime? previousDate = (DateTime?)previousObjectValue;

                    if (currentDate.HasValue && previousDate.HasValue)
                    {
                        if (!currentDate.Value.Equals(previousDate.Value))
                        {
                            if (currentDate.Value.Kind != DateTimeKind.Utc)
                                currentDate = GetUTCKindDate(currentDate, true);

                            if (previousDate.Value.Kind != DateTimeKind.Utc)
                                previousDate = GetUTCKindDate(previousDate, true);

                            if (currentDate.HasValue && previousDate.HasValue)
                            {
                                if (currentDate.Value.Equals(previousDate.Value))
                                {
                                    currentObjectValue = currentDate;
                                    previousObjectValue = previousDate;
                                }
                            }
                        }
                    }
                }

                if (currentObjectDate.Equals("1/1/0001 12:00:00 AM"))
                {
                    currentObjectValue = "";
                }
                else if (currentObjectDate.Equals("01-Jan-01 12:00:00 AM"))
                {
                    currentObjectValue = "";
                }

                if (previousObjectDate.Equals("1/1/0001 12:00:00 AM"))
                {
                    previousObjectValue = "";
                }
                else if (previousObjectDate.Equals("01-Jan-01 12:00:00 AM"))
                {
                    previousObjectValue = "";
                }
            }

            if (!currentObjectValue.Equals(previousObjectValue))
            {
                var newField = new ModifiedField()
                {
                    PropertyInfo = property,
                    PropertyType = property.PropertyType?.ToString(),
                    EntityName = currentObjectName,
                    PropertyName = property.Name,
                    CustomPropertyName = customPropertyName,
                    CurrentValue = currentObjectValue.ToString(),
                    PreviousValue = previousObjectValue.ToString(),
                };

                return newField;
            }
            else
            {
                return null;
            }
        }

        public static object GetPropValue(object src, string propName)
        {
            if (src != null && !string.IsNullOrEmpty(propName) && src.GetType().GetProperty(propName) != null)
            {
                var obj = src.GetType().GetProperty(propName).GetValue(src, null);

                return obj;
            }

            return null;
        }

        public static string GetPropValueAsString(object src, string propName)
        {
            if (src != null && !string.IsNullOrEmpty(propName) && src.GetType().GetProperty(propName) != null)
            {
                var obj = src.GetType().GetProperty(propName).GetValue(src, null);

                if (obj == null)
                {
                    obj = string.Empty;
                }

                return obj.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static DateTime? GetPropValueAsDate(object src, string datePropName)
        {
            if (src != null && !string.IsNullOrEmpty(datePropName) && src.GetType().GetProperty(datePropName) != null)
            {
                var obj = src.GetType().GetProperty(datePropName).GetValue(src, null);

                if (obj != null)
                {
                    if (src.GetType().GetProperty(datePropName).PropertyType == typeof(DateTime)
                    || src.GetType().GetProperty(datePropName).PropertyType == typeof(DateTime?))
                    {
                        return (DateTime?)obj;
                    }
                }
            }

            return null;
        }

        public static T CloneObject<T>(T obj)
        {
            var config = new JsonSerializerSettings { Error = (se, ev) => { ev.ErrorContext.Handled = true; } };

            var clonedObject = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj), config);

            return clonedObject;
        }

        public static List<string> GetIgnoredProperties<T>(T obj) where T : class, new()
        {
            var ignoreProperties = new List<string>();

            if (obj == null)
                obj = new T();

            var entityName = typeof(T).Name;

            ignoreProperties.Add("Id");
            ignoreProperties.Add("CreatedBy");
            ignoreProperties.Add("ModifiedBy");
            ignoreProperties.Add("SavedBy");
            ignoreProperties.Add("SubmittedBy");
            ignoreProperties.Add("CreatedOn");
            ignoreProperties.Add("ModifiedOn");
            ignoreProperties.Add("SavedOn");
            ignoreProperties.Add("SubmittedOn");

            return ignoreProperties;
        }

        public static DateTime? GetUTCKindDate(DateTime? date)
        {
            DateTime parsed;
            if (date.HasValue)
            {
                parsed = date.Value.Date;
                parsed = DateTime.SpecifyKind(parsed, DateTimeKind.Utc);
                return parsed.Date;
            }
            else
            {
                return null;
            }
        }

        public static void LogExport(List<string> items, string fileName)
        {
            StringBuilder messages = new StringBuilder();
            items.ForEach(item => messages.AppendLine(item));
            var location = string.Empty; //Path.Combine(ApplicationConstants.ExportFilePath + "/" + fileName);
            System.IO.File.AppendAllText(location, messages.ToString());
            messages.Clear();
        }

        public static string TrimLeadingZeros(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                Regex rx = new Regex(@"^0+(\d+)$");
                return rx.Replace(data, @"$1");
            }
            else
            {
                return "";
            }
        }
    }
}
