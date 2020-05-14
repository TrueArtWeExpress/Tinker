/**
 * Marlin 3D Printer Firmware
 * Copyright (c) 2019 MarlinFirmware [https://github.com/MarlinFirmware/Marlin]
 *
 * Based on Sprinter and grbl.
 * Copyright (c) 2011 Camiel Gubbels / Erik van der Zalm
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 */

#include "../../inc/MarlinConfig.h"

#if ENABLED(BABYSTEPPING)

#include "../gcode.h"
#include "../../feature/babystep.h"
#include "../../module/probe.h"
#include "../../module/temperature.h"
#include "../../module/planner.h"

#if ENABLED(BABYSTEP_ZPROBE_OFFSET)
  #include "../../core/serial.h"
#endif

#if ENABLED(BABYSTEP_ZPROBE_OFFSET)

  FORCE_INLINE void mod_zprobe_zoffset(const float &offs) {
    if (true
      #if ENABLED(BABYSTEP_HOTEND_Z_OFFSET)
        && active_extruder == 0
      #endif
    ) {
      probe_offset[Z_AXIS] += offs;
      SERIAL_ECHO_START();
      SERIAL_ECHOLNPAIR(MSG_PROBE_OFFSET MSG_Z ": ", probe_offset[Z_AXIS]);
    }
    #if ENABLED(BABYSTEP_HOTEND_Z_OFFSET)
      else {
        hotend_offset[Z_AXIS][active_extruder] -= offs;
        SERIAL_ECHO_START();
        SERIAL_ECHOLNPAIR(MSG_Z_OFFSET ": ", hotend_offset[Z_AXIS][active_extruder]);
      }
    #endif
  }

#endif

/**
 * M290: Babystepping
 *
 *  X<linear> - Distance to step X
 *  Y<linear> - Distance to step Y
 *  Z<linear> - Distance to step Z
 *  S<linear> - Distance to step Z (alias for Z)
 *
 * With BABYSTEP_ZPROBE_OFFSET:
 *         P0 - Don't adjust the Z probe offset.
 */
void GcodeSuite::M290() {
  #if ENABLED(BABYSTEP_XY)
    for (uint8_t a = X_AXIS; a <= Z_AXIS; a++)
      if (parser.seenval(axis_codes[a]) || (a == Z_AXIS && parser.seenval('S'))) {
        const float offs = constrain(parser.value_axis_units((AxisEnum)a), -2, 2);
        babystep.add_mm((AxisEnum)a, offs);
        #if ENABLED(BABYSTEP_ZPROBE_OFFSET)
          if (a == Z_AXIS && (!parser.seen('P') || parser.value_bool())) mod_zprobe_zoffset(offs);
        #endif
      }
  #else
    if (parser.seenval('Z') || parser.seenval('S')) {
      const float offs = constrain(parser.value_axis_units(Z_AXIS), -2, 2);
      babystep.add_mm(Z_AXIS, offs);
      #if ENABLED(BABYSTEP_ZPROBE_OFFSET)
        if (!parser.seen('P') || parser.value_bool()) mod_zprobe_zoffset(offs);
      #endif
    }
  #endif
}

#endif // BABYSTEPPING
