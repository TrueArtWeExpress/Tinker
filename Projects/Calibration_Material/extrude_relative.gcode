M302 S0    					; Allow extrusion at any temperature
G28									;Home
G92 E0							;zero extruder length
G1 F200 E100				;extrude 100mm
G92 E0							;zero extruder after prime
M117 Rock & Roll!		;message to display
