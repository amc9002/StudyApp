using System;
using System.Collections.Generic;
using System.Text;

namespace StudyApp
{
    class Mark
    {
        public int Teachers_id { get; set; }
        public int Subjects_Id { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public Mark(DateTime date, int teachers_id, int subjects_id, int score)
        {
            Date = date;
            Teachers_id = teachers_id;
            Subjects_Id = subjects_id;
            Score = score;
        }
    }
}
