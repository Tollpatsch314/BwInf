
public class Main {
    public static void main(String[] args) {
	
	System.out.println("Wählen Sie einen Modus aus");
	System.out.println("(1) Liga");
	System.out.println("(2) KO-Prinzip");
	System.out.println("(3) KOx5-Prinzip");
	
	switch(InOut.readString("Wählen Sie aus: ")) {
	case "1":
	    System.out.println("Starte Liga\n==========");
	    BWINF_TobisTurnier_Liga_JakobParidon_2020.main(args);
	    break;
	case "2":
	    System.out.println("Starte KO\n==========");
	    BWINF_TobisTurnier_KO_JakobParidon_2020.main(args);
	    break;
	case "3":
	    System.out.println("Starte KOx5\n==========");
	    BWINF_TobisTurnier_KOx5_JakobParidon_2020.main(args);
	    break;
	default:
	    System.err.println("Das ist eine ungültige Eingabe!");
	    main(args);
	    break;
	}
    }
}
