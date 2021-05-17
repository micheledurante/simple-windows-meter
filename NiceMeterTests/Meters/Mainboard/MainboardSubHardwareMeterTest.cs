using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NiceMeter.Meters.Mainboard;
using NiceMeter.Meters.Units;
using OpenHardwareMonitor.Hardware;
using System.Linq;

namespace NiceMeterTests.Meters.Mainboard
{
    [TestClass]
    public class MainboardSubHardwareMeterTest
    {
        [TestMethod]
        public void Ctor_ProvidedBaseCtorParameters_ShoulSetBaseCtorParameters()
        {
            var name = new Faker().Random.Word();

            var mainboardSubHardwareMeter = new MainboardSubHardwareMeter(name, new Mock<MainboardConfig>().Object);

            Assert.AreEqual(name, mainboardSubHardwareMeter.Name);
            Assert.AreEqual(HardwareType.SuperIO, mainboardSubHardwareMeter.HardwareType);
        }

        [TestMethod]
        public void Ctor_AllFalseConfig_UnitsListShouldBeEmpty()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardSubHardwareMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);

            Assert.AreEqual(false, mainboardSubHardwareMeter.Units.Any());
        }

        [TestMethod]
        public void Ctor_NoConfigRequired_UnitOHNamesAreSetFromConsts()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardSubHardwareMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);

            Assert.AreEqual(mainboardSubHardwareMeter.CpuVCore.OHName, MainboardSubHardwareMeter.MAINBOARD_CPU_V_CORE_OHNAME);
            Assert.AreEqual(mainboardSubHardwareMeter.CpuSoc.OHName, MainboardSubHardwareMeter.MAINBOARD_CPU_SOC_OHNAME);
            Assert.AreEqual(mainboardSubHardwareMeter.DRam.OHName, MainboardSubHardwareMeter.MAINBOARD_D_RAM_OHNAME);
            Assert.AreEqual(mainboardSubHardwareMeter.Vrm.OHName, MainboardSubHardwareMeter.MAINBOARD_VRM_OHNAME);
            Assert.AreEqual(mainboardSubHardwareMeter.TSensor.OHName, MainboardSubHardwareMeter.MAINBOARD_T_SENSOR_OHNAME);
            Assert.AreEqual(mainboardSubHardwareMeter.CpuFan.OHName, MainboardSubHardwareMeter.MAINBOARD_CPU_FAN_OHNAME);
            Assert.AreEqual(mainboardSubHardwareMeter.WPump.OHName, MainboardSubHardwareMeter.MAINBOARD_W_PUMP_OHNAME);
        }


        [TestMethod]
        public void Ctor_MainboardCpuVCoreEnbaled_ShoulAddMainboardCpuVCoreUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = true,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(VoltUnit));
        }

        [TestMethod]
        public void Ctor_MainboardCpuSocEnbaled_ShoulAddMainboardCpuSocUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = true,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(VoltUnit));
        }

        [TestMethod]
        public void Ctor_MainboardDRamEnbaled_ShoulAddMainboardDRamUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = true,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(VoltUnit));
        }

        [TestMethod]
        public void Ctor_MainboardVrm_ShoulAddMainboardVrmUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = true,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(TempUnit));
        }

        [TestMethod]
        public void Ctor_MainboardTSensor_ShoulAddMainboardTSensorUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = true,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(TempUnit));
        }

        [TestMethod]
        public void Ctor_MainboardCpuFan_ShoulAddMainboardCpuFanUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = true,
                MainboardWPump = false
            };

            var mainboardMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(RpmUnit));
        }

        [TestMethod]
        public void Ctor_MainboardWPump_ShoulAddMainboardWPumpUnitToUnitsList()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = true
            };

            var mainboardMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);

            Assert.AreEqual(1, mainboardMeter.Units.Count);
            Assert.IsInstanceOfType(mainboardMeter.Units.First(), typeof(RpmUnit));
        }

        [TestMethod]
        public void UpdateMeters_NoMeters_ShoulSetMeterTextToNull()
        {
            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardSubHardwareMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);
            mainboardSubHardwareMeter.UpdateMeters(new Mock<IHardware>().Object);

            Assert.IsNull(mainboardSubHardwareMeter.Text);
        }

        [TestMethod]
        public void ReadSensors_CpuVCoreEnabled_ShouldSetValueForCpuVCore()
        {
            var cpuVCoreSensorValue = new Faker().Random.Number();
            var cpuVCoreSensorMock = new Mock<ISensor>();
            cpuVCoreSensorMock.SetupGet(x => x.Name).Returns(MainboardSubHardwareMeter.MAINBOARD_CPU_V_CORE_OHNAME);
            cpuVCoreSensorMock.SetupGet(x => x.Value).Returns(cpuVCoreSensorValue);
            var sensors = new ISensor[1];
            sensors[0] = cpuVCoreSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = true,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardSubHardwareMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);
            mainboardSubHardwareMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            cpuVCoreSensorMock.VerifyGet(x => x.Value, Times.Once);
            Assert.AreEqual(cpuVCoreSensorValue, mainboardSubHardwareMeter.CpuVCore.Value);
        }

        [TestMethod]
        public void ReadSensors_CpuSocEnabled_ShouldSetValueForCpuSoc()
        {
            var cpuSocSensorValue = new Faker().Random.Number();
            var cpuSocSensorMock = new Mock<ISensor>();
            cpuSocSensorMock.SetupGet(x => x.Name).Returns(MainboardSubHardwareMeter.MAINBOARD_CPU_SOC_OHNAME);
            cpuSocSensorMock.SetupGet(x => x.Value).Returns(cpuSocSensorValue);
            var sensors = new ISensor[1];
            sensors[0] = cpuSocSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = true,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardSubHardwareMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);
            mainboardSubHardwareMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            cpuSocSensorMock.VerifyGet(x => x.Value, Times.Once);
            Assert.AreEqual(cpuSocSensorValue, mainboardSubHardwareMeter.CpuSoc.Value);
        }

        [TestMethod]
        public void ReadSensors_DRamEnabled_ShouldSetValueForDRam()
        {
            var dRamSensorValue = new Faker().Random.Number();
            var dRamSensorMock = new Mock<ISensor>();
            dRamSensorMock.SetupGet(x => x.Name).Returns(MainboardSubHardwareMeter.MAINBOARD_D_RAM_OHNAME);
            dRamSensorMock.SetupGet(x => x.Value).Returns(dRamSensorValue);
            var sensors = new ISensor[1];
            sensors[0] = dRamSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = true,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardSubHardwareMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);
            mainboardSubHardwareMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            dRamSensorMock.VerifyGet(x => x.Value, Times.Once);
            Assert.AreEqual(dRamSensorValue, mainboardSubHardwareMeter.DRam.Value);
        }

        [TestMethod]
        public void ReadSensors_VRamEnabled_ShouldSetValueForVRam()
        {
            var vrmSensorValue = new Faker().Random.Number();
            var vrmSensorMock = new Mock<ISensor>();
            vrmSensorMock.SetupGet(x => x.Name).Returns(MainboardSubHardwareMeter.MAINBOARD_VRM_OHNAME);
            vrmSensorMock.SetupGet(x => x.Value).Returns(vrmSensorValue);
            var sensors = new ISensor[1];
            sensors[0] = vrmSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = true,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardSubHardwareMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);
            mainboardSubHardwareMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            vrmSensorMock.VerifyGet(x => x.Value, Times.Once);
            Assert.AreEqual(vrmSensorValue, mainboardSubHardwareMeter.Vrm.Value);
        }

        [TestMethod]
        public void ReadSensors_TSensorEnabled_ShouldSetValueForTSensor()
        {
            var tSensorSensorValue = new Faker().Random.Number();
            var tSensorSensorMock = new Mock<ISensor>();
            tSensorSensorMock.SetupGet(x => x.Name).Returns(MainboardSubHardwareMeter.MAINBOARD_T_SENSOR_OHNAME);
            tSensorSensorMock.SetupGet(x => x.Value).Returns(tSensorSensorValue);
            var sensors = new ISensor[1];
            sensors[0] = tSensorSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = true,
                MainboardCpuFan = false,
                MainboardWPump = false
            };

            var mainboardSubHardwareMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);
            mainboardSubHardwareMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            tSensorSensorMock.VerifyGet(x => x.Value, Times.Once);
            Assert.AreEqual(tSensorSensorValue, mainboardSubHardwareMeter.TSensor.Value);
        }

        [TestMethod]
        public void ReadSensors_CpuFanEnabled_ShouldSetValueForCpuFan()
        {
            var cpuFanSensorValue = new Faker().Random.Number();
            var cpuFanSensorMock = new Mock<ISensor>();
            cpuFanSensorMock.SetupGet(x => x.Name).Returns(MainboardSubHardwareMeter.MAINBOARD_CPU_FAN_OHNAME);
            cpuFanSensorMock.SetupGet(x => x.Value).Returns(cpuFanSensorValue);
            var sensors = new ISensor[1];
            sensors[0] = cpuFanSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = true,
                MainboardWPump = false
            };

            var mainboardSubHardwareMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);
            mainboardSubHardwareMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            cpuFanSensorMock.VerifyGet(x => x.Value, Times.Once);
            Assert.AreEqual(cpuFanSensorValue, mainboardSubHardwareMeter.CpuFan.Value);
        }

        [TestMethod]
        public void ReadSensors_WPumpEnabled_ShouldSetValueForWPump()
        {
            var WPumpSensorValue = new Faker().Random.Number();
            var WPumpSensorMock = new Mock<ISensor>();
            WPumpSensorMock.SetupGet(x => x.Name).Returns(MainboardSubHardwareMeter.MAINBOARD_W_PUMP_OHNAME);
            WPumpSensorMock.SetupGet(x => x.Value).Returns(WPumpSensorValue);
            var sensors = new ISensor[1];
            sensors[0] = WPumpSensorMock.Object;
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(x => x.Sensors).Returns(sensors);

            var mainboardConfig = new MainboardConfig
            {
                MainboardCpuVCore = false,
                MainboardCpuSoc = false,
                MainboardDRam = false,
                MainboardVrm = false,
                MainboardTSensor = false,
                MainboardCpuFan = false,
                MainboardWPump = true
            };

            var mainboardSubHardwareMeter = new MainboardSubHardwareMeter(new Faker().Random.Word(), mainboardConfig);
            mainboardSubHardwareMeter.ReadSensors(hardwareMock.Object);

            hardwareMock.VerifyGet(x => x.Sensors, Times.Once);
            WPumpSensorMock.VerifyGet(x => x.Value, Times.Once);
            Assert.AreEqual(WPumpSensorValue, mainboardSubHardwareMeter.WPump.Value);
        }
    }
}
