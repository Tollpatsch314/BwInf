import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

public class H�gelkarte {
    private int[] feldGroe�e = new int[2];
    private MaulwurfFeld[][] felder;
    
    
    // L�d eine H�gelkarte von einer Datei
    public H�gelkarte(File karte) throws IOException {
	BufferedReader reader = new BufferedReader(new FileReader(karte));
	String line;

	// Auslesen und Einrichten der Feldgr��e
	try {
	    feldGroe�e[1] = Integer.parseInt(reader.readLine());
	    feldGroe�e[0] = Integer.parseInt(reader.readLine());
	} catch (NumberFormatException | NullPointerException e) {
	    reader.close();
	    throw new IOException(
		    "Die Kopfzeile konnte nicht ausgelesen werden, vielleicht ist die ausgew�hlte Datei ung�ltig");
	}
	felder = new MaulwurfFeld[feldGroe�e[0]][feldGroe�e[1]];

	// Einrichten der Felder
	for (int y = 0; y < feldGroe�e[0]; y++) {
	    line = reader.readLine();
	    if (line == null) {
		for (int x = 0; x < feldGroe�e[1]; x++)
		    felder[y][x] = new MaulwurfFeld(false);
	    } else
		for (int x = 0; x < feldGroe�e[1]; x++)
		    felder[y][x] = new MaulwurfFeld(line.length() > x && line.charAt(x) == 'X');
	}

	reader.close();
    }
    
    // Z�hlt alle Baulwurfbaue auf dem Feld
    public int zaehleBaulwurfbaue() {
	int anzahl = 0;
	for (int y = 0; y < feldGroe�e[0]; y++)
	    for (int x = 0; x < feldGroe�e[1]; x++) {
		if (istBaulwurfbau(y, x))
		    anzahl++;
	    }
	return anzahl;
    }

    // Testet, ob an dem Punkt (x|y) ein Baulwurfbau beginnt
    public boolean istBaulwurfbau(int y, int x) {
	// Relative Felder von y und x, die auch zu einem Bau geh�ren m�ssten
	int[][] testFelder = { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 1, 0 }, { 1, 2 }, { 2, 0 }, { 2, 2 }, { 3, 0 }, { 3, 1 },
		{ 3, 2 } };
	// Test der relativen Felder
	for (int[] feld : testFelder) {
	    if (feld[0] + y >= feldGroe�e[0] || feld[1] + x >= feldGroe�e[1]) {
		return false;
	    }
	    if (!felder[y + feld[0]][x + feld[1]].istHuegel || felder[y + feld[0]][x + feld[1]].wurdeGescannt) {
		return false;
	    }
	}

	// Bei Erfolg werden die Felder als vergeben gekennzeichnet, sodass sie zu
	// keinem anderen Bau zugeordnet werden k�nnen.
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
