#include <Arduino.h>

int LED = 8;

void setup()
{
	pinMode(LED,OUTPUT);
}

void loop()
{
	digitalWrite(LED,HIGH);
}
