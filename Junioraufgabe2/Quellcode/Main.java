import java.io.File;
import java.io.IOException;
import java.net.URISyntaxException;

import javax.swing.JFileChooser;
import javax.swing.JOptionPane;
import javax.swing.filechooser.FileNameExtensionFilter;

public class Main {
    public static void main(String[] args) {
		try {
			File kartenDatei = getFile();
			
			//Terminierung des Programms wenn keine Datei ausgew�hlt wurde
			if (kartenDatei == null)
				return;

			H�gelkarte karte = new H�gelkarte(kartenDatei);
			JOptionPane.showMessageDialog(null, "Die Karte enth�lt " + karte.zaehleBaulwurfbaue() + " Bauwurfbau(e)",
				"Baulwurfz�hlung", 1);

		// Fehlerbehandlung
		} catch (URISyntaxException e) {
			JOptionPane.showMessageDialog(null, "Die Datei konnte nicht gefunden werden!", "Fehler", 2);
		} catch (IOException e) {
			JOptionPane.showMessageDialog(null, "Die ausgew�hlte Datei ist ung�ltig!", "Fehler", 2);
		} catch (NullPointerException e) {
			JOptionPane.showMessageDialog(null,
				"Es ist ein unerwarteter Fehler augetreten, bitte versuchen Sie es erneut", "Fehler", 2);
		}
    }

    // Dateiauswahl
    public static File getFile() throws URISyntaxException {
		final JFileChooser chooser = new JFileChooser();
		chooser.setFileFilter(new FileNameExtensionFilter("H�gelkarte", "txt"));
		chooser.setCurrentDirectory(new File(Main.class.getProtectionDomain().getCodeSource().getLocation().toURI()));
		chooser.setDialogTitle("W�hlen Sie eine H�gelkare aus");
		chooser.showOpenDialog(null);

		return chooser.getSelectedFile();
    }
}
