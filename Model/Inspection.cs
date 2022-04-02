using System;

namespace MIS.Model
{
    [Serializable]
    public class Inspection
    {
        public bool IsInspected { get; set; }
        public string InspectionDate { get; set; }
        public string Complaints { get; set; }
        public string Anamnesis { get; set; }
        public string ObjectiveExamination { get; set; }
        public string StLocalis { get; set; }
        public string UltrasoundData { get; set; }
        public string Diagnosis { get; set; }
        public string Recomendations { get; set; }
        public string Treatment { get; set; }

        public Inspection(bool isInspected, string inspectionDate, string complaints,
            string anamnesis, string objectiveExamination, string stLocalis, string ultrasoundData, 
            string diagnosis, string recomendations, string treatment)
        {
            IsInspected = isInspected;
            InspectionDate = inspectionDate;
            Complaints = complaints;
            Anamnesis = anamnesis;
            ObjectiveExamination = objectiveExamination;
            StLocalis = stLocalis;
            UltrasoundData = ultrasoundData;
            Diagnosis = diagnosis;
            Recomendations = recomendations;
            Treatment = treatment;
        }

        public Inspection(string inspectionDate)
        {
            IsInspected = false;
            InspectionDate = inspectionDate;
            Complaints = "";
            Anamnesis = "";
            ObjectiveExamination = "";
            StLocalis = "";
            UltrasoundData = "";
            Diagnosis = "";
            Recomendations = "";
            Treatment = "";
        }
    }
}
