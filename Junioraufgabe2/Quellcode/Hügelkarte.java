import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

public class Hügelkarte {
    private int[] feldGroeße = new int[2];
    private MaulwurfFeld[][] felder;
    
    
    // Läd eine Hügelkarte von einer Datei
    public Hügelkarte(File karte) throws IOException {
	BufferedReader reader = new BufferedReader(new FileReader(karte));
	String line;

	// Auslesen und Einrichten der Feldgröße
	try {
	    feldGroeße[1] = Integer.parseInt(reader.readLine());
	    feldGroeße[0] = Integer.parseInt(reader.readLine());
	} catch (NumberFormatException | NullPointerException e) {
	    reader.close();
	    throw new IOException(
		    "Die Kopfzeile konnte nicht ausgelesen werden, vielleicht ist die ausgewählte Datei ungültig");
	}
	felder = new MaulwurfFeld[feldGroeße[0]][feldGroeße[1]];

	// Einrichten der Felder
	for (int y = 0; y < feldGroeße[0]; y++) {
	    line = reader.readLine();
	    if (line == null) {
		for (int x = 0; x < feldGroeße[1]; x++)
		    felder[y][x] = new MaulwurfFeld(false);
	    } else
		for (int x = 0; x < feldGroeße[1]; x++)
		    felder[y][x] = new MaulwurfFeld(line.length() > x && line.charAt(x) == 'X');
	}

	reader.close();
    }
    
    // Zählt alle Baulwurfbaue auf dem Feld
    public int zaehleBaulwurfbaue() {
	int anzahl = 0;
	for (int y = 0; y < feldGroeße[0]; y++)
	    for (int x = 0; x < feldGroeße[1]; x++) {
		if (istBaulwurfbau(y, x))
		    anzahl++;
	    }
	return anzahl;
    }

    // Testet, ob an dem Punkt (x|y) ein Baulwurfbau beginnt
    public boolean istBaulwurfbau(int y, int x) {
	// Relative Felder von y und x, die auch zu einem Bau gehören müssten
	int[][] testFelder = { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 1, 0 }, { 1, 2 }, { 2, 0 }, { 2, 2 }, { 3, 0 }, { 3, 1 },
		{ 3, 2 } };
	// Test der relativen Felder
	for (int[] feld : testFelder) {
	    if (feld[0] + y >= feldGroeße[0] || feld[1] + x >= feldGroeße[1]) {
		return false;
	    }
	    if (!felder[y + feld[0]][x + feld[1]].istHuegel || felder[y + feld[0]][x + feld[1]].wurdeGescannt) {
		return false;
	    }
	}

	// Bei Erfolg werden die Felder als vergeben gekennzeichnet, sodass sie zu
	// keinem anderen Bau zugeordnet werden können.
	for (int[] feld : testFelder)
	    felder[feld[0] + y][feld[1] + x].wurdeGescannt = true;
	return true;
    }

    public class MaulwurfFeld {
	public boolean istHuegel;
	public boolean wurdeGescannt = false;

	public MaulwurfFeld(boolean istHuegel) {
	    this.istHuegel = istHuegel;
	}
    }
}
