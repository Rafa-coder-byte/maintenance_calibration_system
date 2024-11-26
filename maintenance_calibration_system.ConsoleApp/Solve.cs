namespace maintenance_calibration_system.ConsoleApp;
    public enum CommunicationProtocol
    {
        ModBus,
        OPC,
        UA,
        BACNet,
    }
    public class PhysicalQuantity
    {
        public string name{get;set;}
        public string Magnitude{get;set;}

        public PhysicalQuantity(string name, string magnitude)
        {
            this.name = name;
            this.Magnitude = magnitude;
        }
    }
    public abstract class Equipment
    {
        public PhysicalQuantity? physicalQuantity;
        public string? alphaNumericCode;
        public string? manufacturerName;
    }

    public class Sensor : Equipment
    {
        public string initFunct{get;set;}
        public bool calibrated{get;set;}
        public CommunicationProtocol protocol{get;set;}
        public Sensor(PhysicalQuantity physicalQuantity, string alphaNumericCode,string manufacturerName,CommunicationProtocol protocol,string initFunct)
        {
            this.physicalQuantity = physicalQuantity;
            this.alphaNumericCode = alphaNumericCode;
            this.manufacturerName = manufacturerName;
            this.protocol = protocol;
            this.initFunct = initFunct;
            calibrated = false;
        }
    } 

    public class Calibraciones
    {
        public List<Sensor> calibratedSensors{get;set;}
        public Calibraciones()
        {
            calibratedSensors = Main.sensors.Where((x) => x.calibrated).ToList();
        }
        
    }

    public static class Main
    {
        public static List<Sensor> sensors{get;set;}
    }

