namespace LovePets_Shared
{
    using System;

    public class Reminder_st
    {
        private int id;
        private DateTime endTime;
        private DateTime startTime;
        private string subject;
        private string location;
        private string notes;
        private bool isRecursive;
        private string recurrenceRule;
        private int backR;
        private int backG;
        private int backB;
        private int frontR;
        private int frontG;
        private int frontB;

        public int Id { get => this.id; set => this.id = value; }

        public DateTime EndTime { get => this.endTime; set => this.endTime = value; }

        public DateTime StartTime { get => this.startTime; set => this.startTime = value; }

        public string Subject { get => this.subject; set => this.subject = value; }

        public string Location { get => this.location; set => this.location = value; }

        public string Notes { get => this.notes; set => this.notes = value; }

        public bool IsRecursive { get => this.isRecursive; set => this.isRecursive = value; }

        public string RecurrenceRule { get => this.recurrenceRule; set => this.recurrenceRule = value; }

        public int BackR { get => this.backR; set => this.backR = value; }

        public int BackG { get => this.backG; set => this.backG = value; }

        public int BackB { get => this.backB; set => this.backB = value; }

        public int FrontR { get => this.frontR; set => this.frontR = value; }

        public int FrontG { get => this.frontG; set => this.frontG = value; }

        public int FrontB { get => this.frontB; set => this.frontB = value; }
    }
}
