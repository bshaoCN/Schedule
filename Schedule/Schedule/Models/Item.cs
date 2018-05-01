using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Schedule.Models
{
    public class Item: BaseModel
    {
        public readonly string Id;

        private TimeSpan startTime;
        public TimeSpan StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                if (value != startTime)
                {
                    startTime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private TimeSpan endTime;
        public TimeSpan EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                if (value != endTime)
                {
                    endTime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int severityID;
        public int SeverityID
        {
            get
            {
                return severityID;
            }
            set
            {
                if (value != severityID)
                {
                    severityID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string color;
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                if (value != color)
                {
                    color = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double completePercent;
        public double CompletePercent
        {
            get
            {
                return completePercent;
            }
            set
            {
                if (value != completePercent)
                {
                    completePercent = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value != description)
                {
                    description = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Item()
        {
            Id = Guid.NewGuid().ToString();
        }

    }

    public class Severity:BaseModel
    {
        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (value != text)
                {
                    text = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string color;
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                if (value != color)
                {
                    color = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
