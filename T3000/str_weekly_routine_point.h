#pragma once
#include <stdint.h>

typedef struct {
public:
	byte number;
	byte point_type;
	byte panel;
}Point_T3000;

typedef struct
{
	char description[21];		     /* (21 bytes; string)*/
	char label[9];		      	     /*	(9 bytes; string)*/

	uint8_t value;  /* (1 bit; 0=off, 1=on)*/
	uint8_t auto_manual;  /* (1 bit; 0=auto, 1=manual)*/
	uint8_t override_1_value;  /* (1 bit; 0=off, 1=on)*/
	uint8_t override_2_value;  /* (1 bit; 0=off, 1=on)*/
	uint8_t off;
	uint8_t unused; /* (11 bits)*/

	Point_T3000 override_1;	     /* (3 bytes; point)*/
	Point_T3000 override_2;	     /* (3 bytes; point)*/

} Str_weekly_routine_point; /* 21+9+2+3+3 = 38*/