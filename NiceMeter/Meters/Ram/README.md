# `NiceMeter.Meters.Mainboard`
Map RAM and its values to the internal objects used to display our meters.

Sesors for the mainboard are provided by the sub hardware chip.

Source data example:
```
+- ASUS ROG CROSSHAIR VIII IMPACT (/mainboard)
|  |
|  +- Nuvoton NCT6798D (/lpc/nct6798d)
|  |  +- CPU VCore      :    1.336    1.336    1.336 (/lpc/nct6798d/voltage/0)
|  |  +- Voltage #2     :        1        1        1 (/lpc/nct6798d/voltage/1)
|  |  +- AVCC           :    3.424    3.424    3.424 (/lpc/nct6798d/voltage/2)
|  |  +- 3VCC           :     3.36     3.36     3.36 (/lpc/nct6798d/voltage/3)
|  |  +- Voltage #5     :    1.728    1.728    1.728 (/lpc/nct6798d/voltage/4)
|  |  +- Voltage #6     :    0.592    0.592    0.592 (/lpc/nct6798d/voltage/5)
|  |  +- Voltage #7     :     1.08     1.08     1.08 (/lpc/nct6798d/voltage/6)
|  |  +- 3VSB           :    3.424    3.424    3.424 (/lpc/nct6798d/voltage/7)
|  |  +- VBAT           :    3.296    3.296    3.296 (/lpc/nct6798d/voltage/8)
|  |  +- VTT            :    0.912    0.912    0.912 (/lpc/nct6798d/voltage/9)
|  |  +- Voltage #12    :    0.088    0.088    0.088 (/lpc/nct6798d/voltage/11)
|  |  +- Voltage #13    :    1.016    1.016    1.016 (/lpc/nct6798d/voltage/12)
|  |  +- Voltage #14    :    1.376    1.376    1.376 (/lpc/nct6798d/voltage/13)
|  |  +- Voltage #15    :    0.912    0.912    0.912 (/lpc/nct6798d/voltage/14)
|  |  +- Temperature #1 :     38.5     38.5     38.5 (/lpc/nct6798d/temperature/1)
|  |  +- Temperature #2 :       36       36       36 (/lpc/nct6798d/temperature/2)
|  |  +- Temperature #3 :       22       22       22 (/lpc/nct6798d/temperature/3)
|  |  +- Temperature #5 :      103      103      103 (/lpc/nct6798d/temperature/5)
|  |  +- Temperature #6 :       31       31       31 (/lpc/nct6798d/temperature/6)
|  |  +- Fan #2         :  908.479  908.479  908.479 (/lpc/nct6798d/fan/1)
|  |  +- Fan #6         :  2636.72  2636.72  2636.72 (/lpc/nct6798d/fan/5)
|  |  +- Fan Control #1 :  27.8431  27.8431  27.8431 (/lpc/nct6798d/control/0)
|  |  +- Fan Control #2 :  38.4314  38.4314  38.4314 (/lpc/nct6798d/control/1)
|  |  +- Fan Control #3 :  68.6275  68.6275  68.6275 (/lpc/nct6798d/control/2)
|  |  +- Fan Control #4 :       60       60       60 (/lpc/nct6798d/control/3)
|  |  +- Fan Control #5 :       60       60       60 (/lpc/nct6798d/control/4)
|  |  +- Fan Control #6 :      100      100      100 (/lpc/nct6798d/control/5)
|  |  +- Fan Control #7 :      100      100      100 (/lpc/nct6798d/control/6)
```
