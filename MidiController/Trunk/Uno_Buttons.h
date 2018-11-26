#include <FastLED.h>
#define NUM_LEDS 1
#define PIN_0 16 //A2
#define PIN_1 17 //A3
#define PIN_2 2
#define PIN_3 3
#define PIN_4 4
#define PIN_5 5
#define PIN_6 6
#define PIN_7 7
#define PIN_8 8
#define PIN_9 9
#define PIN_10 10 
#define PIN_11 11
#define PIN_12 12
#define PIN_13 13
#define PIN_14 14 //A0
#define PIN_15 15 //A1


// Placing below array's in a new array makes all leds accessible in functions
CRGB led1[NUM_LEDS];
CRGB led2[NUM_LEDS];
CRGB led3[NUM_LEDS];
CRGB led4[NUM_LEDS];
CRGB led5[NUM_LEDS];
CRGB led6[NUM_LEDS];
CRGB led7[NUM_LEDS];
CRGB led8[NUM_LEDS];
CRGB led9[NUM_LEDS];
CRGB led10[NUM_LEDS];
CRGB led11[NUM_LEDS];
CRGB led12[NUM_LEDS];
CRGB led13[NUM_LEDS];
CRGB led14[NUM_LEDS];
CRGB led15[NUM_LEDS];
CRGB led16[NUM_LEDS];

// variable for commands
char mystr[5]; //Initialized variable to store recieved data

