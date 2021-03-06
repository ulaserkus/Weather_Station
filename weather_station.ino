#include "BlueDot_BME280.h"  

#include <LiquidCrystal.h>  //Kütüphanemizi ekliyoruz

// Kütüphanenin karşılık geldiği arayüz pinlerini buradan belirtiyoruz. bunları kontrol etmenizde fayda var.

LiquidCrystal lcd(8, 9, 13, 12, 11, 10); /// REGISTER PIN,ENABLE PIN,D4 PIN,D5 PIN, D6 PIN, D7 PIN
#define ClockPin 2 // Must be pin 2 or 3

#define Multiplier 15000000.0 

int yagmur;
int toprak;
                                  
BlueDot_BME280 bme2;                                    
int bme2Detected = 0;

volatile long count = 0;
volatile int32_t dTime; 
volatile bool DataPinVal;

void onPin2CHANGECallBackFunction(){
    static uint32_t lTime; // Saved Last Time of Last Pulse
    uint32_t cTime; // Current Time
    cTime = micros(); // Store the time for RPM Calculations

    dTime = cTime - lTime;
    lTime = cTime;

}
void setup() {
  //pinMode(A3,OUTPUT);
  Serial.begin(9600);
  lcd.begin(16,2);
  pinMode(ClockPin, INPUT);  

  attachInterrupt(digitalPinToInterrupt(ClockPin),onPin2CHANGECallBackFunction,RISING);
    bme2.parameter.I2CAddress = 0x76;                    
    bme2.parameter.sensorMode = 0b11;                    //Setup Sensor mode for Sensor 2 
    bme2.parameter.IIRfilter = 0b100;                   //IIR Filter for Sensor 2
    bme2.parameter.humidOversampling = 0b101;            
    bme2.parameter.tempOversampling = 0b101;              
    bme2.parameter.pressOversampling = 0b101;              
    bme2.parameter.pressureSeaLevel = 1013.25;            
    bme2.parameter.tempOutsideCelsius = 15;               
    bme2.parameter.tempOutsideFahrenheit = 59;            
  if (bme2.init() != 0x60)
  {    
   
    bme2Detected = 0;
  }
  else
  {
  
    bme2Detected = 1;
  }
  pinMode(9,OUTPUT);
}

  // put your setup code here, to run once:
   



void loop() {
    float DeltaTime;
  float SpeedInRPM = 0;

   noInterrupts ();

  DeltaTime = dTime;
  interrupts ();
  
yagmur=analogRead(A0);

toprak=analogRead(A1);
 
Serial.print(yagmur);
Serial.print("*");
Serial.print(toprak);
 if (bme2Detected)
  {
     Serial.print("*");
     
    Serial.print(bme2.readTempC());
      Serial.print("*"); 
      
    Serial.print(bme2.readHumidity());
      Serial.print("*"); 
      
    Serial.print(bme2.readPressure());
      Serial.print("*"); 
      int Alt = bme2.readAltitudeMeter();
    Serial.print(bme2.readAltitudeMeter());   
          
          
  }
  SpeedInRPM = Multiplier / DeltaTime; 


  static unsigned long SpamTimer;
  if ( (unsigned long)(millis() - SpamTimer) >= (100)) {
    SpamTimer = millis();

     Serial.print("*"); 
    Serial.println(0.3 * SpeedInRPM * 0.001885 );//radius * pi *2*rpm*60/1000*0.27);
    delay(1000);
    SpeedInRPM = 0; 
  }
  LCDPrint();
 
   
 
}
void LCDPrint(){
  // İmleci sütun 0'a, satır 1'e ayarlıyoruz
lcd.setCursor(0, 0);
lcd.print("HPa:");//ana İsim olacak dilediğinizi yazabilirsiniz
int Press = bme2.readPressure();
lcd.print(Press);
 // İmleci sütun 0'a, satır 2'ye ayarlıyoruz

lcd.print("  Nem:");//dilediğiniz ismi yazabilirsiniz.
int hum = bme2.readHumidity();
lcd.print(hum);
delay(750);//0.75 gecikme koyuyoruz
lcd.setCursor(0, 1);
//lcd.scrollDisplayLeft();//Yazıyı kaydırıyoruz
lcd.print("Toprak:");
lcd.print(toprak);
lcd.print(" C:");
int temp = bme2.readTempC();
lcd.print(temp);
lcd.setCursor(0, 0);// İmleci sütun 0'a, satır 1'e ayarlıyoruz
}
