/**
 *
 * Beschreibung
 *
 * @version 1.0 vom 12.10.2020
 * @author Jakob Paridon 
 */

public class BWINF_TobisTurnier_KOx5_JakobParidon_2020 {   //Variablen sortieren
  
  public static void main(String[] args) {
    //Variablen-Deklaration
    int spielerAnzahl = InOut.readInt("Wieviele Spieler nehmen an dem Turnier teil? ");
    double spielerAnzahlGeteilt = spielerAnzahl; //s. Dokumentation
    int wiederholungen = InOut.readInt("Ueber wieviele Runden soll das Turnier gespielt werden? ");
    
    double spielStaerkeGesamt = 0;//Spielerstaerke von beiden Spielern zusammengenommen (s. Dokumentation)
    double groessteSpielStaerke = 0; //Variable zum Speichern der groessten Spielstaerke
    double spielStaerke[] = new double[spielerAnzahl]; //Staerke der einzelnen Spieler wird deklariert
    int staerksterSpieler[] = new int[spielerAnzahl]; //Variable zum Speichern des staerksten Spielers bzw. der staerksten Spieler
    int anzahlGroessteStaerke = 0; //Variable zum Festhalten der Anzahl der Spieler, die die groesste Stärke haben
    double staerkeGeteilt = 0;
    
    int siege[] = new int[spielerAnzahl]; //Variable zum Festhalten der Siege im einzelnen Spiel wird deklariert
    int siegeGesamt[] = new int[spielerAnzahl]; ////Variable zum Festhalten der Siege der Turniere wird deklariert
    double zufall = 0;
    
    int mitspielerNummer=0; //Variable, die angibt, an welcher Stelle der Mitspieler, der gewonnen hat, gespeichert werden soll
    int spiele = 0; //haelt fest, wieviele Spiele gespielt werden muessen
    
    int ersterSpieler = 0; //Festhalten des ersten Spielers in einem Spiel
    int zweiterSpieler = 0; //Festhalten des zweiten Spielers in einem Spiel
    int mitspieler[] = new int[spielerAnzahl]; //Variable zum Festhalten der verbleibenden Mitspieler
    
    
    for (int i=0;i<spielerAnzahl;++i) { //Definition der Mitspieler 
      mitspieler[i]=i;
    } // end of for
    
    for (int i=0;i<spielerAnzahl/2;++i) { //Ermittlung der Spielanzahl
      if (Math.pow(2, i)==spielerAnzahl) {
        spiele=i;
        break;
      } // end of if
    } // end of for
    
    //Einlesen der Werte
        for (int i=0;i<(spielerAnzahl);++i) { //Einlesen der Spielstaerken
      spielStaerke[i] = InOut.readInt("Wie stark ist Spieler "+(i+1)+"? "); //Spielerstaerke wird  definiert
    } // end of for
    
    for (int i=0;i<spielerAnzahl;++i) { //Feststellung der groessten Spielstaerken
      if (spielStaerke[i]>groessteSpielStaerke) {
        groessteSpielStaerke = spielStaerke[i];
      } // end of if
    } // end of for
    
    for (int i=0;i<spielerAnzahl;++i) {
      if (spielStaerke[i]==groessteSpielStaerke) {
        staerksterSpieler[anzahlGroessteStaerke] = i;
        ++anzahlGroessteStaerke;
      } // end of if
    } // end of for
    
    
    //Austragen der Turniere
      for (int a=0;a<wiederholungen;++a ) {
      
      for (int i=0;i<spielerAnzahl;++i) {
        siege[i]=0;
      } // end of for 
      
      for (int i=0;i<spielerAnzahl;++i) { //Zuruecksetzen der Mitspieler 
        mitspieler[i]=i;
      } // end of for
      
      for (int i=0;i<spiele;++i) { 
        mitspielerNummer=0;
        for (int j=0;j<(spielerAnzahl/(Math.pow(2,i)));j+=2) { //fuer alle (verbleibenden) Mitspieler wird das Turnier durchgeführt
          ersterSpieler = mitspieler[j];
          zweiterSpieler = mitspieler[(j+1)];
          spielStaerkeGesamt = spielStaerke[ersterSpieler]+spielStaerke[zweiterSpieler];
          staerkeGeteilt = spielStaerke[ersterSpieler]/spielStaerkeGesamt;
          
          for (int k=0;k<5;++k) { //Durchfuehren der Spiele im Turnier
            zufall = Math.random();
            if (zufall<staerkeGeteilt) { //zufall wird ausgelesen (s. Dokumentation)
              ++siege[ersterSpieler];
              } // end of if
            else {
              ++siege[zweiterSpieler];
            } // end of if-else
          } // end of for    
          
           if (siege[ersterSpieler]>siege[zweiterSpieler]) {
            mitspieler[mitspielerNummer]=ersterSpieler;
          } // end of if
          else {
            mitspieler[mitspielerNummer]=zweiterSpieler;
          } // end of for
          ++mitspielerNummer;
        } // end of if-else
        
        } // end of for
      
      ++siegeGesamt[mitspieler[0]]; //Erhoehung der Siege des Spielers
       } // end of for
    
    
    for (int i=0;i<anzahlGroessteStaerke;++i) {
      System.out.println("Staerkster: Siege von Spieler "+(staerksterSpieler[i]+1)+": "+siegeGesamt[staerksterSpieler[i]]);
    } // end of for
    
    for (int i=0;i<spielerAnzahl;++i) {
      System.out.println("Siege von "+(i+1)+": "+siegeGesamt[i]);
    } // end of for
    System.out.println("Das Spiel startet erneut");
    System.out.println("==========");
    Main.main(args);
  } // end of main

} // end of class BWINF_TobisTurnier_KOx5_JakobParidon_2020

