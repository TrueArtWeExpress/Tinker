#include <Thread.h> 
#include <ThreadController.h> 
#include <Bounce2.h> //Debounce library
#include <Multiplexer4067.h> //MUX library
#include "MIDIUSB.h"

#define NUM_BUTTONS 11 // Number of digital pins
const uint8_t BUTTON_PINS[NUM_BUTTONS] = {9, 8, 7, 6, 10, 16, 14, 15, 18, 19, 20}; // Digital pins for buttons

int RXLED = 17; // Pin for RX-led
int ledState = LOW; // Initial state for RX-led

const byte muxNButtons = 5; // Number of input pins used by MUX
const byte NButtons = 11; // Number of used digital inputs
const byte muxButtonPin[muxNButtons] = {11, 12, 13, 14, 15}; // Array's with digital pins used for MUX
const byte totalButtons = muxNButtons + NButtons;
const byte buttonPin[NButtons] = {9, 8, 7, 6, 10, 16, 14, 15, 18, 19, 20}; // Digital button pins
int buttonCState[totalButtons] = {0}; // Current state of digital ports
int buttonPState[totalButtons] = {0}; // Previous state of digital ports
char mystr[3] = "00000"; //String data

Multiplexer4067 mplex = Multiplexer4067(2, 3, 4, 5, A3); // Defining MUX

Bounce * buttons = new Bounce[NUM_BUTTONS]; // Defining bounce instance

// Potentiometers
const byte NPots = 11; // Number of pots
const byte muxPotPin[NPots] = {0, 1, 2, 3,  4,  5, 6, 7, 8, 9, 10}; // Pot Pins on MUX
int potCState[NPots] = {0}; // Current analog port state
int potPState[NPots] = {0}; // Previous analog port state
int potVar = 0; // Difference between current and previous port state
int lastCcValue[NPots] = {0};

// pot reading
int TIMEOUT = 50; 
byte varThreshold = 4; 
boolean potMoving = true; 
unsigned long pTime[NPots] = {0}; 
unsigned long timer[NPots] = {0}; 

// midi
byte note = 16; // number of notes that will be used
byte cc = 1; // Number of layers
byte midiCh = 0;

// threads 
ThreadController cpu; 
Thread threadReadPots; 


// debounce
unsigned long lastDebounceTime = 0;  // the last time the output pin was toggled
unsigned long debounceDelay = 5;    // the debounce time; increase if the output flickers

void setup() {
  mplex.begin();
  pinMode(A3, INPUT_PULLUP);
  
  for (int i = 0; i < NUM_BUTTONS; i++) {
    buttons[i].attach( BUTTON_PINS[i] , INPUT_PULLUP  ); //setup the bounce instance for the current button
    buttons[i].interval(25); // interval in ms
  }

  // threads setup
  threadReadPots.setInterval(10);
  threadReadPots.onRun(readPots);
  cpu.add(&threadReadPots);
  
  // Begin the Serial at 9600 Baud
  Serial.begin(9600);
  
  pinMode(RXLED, OUTPUT); // RX-ledpin
  digitalWrite(RXLED, ledState); // RX-ledpin

}

void loop() {

  cpu.run();
  readButtons();

}

void readButtons() {

  for (int i = 0; i < muxNButtons; i++) { //reads buttons on mux
    int buttonReading = mplex.readChannel(muxButtonPin[i]);
    //buttonCState[i] = map(mplex.readChannel(muxButtonPin[i]), 22, 1023, 0, 2); // stores on buttonCState
    if (buttonReading > 1000) {
      buttonCState[i] = HIGH;
    }
    else {
      buttonCState[i] = LOW;
    }
    //Serial.print(buttonCState[i]); Serial.print("   ");//testline
  }
  //Serial.println();//testline

  for (int i = 0; i < NButtons; i++) { //read buttons on Arduino
    buttonCState[i + muxNButtons] = digitalRead(buttonPin[i]); // stores in the rest of buttonCState
  }

  for (int i = 0; i < totalButtons; i++) {

    if ((millis() - lastDebounceTime) > debounceDelay) {

      if (buttonCState[i] != buttonPState[i]) {
        lastDebounceTime = millis();

        if (buttonCState[i] == LOW) {
          noteOn(potMidiCh(), note + i, 127);  // Channel 0, middle C, normal velocity
          MidiUSB.flush();
          //MIDI.sendNoteOn(note + i, 127, potMidiCh()); // envia NoteOn(nota, velocity, canal midi)
		  Serial.write(mystr,5); //Write the serial data
          Serial.print("Note: "); Serial.print(note + i); Serial.println(" On");
          buttonPState[i] = buttonCState[i];
        }
        else {
          noteOn(potMidiCh(), note + i, 0);  // Channel 0, middle C, normal velocity
          MidiUSB.flush();
          //MIDI.sendNoteOn(note + i, 0, potMidiCh());
          Serial.print("Note: "); Serial.print(note + i); Serial.println(" Off");
          buttonPState[i] = buttonCState[i];
        }
      }
    }

  }

}

void readPots() {

  for (int i = 0; i < NPots - 1; i++) { 
    potCState[i] = mplex.readChannel(muxPotPin[i]);
  }

  for (int i = 0; i < NPots; i++) {

    potVar = abs(potCState[i] - potPState[i]); 

    if (potVar >= varThreshold) {  
      pTime[i] = millis(); 
    }
    timer[i] = millis() - pTime[i]; 
    if (timer[i] < TIMEOUT) { 
      potMoving = true;
    }
    else {
      potMoving = false;
    }

    if (potMoving == true) { 
      int ccValue = map(potCState[i], 22, 1022, 0, 127);
      if (lastCcValue[i] != ccValue) {
        controlChange(11, cc + i, ccValue); // manda control change (channel, CC, value)
        MidiUSB.flush();
        //MIDI.sendControlChange(cc + i, map(potCState[i], 0, 1023, 0, 127), 11); // envia Control Change (numero do CC, valor do CC, canal midi)
        Serial.print("CC: "); Serial.print(cc + i); Serial.print(" value:"); Serial.println(map(potCState[i], 22, 1023, 0, 127));
        potPState[i] = potCState[i]; 
        lastCcValue[i] = ccValue;
      }
    }
  }

}

//Calculate midi channel based on pot position
int potMidiCh () {
  int potCh =  map(mplex.readChannel(muxPotPin[9]), 22, 1023, 0, 4);

  if (potCh == 4) {
    potCh = 3;
  }
  
  return potCh + midiCh;
}

// Arduino (pro)micro midi functions MIDIUSB Library
void noteOn(byte channel, byte pitch, byte velocity) {
  midiEventPacket_t noteOn = {0x09, 0x90 | channel, pitch, velocity};
  MidiUSB.sendMIDI(noteOn);
}

void noteOff(byte channel, byte pitch, byte velocity) {
  midiEventPacket_t noteOff = {0x08, 0x80 | channel, pitch, velocity};
  MidiUSB.sendMIDI(noteOff);
}

void controlChange(byte channel, byte control, byte value) {
  midiEventPacket_t event = {0x0B, 0xB0 | channel, control, value};
  MidiUSB.sendMIDI(event);
}