// Runs ones
void setup() {
  // reading commands 
  Serial.begin(9600);
  
  FastLED.addLeds<NEOPIXEL, PIN_0>(led1, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_1>(led2, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_2>(led3, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_3>(led4, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_4>(led5, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_5>(led6, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_6>(led7, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_7>(led8, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_8>(led9, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_9>(led10, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_10>(led11, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_11>(led12, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_12>(led13, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_13>(led14, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_14>(led15, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, PIN_15>(led16, NUM_LEDS);
  
}

// Runs in loop
void loop() {

  Serial.readBytes(mystr,5); //Read the serial data and store in var

  Serial.print(mystr);
  
  if(mystr == '00000') {
    ledSnake(50, 100, 150);
    ledAllOff();
  }
}

// LED functions

// V1 - V2 - V3 - V4  // Vertical lines

// 13 - 14 - 15 - 16  // Horizontal 4
// 09 - 10 - 11 - 12  // Horizontal 3
// 05 - 06 - 07 - 08  // Horizontal 2
// 01 - 02 - 03 - 04  // Horizontal 1 


//void ledLine(int x, int r, int g, int b){
//  switch(x){
//  
//    // Horizontal 1
//    case 1 :
//      CRGB led1[NUM_LEDS];
//      CRGB led2[NUM_LEDS];
//      CRGB led3[NUM_LEDS];
//      CRGB led4[NUM_LEDS];
//    break;
//    
//    // Horizontal 2
//    case 2 :
//      CRGB led5[NUM_LEDS];
//      CRGB led6[NUM_LEDS];
//      CRGB led7[NUM_LEDS];
//      CRGB led8[NUM_LEDS];
//    break;
//    
//    // Horizontal 3
//    case 3 :
//      CRGB led9[NUM_LEDS];
//      CRGB led10[NUM_LEDS];
//      CRGB led11[NUM_LEDS];
//      CRGB led12[NUM_LEDS];
//    break;
//    
//    // Horizontal 4
//    case 4 :
//      CRGB led13[NUM_LEDS];
//      CRGB led14[NUM_LEDS];
//      CRGB led15[NUM_LEDS];
//      CRGB led16[NUM_LEDS];
//    break;
//    
//    // Vertical 1
//    case 5 :
//      CRGB led13[NUM_LEDS];
//      CRGB led9[NUM_LEDS];
//      CRGB led5[NUM_LEDS];
//      CRGB led1[NUM_LEDS];
//    break;
//    
//    case 6 :
//      CRGB led14[NUM_LEDS];
//      CRGB led10[NUM_LEDS];
//      CRGB led6[NUM_LEDS];
//      CRGB led2[NUM_LEDS];
//    break;
//    
//    case 7 :
//      CRGB led15[NUM_LEDS];
//      CRGB led11[NUM_LEDS];
//      CRGB led7[NUM_LEDS];
//      CRGB led3[NUM_LEDS];
//    break;
//    
//    case 8 :
//      CRGB led16[NUM_LEDS];
//      CRGB led12[NUM_LEDS];
//      CRGB led8[NUM_LEDS];
//      CRGB led4[NUM_LEDS];
//    break;
//    
//    default :
//      FastLED.show();
//    break;  
//  }
//}

void ledSnake(int r, int g, int b) {
  led1[0] = CRGB(r, g, b);
  FastLED.show();
  delay(333);
    led2[0] = CRGB(r, g, b);
  FastLED.show();
    delay(333);
  led3[0] = CRGB(r, g, b);
  FastLED.show();
    delay(333);
  led4[0] = CRGB(r, g, b);
  FastLED.show();
  delay(333);
  led8[0] = CRGB(r, g, b);
  FastLED.show();
  delay(333);
  led12[0] = CRGB(r, g, b);
  FastLED.show();
  delay(333);
  led16[0] = CRGB(r, g, b);
  FastLED.show();
  delay(333);
  led15[0] = CRGB(r, g, b);
  FastLED.show();
  delay(333);
  led14[0] = CRGB(r, g, b);
  FastLED.show();
  delay(333);
  led13[0] = CRGB(r, g, b);
  FastLED.show();
  delay(333);
  led9[0] = CRGB(r, g, b);
  FastLED.show();
  delay(333);
  led5[0] = CRGB(r, g, b);
  FastLED.show();
  delay(333);
  led6[0] = CRGB(r, g, b);
  FastLED.show();
    delay(333);
  led7[0] = CRGB(r, g, b);
  FastLED.show();
  delay(333);
  led11[0] = CRGB(r, g, b);
  FastLED.show();
   delay(333);
  led10[0] = CRGB(r, g, b);
  FastLED.show();
  delay(333);
}

void ledOuter(int r, int g, int b){
    led1[0] = CRGB(r, g, b);
    led2[0] = CRGB(r, g, b);
    led3[0] = CRGB(r, g, b);
    led4[0] = CRGB(r, g, b);
    led5[0] = CRGB(r, g, b);
    led8[0] = CRGB(r, g, b);
    led9[0] = CRGB(r, g, b);
    led12[0] = CRGB(r, g, b);
    led13[0] = CRGB(r, g, b);
    led14[0] = CRGB(r, g, b);
    led15[0] = CRGB(r, g, b);
    led16[0] = CRGB(r, g, b);
    FastLED.show();
}

void ledInner(int r, int g, int b){
  
    led6[0] = CRGB(r, g, b);
    led7[0] = CRGB(r, g, b);
    led10[0] = CRGB(r, g, b);
    led11[0] = CRGB(r, g, b);
    FastLED.show();
}


void ledAllOff(){
  
    led1[0] = CRGB::Black;
    led2[0] = CRGB::Black;
    led3[0] = CRGB::Black;
    led4[0] = CRGB::Black;
    led5[0] = CRGB::Black;
    led6[0] = CRGB::Black;
    led7[0] = CRGB::Black;
    led8[0] = CRGB::Black;
    led9[0] = CRGB::Black;
    led10[0] = CRGB::Black;
    led11[0] = CRGB::Black;
    led12[0] = CRGB::Black;
    led13[0] = CRGB::Black;
    led14[0] = CRGB::Black;
    led15[0] = CRGB::Black;
    led16[0] = CRGB::Black;
    FastLED.show();
}

void ledAllOn(int r, int g, int b){
  
    led1[0] = CRGB(r, g, b);
    led2[0] = CRGB(r, g, b);
    led3[0] = CRGB(r, g, b);
    led4[0] = CRGB(r, g, b);
    led5[0] = CRGB(r, g, b);
    led6[0] = CRGB(r, g, b);
    led7[0] = CRGB(r, g, b);
    led8[0] = CRGB(r, g, b);
    led9[0] = CRGB(r, g, b);
    led10[0] = CRGB(r, g, b);
    led11[0] = CRGB(r, g, b);
    led12[0] = CRGB(r, g, b);
    led13[0] = CRGB(r, g, b);
    led14[0] = CRGB(r, g, b);
    led15[0] = CRGB(r, g, b);
    led16[0] = CRGB(r, g, b);
    FastLED.show();
}

void ledCross(int r, int g, int b){
  
  led1[0] = CRGB(r, g, b);
  led4[0] = CRGB(r, g, b);
  led6[0] = CRGB(r, g, b);
  led7[0] = CRGB(r, g, b);
  led10[0] = CRGB(r, g, b);
  led11[0] = CRGB(r, g, b);
  led13[0] = CRGB(r, g, b);
  led16[0] = CRGB(r, g, b);
  FastLED.show(); 
}

