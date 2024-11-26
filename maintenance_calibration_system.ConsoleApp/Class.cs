using System.Dynamic;

namespace maintenance_calibration_system.ConsoleApp;
    public enum CommunicationProtocol
    {
        ModBus,
        OPC,
        UA,
        BACNet,
    }

    public enum SignalControl
    {
        Digital,
        Analog,
    }

    public enum TypeMaintenance
    {
        Preventivo,
        Correctivo,
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
        public string principleOperation{get;set;}
        public bool calibrated{get;set;}
        public CommunicationProtocol protocol{get;set;}
       
        public Sensor(PhysicalQuantity physicalQuantity, string alphaNumericCode,string manufacturerName,CommunicationProtocol protocol,string principleOperation)
        {
            this.physicalQuantity = physicalQuantity;
            this.alphaNumericCode = alphaNumericCode;
            this.manufacturerName = manufacturerName;
            this.protocol = protocol;
            this.principleOperation = principleOperation;
            calibrated = false;
        }
    } 

     public class Actuador : Equipment
    {
        public string codeControl {get;set;} 
        public CommunicationProtocol protocol{get;set;}
        public SignalControl signalControl{get;set;}
        public bool maintenance {get; set;}
     

        public Actuador (PhysicalQuantity physicalQuantity, string alphaNumericCode,string manufacturerName,CommunicationProtocol protocol,string codeControl, SignalControl signalControl)
        {
            this.physicalQuantity = physicalQuantity;
            this.alphaNumericCode = alphaNumericCode;
            this.manufacturerName = manufacturerName;
            this.protocol = protocol;
            this.codeControl = codeControl;
            this.signalControl = signalControl;
            maintenance = false;
        }
    } 

    public class Calibraciones
    {
        public string dateCalibration {get;set;}
        public string nameTechnician {get; set;}
        public string nameCertificateAuthority {get; set;}
        public List<Sensor> calibratedSensors{get;set;}

         public Calibraciones(PhysicalQuantity physicalQuantity, string alphaNumericCode,string manufacturerName,CommunicationProtocol protocol,string principelOperation, string dateCalibration, string nameTechnician, string nameCertificateAuthority)
        {
            this.physicalQuantity = physicalQuantity;
            this.alphaNumericCode = alphaNumericCode;
            this.manufacturerName = manufacturerName;
            this.protocol = protocol;
            this.principelOperation = principelOperation;
            this.dateCalibration = dateCalibration;
            this.nameTechnician = nameTechnician;
            this.nameCertificateAuthority = nameCertificateAuthority;
            calibrated = false;
        }
        
        public Calibraciones()
        {
            calibratedSensors = Main.sensors.Where((x) => x.calibrated).ToList();
        }

        
    }

     public class Maintenance
    {
        public string codeControl {get;set;} 
        public CommunicationProtocol protocol{get;set;}
        public SignalControl signalControl{get;set;}

        public TypeMaintenance typeMaintenance{get; set;}
        public string dateMaintenance{get; set;}
        public string nameTechnician{get; set;}
        public List<Actuador> maintenanceActuador {get;set;}  
       
        public Maintenance (PhysicalQuantity physicalQuantity, string alphaNumericCode,string manufacturerName,CommunicationProtocol protocol,string codeControl, SignalControl signalControl, TypeMaintenance typeMaintenance, string dateMaintenance, string nameTechnician)
        {
            this.physicalQuantity = physicalQuantity;
            this.alphaNumericCode = alphaNumericCode;
            this.manufacturerName = manufacturerName;
            this.protocol = protocol;
            this.codeControl = codeControl;
            this.signalControl = signalControl;
            this.typeMaintenance = typeMaintenance;
            this.dateMaintenance = dateMaintenance;
            this.nameTechnician = nameTechnician;
            maintenance = false;
        }
         public Maintenance()
        {
            maintenanceActuador = Main.actuadores.Where((x) => x.maintenance).ToList();
        }

    } 

    public static class Main
    {
        public static List<Sensor> sensors{get;set;}
    }

