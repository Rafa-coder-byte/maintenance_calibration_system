 public class Maintenance
    {
        public string codeControl {get;set;} 
        public CommunicationProtocol protocol{get;set;}
        public SignalControl signalControl{get;set;}

        public TypeMaintenance typeMaintenance{get; set;}
        public string dateMaintenance{get; set;}
        public string nameTechnician{get; set;}
        public List<Actuador> maintenanceActuador {get;set;}  
       
        public Maintenance (PhysicalMagnitude physicalMagnitude, string alphaNumericCode,string manufacturerName,CommunicationProtocol protocol,string codeControl, SignalControl signalControl, TypeMaintenance typeMaintenance, string dateMaintenance, string nameTechnician)
        {
            this.physicalMagnitude = physicalMagnitude;
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
         /*Ver el llenado de la lista*/
         public Maintenance()
        {
            maintenanceActuador = Main.actuadores.Where((x) => x.maintenance).ToList();
        }

    } 