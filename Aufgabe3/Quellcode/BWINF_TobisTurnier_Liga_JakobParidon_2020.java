/**
 *
 * Beschreibung
 *
 * @version 1.0 vom 08.10.2020
 * @author Jakob Paridon 
 */

public class BWINF_TobisTurnier_Liga_JakobParidon_2020 {
  
  public static void main(String[] args) {
    int spielerAnzahl = InOut.readInt("Wieviele Spieler nehmen an dem Turnier teil? "); //Anzhl der Teilnehmenden Spieler
    double spielStaerke[] = new double[spielerAnzahl]; //Staerke der einzelnen Spieler wird deklariert
    int siege[] = new int[spielerAnzahl]; //Variable zum Festhalten der Siege jedes Spielers im Turnier
    double zufall = 0;
    double spielStaerkeGesamt = 0;//Spielerstaerke von beiden Spielern zusammengenommen (s. Dokumentation)
    double groessteSpielStaerke = 0; //Variable zum Speichern der groessten Spielstaerke
    int staerksterSpieler[] = new int[spielerAnzahl]; //Variable zum Speichern des staerksten Spielers
    int anzahlGroessteStaerke = 0; //Variable zum Festhalten der Anzahl der Spieler, die die groesste Stärke haben
    int wiederholungen = InOut.readInt("Ueber wieviele Runden soll das Turnier gespielt werden? ");
    double staerkeGeteilt = 0; 
    int siegeGesamt[] = new int[spielerAnzahl]; //Anzahl der gewonnenen Turniere jedes Spielers
    int siegeVergleich=0; //Variable zum Vergleichen der gewonnenen Turniere
    int meisteSiege=0; //Variable zum Speichern des Spielers mit den meisten Siegen jede Runde
    
    for (int i=0;i<(spielerAnzahl);++i) { //die Spielerstaerken werden eingelesen
      spielStaerke[i]=InOut.readInt("Wie stark ist Spieler "+(i+1)+"? "); //Spielerstaerke wird  definiert
    } // end of for
    
    for (int i=0;i<spielerAnzahl;++i) { //groesste Spielstaerke wird festgestellt
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
    
    //Die Turniere werden durchgefuehrt
    for (int a=0;a<wiederholungen;++a ) {
      
      //einige Variablen (ggf. aller Spieler) werden für jedes Turnier auf 0 gesetzt 
      for (int i=0;i<spielerAnzahl;++i) {
        siege[i]=0;
      } // end of for
      siegeVergleich=0;
      meisteSiege=0;
      
      //ein Turnier wird durchgeführt
      for (int j=0;j<(spielerAnzahl);++j) {
        for (int k=0;k<(spielerAnzahl);++k) {
          if (j!=k) {     
            spielStaerkeGesamt = spielStaerke[j]+spielStaerke[k];
            staerkeGeteilt = spielStaerke[j]/spielStaerkeGesamt;
            zufall = Math.random();
            if (zufall<staerkeGeteilt) { //zufall wird ausgelesen (s. Dokumentation)
              ++siege[j];
            } // end of if
            else {
              ++siege[k];
            } // end of if-else
            
          } // end of if
        } // end of for 
      } // end of for
      
      //Feststellung der Spieler mit den meisten Siegen der einzelnen Kämpfe      
      for (int i=0;i<spielerAnzahl;++i) {
        if (siege[i]>siegeVergleich) {
          siegeVergleich=siege[i];
          meisteSiege=i; //Spieler mit den meisten Siegen
        } // end of if
      } // end of for
      ++siegeGesamt[meisteSiege]; //siegeGesamt wird für den Spieler mit den meisten Siegen des Turniers erhöht
    } // end of for
    
    //Siege werden ausgegeben
    for (int i=0;i<anzahlGroessteStaerke;++i) {
      System.out.println("Staerkster: Siege von Spieler "+(staerksterSpieler[i]+1)+": "+siegeGesamt[staerksterSpieler[i]]);
    } // end of for
    
    for (int i=0;i<spielerAnzahl;++i) {
      System.out.println("Siege von Spieler "+(i+1)+" : "+siegeGesamt[i]);
    } // end of for
    System.out.println("Das Spiel startet erneut");
    System.out.println("==========");
    Main.main(args);
  } // end of main

} // end of class BWINF_TobisTurnier_Liga_JakobParidon_2020

