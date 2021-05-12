# `NiceMeter.Meters.Gpu`
Map GPU hardware and its sensors to the internal objects used to display our meters.

Source data example:
```
+- NVIDIA NVIDIA GeForce GTX 1050 Ti (/nvidiagpu/0)
|  +- GPU Core       :      139      139      139 (/nvidiagpu/0/clock/0)
|  +- GPU Memory     :      405      405      405 (/nvidiagpu/0/clock/1)
|  +- GPU Shader     :      278      278      278 (/nvidiagpu/0/clock/2)
|  +- GPU Core       :       33       33       33 (/nvidiagpu/0/temperature/0)
|  +- GPU Core       :        2        2        7 (/nvidiagpu/0/load/0)
|  +- GPU Frame Buffer :        5        5        5 (/nvidiagpu/0/load/1)
|  +- GPU Video Engine :        0        0        0 (/nvidiagpu/0/load/2)
|  +- GPU Bus Interface :        2        2        2 (/nvidiagpu/0/load/3)
|  +- GPU Memory     :  12.2703  12.2703  12.2703 (/nvidiagpu/0/load/4)
|  +- GPU            :        0        0        0 (/nvidiagpu/0/fan/0)
|  +- GPU Fan        :        0        0        0 (/nvidiagpu/0/control/0)
|  +- GPU Memory Free :  3593.41  3593.41  3593.41 (/nvidiagpu/0/smalldata/1)
|  +- GPU Memory Used :   502.59   502.59   502.59 (/nvidiagpu/0/smalldata/2)
|  +- GPU Memory Total :     4096     4096     4096 (/nvidiagpu/0/smalldata/3)
```
