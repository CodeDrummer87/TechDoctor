namespace Domain
{
    public struct Measurement
    {
        public string Denotement;
        public bool isInStock;

        public Measurement(string denotement) 
        {
            Denotement = denotement;
            isInStock = false;
        }
    }

    public struct MeasurementsCheckingStruct
    {
        public Measurement ins;
        public Measurement ubk;
        public Measurement se1;
        public Measurement se2;
        public Measurement se3;
        public Measurement se4;

        public MeasurementsCheckingStruct()
        {
            ins = new("INS");
            ubk = new("UBK");
            se1 = new("SE1");
            se2 = new("SE2");
            se3 = new("SE3");
            se4 = new("SE4");
        }
    }

    public struct ReportDataStruct
    {
        public int ProtocolNumber;
        public string SaveDate;
        public int PageCounter;
        public string PerformerINS;
        public string PerformerUBK;
        public string PerformerSE;
    }

    public enum DataFilter { Locomotive, PersonnelNumber, Relevance, Post, Lastname };
}
