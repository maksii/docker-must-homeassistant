﻿using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Models
{
    /// <summary>
    /// The sensor definitions of the PH1800 series of inverters manufactured by Must Solar.
    /// </summary>
    public class Ph1800Reference
    {
        [ModbusSensor(20000, 1.0, true)]
        public short? MachineTypeH { get; set; }

        [ModbusSensor(20001, 1.0, true)]
        public short? MachineTypeL { get; set; }

        [ModbusSensor(20002, 1.0, true)]
        public short? SerialNumberH { get; set; }

        [ModbusSensor(20003, 1.0, true)]
        public short? SerialNumberL { get; set; }
            
        [ModbusSensor(20004, 1.0, true)]
        public short? HardwareNo { get; set; }

        [ModbusSensor(20005, 1.0, true)]
        public short? SoftwareNo { get; set; }

        [ModbusSensor(20006, 1.0, true)]
        public short? ProtocalEditionNo { get; set; }

        [ModbusSensor(20009, 1.0, true)]
        public short? BatteryVoltageC { get; set; }

        [ModbusSensor(20010, 1.0, true)]
        public short? InverterVoltageC { get; set; }

        [ModbusSensor(20011, 1.0, true)]
        public short? GridVoltageC { get; set; }

        [ModbusSensor(20012, 1.0, true)]
        public short? BusVoltageC { get; set; }

        [ModbusSensor(20013, 1.0, true)]
        public short? ControlCurrentC { get; set; }

        [ModbusSensor(20014, 1.0, true)]
        public short? InverterCurrentC { get; set; }

        [ModbusSensor(20015, 1.0, true)]
        public short? GridCurrentC { get; set; }

        [ModbusSensor(20016, 1.0, true)]
        public short? LoadCurrentC { get; set; }

        [ModbusSensor(20101, 1.0, true)]
        public short? InverterOffgridWorkEnable { get; set; }

        [ModbusSensor(20102, 0.1, true)]
        public double? InverterOutputVoltageSet { get; set; }

        [ModbusSensor(20103, 0.01, true)]
        public double? InverterOutputFrequencySet { get; set; }

        [ModbusSensor(20104, 1.0, true)]
        public short? InverterSearchModeEnable { get; set; }

        [ModbusSensor(20108, 1.0, true)]
        public short? InverterDischargerToGridEnable { get; set; }

        [ModbusSensor(20109, 1.0, true)]
        [SensorLookup(new string[]
            {
              "",
              "SBU",
              "SUB",
              "UTI",
              "SOL"
            }
        )]
        [SensorRemarks(
@"
SBU
Solar energy provides power to the
loads as first priority, If solar energy is
not sufficient to power all connected
loads, battery energy will supply power
to the loads at the same time. Utility
provides power to the loads only when
battery voltage drops to either low-level
warning voltage or the setting point in
program 20 or solar and battery is not
sufficient. The battery energy will supply
power to the load in the condition of the
utility is unavailable or the battery
voltage is higher than the setting point
in program 21 (when BLU is selected) or
program 20 (when LBU is selected). If
the solar is available, but the voltage is
lower than the setting point in program
20, the utility will charge the battery
until the battery voltage reaches the
setting point in program 20 to protect
the battery from damage.

SUB
Solar energy provides power to the
loads as first priority, If solar energy is
not sufficient to power all connected
loads, Utility energy will supply power
to the loads at the same time. The
battery energy will supply power to the
load only in the condition of the utility is
unavailable. If the solar is unavailable,
the utility will charge the battery until
the battery voltage reaches the setting
point in program 21.If the solar is
available, but the voltage is lower than
the setting point in program 20, the
utility will charge the battery until the
battery voltage reaches the setting
point in program 20 to protect the
battery from damage.

UTI
Utility will provide power to the loads
as first priority. Solar and battery energy
will provide power to the loads only
when utility power is not available.

SOL
Solar energy provides power to the
loads as first priority.
If battery voltage has been higher than
the setting point in program 21 for 5
minutes, and the solar energy has been
available for 5 minutes too, the inverter
will turn to battery mode, solar and
battery will provide power to the loads
at the same time.
When the battery voltage drops to the
setting point in program 20, the inverter
will turn to bypass mode, utility provides
power to the load only, and the solar will
charge the battery at the same time.
"
        )]
        public short? EnergyUseMode { get; set; }

        [ModbusSensor(20111, 1.0, true)]
        public short? GridProtectStandard { get; set; }

        [ModbusSensor(20112, 1.0, true)]
        [SensorLookup(new string[2]
            {
              "LBU",
              "BLU"
            }
        )]
        [SensorRemarks(
@"
LBU
Solar energy provides power to
the loads as first priority

BLU
Solar energy provides power to
charge battery as first priority
"            
        )]
        public short? SolarUseAim { get; set; }

        [ModbusSensor(20113, 0.1, true)]
        public double? InverterMaxDischargerCurrent { get; set; }

        [ModbusSensor(20118, 0.1, true)]
        public double? BatteryStopDischargingVoltage { get; set; }

        [ModbusSensor(20119, 0.1, true)]
        public double? BatteryStopChargingVoltage { get; set; }

        [ModbusSensor(20125, 0.1, true)]
        public double? GridMaxChargerCurrentSet { get; set; }

        [ModbusSensor(20127, 0.1, true)]
        public double? BatteryLowVoltage { get; set; }

        [ModbusSensor(20128, 0.1, true)]
        public double? BatteryHighVoltage { get; set; }

        [ModbusSensor(20132, 0.1, true)]
        public double? MaxCombineChargerCurrent { get; set; }

        [ModbusSensor(20142, 1.0, true)]
        public ushort? SystemSetting { get; set; }

        [ModbusSensor(20143, 1.0, true)]
        public short? ChargerSourcePriority { get; set; }

        [ModbusSensor(25201, 1.0, true)]
        [SensorInterpretation("state-machine")]
        [SensorLookup(new string[7]
            {
              "PowerOn",
              "SelfTest",
              "OffGrid",
              "Grid-Tie",
              "ByPass",
              "Stop",
              "Grid charging"
            }        
        )]
        [SensorRemarks(
@"
PowerOn
The inverter is powering on.

SelfTest
The inverter is performing a self test.

OffGrid
The inverter will provide output power from battery and PV power.
Inverter power loads from PV energy.
Inverter power loads from battery and PV energy.
Inverter power loads from battery only.

Grid-Tie
PV energy is charger PV is on into the battery and utility provide power to the AC load.
PV is on
PV is off

ByPass
Error are caused by inside circuit error or external reasons such as over temperature, output short circuited and so on.

Stop
The inverter stop working if you turn off the inverter by the soft key or error has occurred in the condition of no grid.

Grid charging
PV energy and grid can charge batteries.
"
        )]

        public short? WorkStateNo { get; set; }

        [ModbusSensor(25202, 1.0, true)]
        [SensorInterpretation("current-ac", "Vac")]
        public short? AcVoltageGrade { get; set;}
    
        [ModbusSensor(25203, 1.0, true)]
        [SensorInterpretation("lightbulb-outline", "VA")]
        public short? RatedPower {get; set;}
    
        [ModbusSensor(25205, 0.1, true)]
        [SensorInterpretation("current-dc", "Vdc-batt")]
        public double? BatteryVoltage {get; set;}
    

        [ModbusSensor(25206, 0.1, true)]
        [SensorInterpretation("current-ac", "Vac")]
        public double? InverterVoltage {get; set;}
    

        [ModbusSensor(25207, 0.1, true)]
        [SensorInterpretation("current-ac", "Vac")]
        public double? GridVoltage {get; set;}
    
        [ModbusSensor(25208, 0.1, true)]
        [SensorInterpretation("cog-transfer-outline", "Vdc/Vac")]
        public double? BusVoltage {get; set;}
    
        [ModbusSensor(25209, 0.1, true)]
        [SensorInterpretation("current-ac", "Aac")]
        public double? ControlCurrent {get; set;}
    
        [ModbusSensor(25210, 0.1, true)]
        [SensorInterpretation("current-ac", "Aac")]
        public double? InverterCurrent {get; set;}
    
        [ModbusSensor(25211, 0.1, true)]
        [SensorInterpretation("current-ac", "Aac")]
        public double? GridCurrent {get; set;}
    
        [ModbusSensor(25212, 0.1, true)]
        [SensorInterpretation("current-ac", "Aac")]
        public double? LoadCurrent {get; set;}
    
        [ModbusSensor(25213, 1.0, true)]
        [SensorInterpretation("cog-transfer-outline", "W")]
        public short? PInverter {get; set;}
    
        [ModbusSensor(25214, 1.0, true)]
        [SensorInterpretation("transmission-tower", "W")]
        public short? PGrid {get; set;}
    
        [ModbusSensor(25215, 1.0, true)]
        [SensorInterpretation("lightbulb-on-outline", "W")]
        public short? PLoad {get; set;}
    

        [ModbusSensor(25216, 1.0, true)]
        [SensorInterpretation("progress-download", "%")]
        public short? LoadPercent {get; set;}
    
        [ModbusSensor(25217, 1.0, true)]
        [SensorInterpretation("cog-transfer-outline", "VA")]
        public short? SInverter {get; set;}
    
        [ModbusSensor(25218, 1.0, true)]
        [SensorInterpretation("transmission-tower", "VA")]
        public short? SGrid {get; set;}

        [ModbusSensor(25219, 1.0, true)]
        [SensorInterpretation("lightbulb-on-outline", "VA")]
        public short? SLoad {get; set;}
    
        [ModbusSensor(25221, 1.0, true)]
        [SensorInterpretation("cog-transfer-outline", "Var")]
        public short? QInverter { get; set; }

        [ModbusSensor(25222, 1.0, true)]
        [SensorInterpretation("transmission-tower", "Var")]
        public short? QGrid {get; set;}
    
        [ModbusSensor(25223, 1.0, true)]
        [SensorInterpretation("lightbulb-on-outline", "Var")]
        public short? QLoad {get; set;}
    
        [ModbusSensor(25225, 0.01, true)]
        [SensorInterpretation("sine-wave", "Hz")]
        public double? InverterFrequency {get; set;}

        [ModbusSensor(25226, 0.01, true)]
        [SensorInterpretation("sine-wave", "Hz")]
        public double? GridFrequency {get; set;}
    
        [ModbusSensor(25229, 1.0, true)]
        [SensorInterpretation("format-list-numbered")]
        public short? InverterMaxNumber {get; set;}
    
        [ModbusSensor(25230, 1.0, true)]
        [SensorInterpretation("format-list-bulleted-type")]
        public short? CombineType {get; set;}
    
        [ModbusSensor(25231, 1.0, true)]
        [SensorInterpretation("format-list-numbered")]
        public short? InverterNumber {get; set;}
    
        [ModbusSensor(25233, 1.0, true)]
        [SensorInterpretation("thermometer", "oC")]
        public short? AcRadiatorTemp {get; set;}
    
        [ModbusSensor(25234, 1.0, true)]
        [SensorInterpretation("thermometer", "oC")]
        public short? TransformerTemp {get; set;}
    
        [ModbusSensor(25235, 1.0, true)]
        [SensorInterpretation("thermometer", "oC")]
        public short? DcRadiatorTemp {get; set;}
    
        [ModbusSensor(25237, 1.0, true)]
        [SensorInterpretation("electric-switch")]
        public short? InverterRelayStateNo { get; set; }

        [ModbusSensor(25238, 1.0, true)]
        [SensorInterpretation("electric-switch")]
        public short? GridRelayStateNo { get; set; }

        [ModbusSensor(25239, 1.0, true)]
        [SensorInterpretation("electric-switch")]
        public short? LoadRelayStateNo { get; set; }

        [ModbusSensor(25240, 1.0, true)]
        [SensorInterpretation("electric-switch")]
        public short? NLineRelayStateNo { get; set; }

        [ModbusSensor(25241, 1.0, true)]
        [SensorInterpretation("electric-switch")]
        public short? DcRelayStateNo { get; set; }

        [ModbusSensor(25242, 1.0, true)]
        [SensorInterpretation("electric-switch")]
        public short? EarthRelayStateNo { get; set; }

        [ModbusSensor(25245, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-Higth")]
        public short? AccumulatedChargerPowerH { get; set; }

        [ModbusSensor(25246, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-Low")]
        public short? AccumulatedChargerPowerL { get; set; }

        [ModbusSensor(25247, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-High")]
        public short? AccumulatedDischargerPowerH { get; set; }

        [ModbusSensor(25248, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-Low")]
        public short? AccumulatedDischargerPowerL { get; set; }

        [ModbusSensor(25249, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-High")]
        public short? AccumulatedBuyPowerH { get; set; }

        [ModbusSensor(25250, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-Low")]
        public short? AccumulatedBuyPowerL { get; set; }

        [ModbusSensor(25251, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-High")]
        public short? AccumulatedSellPowerH { get; set; }

        [ModbusSensor(25252, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-Low")]
        public short? AccumulatedSellPowerL { get; set; }

        [ModbusSensor(25253, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-High")]
        public short? AccumulatedLoadPowerH { get; set; }

        [ModbusSensor(25254, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-Low")]
        public short? AccumulatedLoadPowerL { get; set; }

        [ModbusSensor(25255, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-High")]
        public short? AccumulatedSelfusePowerH { get; set; }
            
        [ModbusSensor(25256, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-Low")]
        public short? AccumulatedSelfusePowerL { get; set; }

        [ModbusSensor(25257, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-High")]
        public short? AccumulatedPvsellPowerH { get; set; }

        [ModbusSensor(25258, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-Low")]
        public short? AccumulatedPvsellPowerL { get; set; }

        [ModbusSensor(25259, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-High")]
        public short? AccumulatedGridChargerPowerH { get; set; }

        [ModbusSensor(25260, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-Low")]
        public short? AccumulatedGridChargerPowerL { get; set; }

        [ModbusSensor(25261, 1.0, true)]
        [SensorInterpretation("alert-circle-outline")]
        public short? Error1 { get; set; }

        [ModbusSensor(25262, 1.0, true)]
        [SensorInterpretation("alert-circle-outline")]
        public short? Error2 { get; set; }

        [ModbusSensor(25263, 1.0, true)]
        [SensorInterpretation("alert-circle-outline")]
        public short? Error3 { get; set; }

        [ModbusSensor(25265, 1.0, true)]
        [SensorInterpretation("alert-outline")]
        public short? Warning1 { get; set; }

        [ModbusSensor(25266, 1.0, true)]
        [SensorInterpretation("alert-outline")]
        public short? Warning2 { get; set; }

        [ModbusSensor(25273, 1.0, true)]
        [SensorInterpretation("car-battery", "W")]
        public short? BattPower {get; set;}

        [ModbusSensor(25274, 1.0, true)]
        [SensorInterpretation("current-dc", "Adc-batt")]
        public short? BattCurrent {get; set;}

        [ModbusSensor(25275, 1.0, true)]
        [SensorInterpretation("current-dc", "Vdc-batt")]
        public short? BattVoltageGrade {get; set;}
    
        [ModbusSensor(25277, 1.0, true)]
        [SensorInterpretation("certificate", "W")]
        public short? RatedPowerW {get; set;}
    
        [ModbusSensor(25278, 1.0, true)]
        [SensorInterpretation("barcode")]
        public short? CommunicationProtocalEdition {get; set;}
    
        [ModbusSensor(25279, 1.0, true)]
        [SensorInterpretation("state-machine")]
        public short? ArrowFlag { get; set; }

        [ModbusSensor(10001, 1.0, true)]
        public short? ChrMachineType { get; set; }

        [ModbusSensor(10002, 1.0, true)]
        public short? ChrSerialNumberH { get; set; }

        [ModbusSensor(10003, 1.0, true)]
        public short? ChrSerialNumberL { get; set; }

        [ModbusSensor(10004, 1.0, true)]
        public short? ChrHardwareNo { get; set; }

        [ModbusSensor(10005, 1.0, true)]
        public short? ChrSoftwareNo { get; set; }

        [ModbusSensor(10006, 1.0, true)]
        public short? PvVoltageC { get; set; }

        [ModbusSensor(10007, 1.0, true)]
        public short? ChrBatteryVoltageC { get; set; }

        [ModbusSensor(10008, 1.0, true)]
        public short? ChargerCurrentC { get; set; }

        [ModbusSensor(10103, 0.1, true)]
        public double? FloatVoltage { get; set; }

        [ModbusSensor(10104, 0.1, true)]
        public double? AbsorptionVoltage { get; set; }

        [ModbusSensor(10105, 0.1, true)]
        public double? ChrBatteryLowVoltage { get; set; }

        [ModbusSensor(10108, 0.1, true)]
        public double? MaxChargerCurrent { get; set; }

        [ModbusSensor(10110, 1.0, true)]
        public short? BatteryType { get; set; }

        [ModbusSensor(10111, 1.0, true)]
        public short? BatteryAh { get; set; }

        [ModbusSensor(15201, 1.0, true)]
        [SensorInterpretation("state-machine")]
        public short? ChrWorkstateNo { get; set; }

        [ModbusSensor(15202, 1.0, true)]
        [SensorInterpretation("electric-switch")]
        public short? MpptStateNo { get; set; }

        [ModbusSensor(15203, 1.0, true)]
        [SensorInterpretation("electric-switch")]
        public short? ChargingStateNo { get; set; }

        [ModbusSensor(15205, 0.1, true)]
        [SensorInterpretation("current-dc", "Vdc-pv")]
        public double? PvVoltage {get; set;}

        [ModbusSensor(15206, 0.1, true)]
        [SensorInterpretation("current-dc", "Vdc-batt")]
        public double? ChrBatteryVoltage {get; set;}
    
        [ModbusSensor(15207, 0.1, true)]
        [SensorInterpretation("current-dc", "Adc-charger")]
        public double? ChargerCurrent {get; set;}
    
        [ModbusSensor(15208, 1.0, true)]
        [SensorInterpretation("car-turbopower", "W")]
        public short? ChargerPower {get; set;}
    
        [ModbusSensor(15209, 1.0, true)]
        [SensorInterpretation("thermometer", "oC")]
        public short? RadiatorTemp {get; set;}
    
        [ModbusSensor(15210, 1.0, true )]
        [SensorInterpretation("thermometer", "oC")]
        public short? ExternalTemp {get; set;}

        [ModbusSensor(15211, 1.0, true)]
        [SensorInterpretation("electric-switch")]
        public short? BatteryRelayNo { get; set; }

        [ModbusSensor(15212, 1.0, true)]
        [SensorInterpretation("electric-switch")]
        public short? PvRelayNo { get; set; }

        [ModbusSensor(15213, 1.0, true)]
        [SensorInterpretation("alert-circle-outline")]
        public short? ChrError1 { get; set; }

        [ModbusSensor(15214, 1.0, true)]
        [SensorInterpretation("alert-outline")]
        public short? ChrWarning1 { get; set; }

        [ModbusSensor(15215, 1.0, true)]
        [SensorInterpretation("current-dc", "Vdc-batt")]
        public short? BattVolGrade { get; set;}
    
        [ModbusSensor(15216, 0.1, true)]
        [SensorInterpretation("current-dc", "Adc-charger")]
        public double? RatedCurrent {get; set;}

        [ModbusSensor(15217, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-High")]
        public short? AccumulatedPvPowerH { get; set; }

        [ModbusSensor(15218, 1.0, true)]
        [SensorInterpretation("chart-bell-curve-cumulative", "W-Low")]
        public short? AccumulatedPvPowerL { get; set; }

        [ModbusSensor(15219, 1.0, true)]
        [SensorInterpretation("calendar-day", "day")]
        public short? AccumulatedDay { get; set; }

        [ModbusSensor(15220, 1.0, true)]
        [SensorInterpretation("clock-outline", "hour")]
        public short? AccumulatedHour { get; set; }

        [ModbusSensor(15221, 1.0, true)]
        [SensorInterpretation("timer-outline", "min")]
        public short? AccumulatedMinute { get; set; }
    }
}