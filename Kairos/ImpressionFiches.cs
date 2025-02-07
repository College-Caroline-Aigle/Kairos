using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using ITextFont = iTextSharp.text.Font;
using ITextDocument = iTextSharp.text.Document;
using ITextRectangle = iTextSharp.text.Rectangle;
using ITextImage = iTextSharp.text.Image;
using System.Linq;
using System.Collections.Generic;

namespace FichesT
{
    public class ImpressionFiches
    {
        private PrintDocument printDocument;
        // Ajout des variables membres pour les dimensions
        private readonly int hauteurLegende = 80;
        private readonly int hauteurCourbe = 140;
        private readonly int espacementCourbeLegende = 25;
        private bool ajouterPageBlanche = false; // Nouvel indicateur pour savoir si une page blanche doit être ajoutée
        private bool impressionFichesElevesTerminee = false;

        public ImpressionFiches()
        {
            InitializePrintDocument();
            ajouterPageBlanche = false; // Initialiser l'indicateur
        }

        private void InitializePrintDocument()
        {
            printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("A3", 1169, 827);
            printDocument.PrintPage += PrintFichesEnT;
        }

        public void ApercuImpressionA4Portrait()
        {
            // Réinitialiser les indices globaux
            Global.indexNiveau = 0;
            Global.indexClasse = 0;
            ajouterPageBlanche = false;

            using (PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog())
            {
                // Configuration du document d'impression en paysage
                printDocument = new PrintDocument();
                printDocument.PrintPage += PrintFichesEnT;

                // Configuration en paysage avec taille A3
                printDocument.DefaultPageSettings.Landscape = true;  // Changé en true pour le mode paysage
                PaperSize paperSize = new PaperSize("A3", 1342, 1000);  // Taille A3 en mode paysage
                printDocument.DefaultPageSettings.PaperSize = paperSize;

                // Configuration du dialogue de prévisualisation
                printPreviewDialog.Document = printDocument;

                // Définir la taille de la fenêtre pour qu'elle occupe presque tout l'écran
                printPreviewDialog.Width = Screen.PrimaryScreen.WorkingArea.Width - 100;
                printPreviewDialog.Height = Screen.PrimaryScreen.WorkingArea.Height - 100;
                printPreviewDialog.StartPosition = FormStartPosition.CenterScreen;

                // Configuration de l'aperçu
                printPreviewDialog.Load += (sender, e) =>
                {
                    if (printPreviewDialog.Controls.Count > 0)
                    {
                        foreach (Control control in printPreviewDialog.Controls)
                        {
                            if (control is Panel panel && panel.Controls.Count > 0)
                            {
                                if (panel.Controls[0] is PrintPreviewControl previewControl)
                                {
                                    previewControl.AutoZoom = false;
                                    previewControl.Zoom = 1.0;  // Zoom à 100%
                                    previewControl.UseAntiAlias = true;
                                }
                            }
                        }
                    }

                    foreach (Control control in printPreviewDialog.Controls)
                    {
                        if (control is ToolStrip toolStrip)
                        {
                            for (int i = 0; i < toolStrip.Items.Count; i++)
                            {
                                if (toolStrip.Items[i] is ToolStripButton button &&
                                    button.ToolTipText.Contains("Imprimer"))
                                {
                                    ToolStripButton newPrintButton = new ToolStripButton()
                                    {
                                        Image = button.Image,
                                        DisplayStyle = button.DisplayStyle,
                                        ToolTipText = "Exporter en PDF"
                                    };

                                    newPrintButton.Click += async (s, evt) =>
                                    {
                                        newPrintButton.Enabled = false;
                                        try
                                        {
                                            DialogResult result = MessageBox.Show(
                                                "Vous allez être invité à choisir l'emplacement de sauvegarde de votre PDF.\n\n" +
                                                "Cliquez sur OK pour continuer.",
                                                "Export PDF",
                                                MessageBoxButtons.OKCancel,
                                                MessageBoxIcon.Information);

                                            if (result == DialogResult.OK)
                                            {
                                                printPreviewDialog.BeginInvoke(new Action(() =>
                                                {
                                                    printPreviewDialog.Close();
                                                    ExporterVersPDF();
                                                }));
                                            }
                                            else
                                            {
                                                newPrintButton.Enabled = true;
                                            }
                                        }
                                        catch
                                        {
                                            newPrintButton.Enabled = true;
                                            throw;
                                        }
                                    };

                                    toolStrip.Items.RemoveAt(i);
                                    toolStrip.Items.Insert(i, newPrintButton);
                                    break;
                                }
                            }
                        }
                    }
                };

                printPreviewDialog.ShowDialog();
            }
        }

        public void ApercuImpressionAvecChoix()
        {
            DialogResult result = MessageBox.Show(
                "Voulez-vous imprimer les fiches en colonne?\n\n" +
                "Oui = Fiches en A3 Colonne\n" +
                "Non = Fiches avec statistique en A4 (mode actuel)",
                "Choix du mode d'impression",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Cancel)
                return;

            if (result == DialogResult.Yes)
            {
                // Mode Portrait A3
                printDocument = new PrintDocument();
                printDocument.DefaultPageSettings.Landscape = true;
                printDocument.DefaultPageSettings.PaperSize = new PaperSize("A3", 1654, 1169);  // A3 en portrait

                // Réinitialiser les indices
                Global.indexNiveau = 0;
                currentClassIndex = 0;
                maxPositionY = 0;
                debutNouveauNiveau = true;
                pageCount = 0;

                printDocument.PrintPage += PrintFichesEnColonnes;

                using (PrintPreviewDialog previewDialog = new PrintPreviewDialog())
                {
                    previewDialog.Document = printDocument;

                    // Ajouter un bouton pour exporter en PDF
                    previewDialog.Load += (sender, e) =>
                    {
                        if (previewDialog.Controls.Count > 0)
                        {
                            foreach (Control control in previewDialog.Controls)
                            {
                                if (control is ToolStrip toolStrip)
                                {
                                    for (int i = 0; i < toolStrip.Items.Count; i++)
                                    {
                                        if (toolStrip.Items[i] is ToolStripButton button &&
                                            button.ToolTipText.Contains("Imprimer"))
                                        {
                                            ToolStripButton newPrintButton = new ToolStripButton()
                                            {
                                                Image = button.Image,
                                                DisplayStyle = button.DisplayStyle,
                                                ToolTipText = "Exporter en PDF"
                                            };

                                            newPrintButton.Click += async (s, evt) =>
                                            {
                                                newPrintButton.Enabled = false;
                                                try
                                                {
                                                    DialogResult results = MessageBox.Show(
                                                        "Vous allez être invité à choisir l'emplacement de sauvegarde de votre PDF.\n\n" +
                                                        "Cliquez sur OK pour continuer.",
                                                        "Export PDF",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Information);

                                                    if (results == DialogResult.OK)
                                                    {
                                                        previewDialog.BeginInvoke(new Action(() =>
                                                        {
                                                            previewDialog.Close();
                                                            ExporterVersPDFA3();
                                                        }));
                                                    }
                                                    else
                                                    {
                                                        newPrintButton.Enabled = true;
                                                    }
                                                }
                                                catch
                                                {
                                                    newPrintButton.Enabled = true;
                                                    throw;
                                                }
                                            };

                                            toolStrip.Items.RemoveAt(i);
                                            toolStrip.Items.Insert(i, newPrintButton);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    };

                    previewDialog.ShowDialog();
                }
            }
            else
            {
                // Mode Portrait existant
                ApercuImpressionA4Portrait();
            }
        }

        private int currentClassIndex = 0;
        private int maxPositionY = 0;
        private bool debutNouveauNiveau = true;
        private Dictionary<string, int> elevesPrinted = new Dictionary<string, int>();
        private int pageCount = 0;

        private void PrintFichesEnColonnes(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int margeGauche = 5;
            int margeHaut = 5;
            int largeurFiche = 95;
            int hauteurFiche = 40;
            int espaceEntreLignes = 5;
            int espaceEntreClasses = 20;
            int nombreMaxColonnes = 9;

            // Vérifier s'il reste des niveaux à traiter
            if (Global.indexNiveau >= Global.lesNiveaux.Count)
            {
                e.HasMorePages = false;
                ResetPrintingState();
                return;
            }

            Niveau niveauActuel = Global.lesNiveaux[Global.indexNiveau];
            var toutesLesClasses = niveauActuel.getLesClasse();

            int positionX = margeGauche;
            int positionY = margeHaut;
            int colonneActuelle = 0;

            // Titre du niveau
            graphics.DrawString($"Fiches Élèves - {niveauActuel.nomDuNiveau}",
                new Font("Arial", 10, FontStyle.Bold), Brushes.Black, positionX, positionY);
            positionY += 30;

            // Calculer combien de classes peuvent tenir sur la largeur de la page
            int largeurDisponible = e.MarginBounds.Width;
            int classesParLigne = Math.Min(nombreMaxColonnes,
                (largeurDisponible - margeGauche) / (largeurFiche + espaceEntreClasses));

            bool niveauTermine = ImprimerClassesNiveau(graphics, niveauActuel, toutesLesClasses,
                ref positionX, ref positionY, ref colonneActuelle,
                classesParLigne, e.MarginBounds.Bottom,
                largeurFiche, hauteurFiche, espaceEntreLignes, espaceEntreClasses);

            if (niveauTermine)
            {
                Global.indexNiveau++;
                currentClassIndex = 0;
                maxPositionY = 0;
                elevesPrinted.Clear();
                // Ne pas mettre debutNouveauNiveau à true ici
            }

            pageCount++;
            e.HasMorePages = Global.indexNiveau < Global.lesNiveaux.Count;
        }

        private bool ImprimerClassesNiveau(Graphics graphics, Niveau niveau, List<Classe> classes,
            ref int positionX, ref int positionY, ref int colonneActuelle,
            int classesParLigne, int marginBottom,
            int largeurFiche, int hauteurFiche, int espaceEntreLignes, int espaceEntreClasses)
        {
            while (currentClassIndex < classes.Count && colonneActuelle < classesParLigne)
            {
                Classe cls = classes[currentClassIndex];
                string classeKey = $"{niveau.nomDuNiveau}_{cls.nomDeLaClasse}";
                if (!elevesPrinted.ContainsKey(classeKey))
                {
                    elevesPrinted[classeKey] = 0;
                }

                int positionYInitiale = positionY;

                // Imprimer le titre de la classe et les élèves
                if (!ImprimerClasseEtEleves(graphics, cls, classeKey,
                    ref positionX, ref positionY,
                    largeurFiche, hauteurFiche, espaceEntreLignes, marginBottom))
                {
                    return false;
                }

                // Vérifier si tous les élèves de la classe ont été imprimés
                var totalEleves = cls.getLesEleves().Count(es => es.dateSortie == default);
                if (elevesPrinted[classeKey] >= totalEleves)
                {
                    currentClassIndex++;
                    colonneActuelle++;
                    if (colonneActuelle < classesParLigne && currentClassIndex < classes.Count)
                    {
                        positionX += largeurFiche + espaceEntreClasses;
                        positionY = positionYInitiale;
                    }
                }
            }

            return currentClassIndex >= classes.Count;
        }

        private bool ImprimerClasseEtEleves(Graphics graphics, Classe cls, string classeKey,
            ref int positionX, ref int positionY,
            int largeurFiche, int hauteurFiche, int espaceEntreLignes, int marginBottom)
        {
            // Rectangle du titre de la classe
            Rectangle rectTitreClasse = new Rectangle(positionX, positionY, largeurFiche, 15);
            using (Brush orangeBrush = new SolidBrush(Color.FromArgb(255, 200, 100)))
            {
                graphics.FillRectangle(orangeBrush, rectTitreClasse);
            }
            graphics.DrawRectangle(Pens.Black, rectTitreClasse);

            graphics.DrawString(cls.nomDeLaClasse,
                new Font("Arial", 8, FontStyle.Bold),
                Brushes.Black,
                positionX + 3,
                positionY + 1);
            positionY += 18;

            Color couleurNiveau = GetCouleurNiveau(cls.nomDeLaClasse);

            // Imprimer les élèves
            var eleves = cls.getLesEleves()
                .Where(es => es.dateSortie == default)
                .OrderBy(es => es.nomEleve)
                .Skip(elevesPrinted[classeKey])
                .ToList();

            foreach (Eleve elv in eleves)
            {
                if (positionY + hauteurFiche > marginBottom)
                {
                    return false;
                }

                ImprimerFicheEleve(graphics, elv, positionX, positionY, largeurFiche, hauteurFiche, couleurNiveau);
                positionY += hauteurFiche + espaceEntreLignes;
                elevesPrinted[classeKey]++;
            }

            return true;
        }

        private void ImprimerFicheEleve(Graphics graphics, Eleve elv,
            int positionX, int positionY,
            int largeurFiche, int hauteurFiche,
            Color couleurNiveau)
        {
            Rectangle rectFiche = new Rectangle(positionX, positionY, largeurFiche, hauteurFiche);
            using (Brush brush = new SolidBrush(couleurNiveau))
            {
                graphics.FillRectangle(brush, rectFiche);
            }
            graphics.DrawRectangle(Pens.Black, rectFiche);

            graphics.DrawString(elv.nomEleve.ToUpper(),
                new Font("Arial", 5, FontStyle.Bold),
                Brushes.Black,
                positionX + 3,
                positionY + 3);
            graphics.DrawString(elv.prenomEleve,
                new Font("Arial", 6),
                Brushes.Black,
                positionX + 3,
                positionY + 12);

            ImprimerOptionsEleve(graphics, elv, positionX, positionY, hauteurFiche);
        }

        private void ImprimerOptionsEleve(Graphics graphics, Eleve elv,
            int positionX, int positionY, int hauteurFiche)
        {
            int optionX = positionX + 3;
            int optionY = positionY + hauteurFiche - 15;
            int largeurOption = 15;
            int hauteurOption = 8;

            if (elv.LV1 != null && elv.LV1.couleur != default)
            {
                using (Brush optionBrush = new SolidBrush(elv.LV1.couleur))
                {
                    graphics.FillRectangle(optionBrush, optionX, optionY, largeurOption, hauteurOption);
                }
                optionX += largeurOption + 3;
            }

            if (elv.option1 != null && elv.option1.couleur != default)
            {
                using (Brush optionBrush = new SolidBrush(elv.option1.couleur))
                {
                    graphics.FillRectangle(optionBrush, optionX, optionY, largeurOption, hauteurOption);
                }
                optionX += largeurOption + 3;
            }

            if (elv.option2 != null && elv.option2.couleur != default)
            {
                using (Brush optionBrush = new SolidBrush(elv.option2.couleur))
                {
                    graphics.FillRectangle(optionBrush, optionX, optionY, largeurOption, hauteurOption);
                }
            }
        }

        private void ResetPrintingState()
        {
            currentClassIndex = 0;
            Global.indexNiveau = 0;
            elevesPrinted.Clear();
            debutNouveauNiveau = true;
            pageCount = 0;
        }

        private Color GetCouleurNiveau(string nomClasse)
        {
            switch (nomClasse.First())
            {
                case '6': return Color.FromArgb(253, 255, 157);
                case '5': return Color.FromArgb(188, 255, 159);
                case '4': return Color.FromArgb(235, 194, 154);
                case '3': return Color.FromArgb(156, 225, 236);
                default: return Color.Gray;
            }
        }

        private void ExporterVersPDFA3()
{
    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
    {
        saveFileDialog.Filter = "Fichier PDF (*.pdf)|*.pdf";
        saveFileDialog.Title = "Enregistrer le PDF";

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            string cheminPDF = saveFileDialog.FileName;
            try
            {
                // Réinitialiser les indices et états avant l'export
                Global.indexNiveau = 0;
                currentClassIndex = 0;
                elevesPrinted.Clear();
                debutNouveauNiveau = true;
                pageCount = 0;

                using (FileStream fs = new FileStream(cheminPDF, FileMode.Create))
                {
                    // Créer le document en mode portrait A3
                    var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A3); // Portrait A3
                    var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, fs);
                    document.Open();

                    bool hasMorePages;
                    do
                    {
                        using (Bitmap bitmap = new Bitmap(1169, 1600)) // Dimensions A3 en portrait
                        {
                            using (Graphics graphics = Graphics.FromImage(bitmap))
                            {
                                graphics.Clear(Color.White);
                                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                                PrintPageEventArgs eventArgs = new PrintPageEventArgs(
                                    graphics,
                                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                    printDocument.DefaultPageSettings
                                );

                                PrintFichesEnColonnes(printDocument, eventArgs);
                                hasMorePages = eventArgs.HasMorePages;

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    var img = iTextSharp.text.Image.GetInstance(ms.ToArray());
                                    img.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                                    img.SetAbsolutePosition(0, 0);
                                    document.Add(img);

                                    if (hasMorePages)
                                    {
                                        document.NewPage();
                                    }
                                }
                            }
                        }
                    } while (hasMorePages);

                    document.Close();
                }

                try
                {
                    System.Diagnostics.Process.Start(cheminPDF);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Le PDF a été généré avec succès mais n'a pas pu être ouvert automatiquement.\n" +
                        $"Vous pouvez le trouver ici : {cheminPDF}",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                MessageBox.Show("PDF généré avec succès !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la génération du PDF : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

        private void ExporterVersPDF()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Fichier PDF (*.pdf)|*.pdf";
                saveFileDialog.Title = "Enregistrer le PDF";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string cheminPDF = saveFileDialog.FileName;
                    try
                    {
                        // Réinitialiser les indices et états avant l'export
                        Global.indexNiveau = 0;
                        Global.indexClasse = 0;
                        impressionFichesElevesTerminee = false;

                        using (FileStream fs = new FileStream(cheminPDF, FileMode.Create))
                        {
                            // Créer le document en mode portrait A3
                            var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A3);
                            var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, fs);
                            document.Open();

                            bool hasMorePages;
                            do
                            {
                                using (Bitmap bitmap = new Bitmap(827, 1169)) // Dimensions A3 en portrait
                                {
                                    using (Graphics graphics = Graphics.FromImage(bitmap))
                                    {
                                        graphics.Clear(Color.White);
                                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                                        PrintPageEventArgs eventArgs = new PrintPageEventArgs(
                                            graphics,
                                            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                            printDocument.DefaultPageSettings
                                        );

                                        PrintFichesEnT(printDocument, eventArgs);
                                        hasMorePages = eventArgs.HasMorePages;

                                        using (MemoryStream ms = new MemoryStream())
                                        {
                                            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                            var img = iTextSharp.text.Image.GetInstance(ms.ToArray());
                                            img.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                                            img.SetAbsolutePosition(0, 0);
                                            document.Add(img);

                                            if (hasMorePages)
                                            {
                                                document.NewPage();
                                            }
                                        }
                                    }
                                }
                            } while (hasMorePages);

                            document.Close();
                        }

                        try
                        {
                            System.Diagnostics.Process.Start(cheminPDF);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                $"Le PDF a été généré avec succès mais n'a pas pu être ouvert automatiquement.\n" +
                                $"Vous pouvez le trouver ici : {cheminPDF}",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }

                        MessageBox.Show("PDF généré avec succès !", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la génération du PDF : {ex.Message}",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string ConvertMoyenneToLetter(double moy)
        {
            if (moy >= 4.5) return "A";
            if (moy >= 3.5) return "B";
            if (moy >= 2.5) return "C";
            if (moy >= 1.5) return "D";
            return "E";
        }

        private void DessinerCourbesPourNiveau(Graphics graphics, Rectangle bounds, Niveau niveau)
        {
            // Récupérer les notes pour toutes les classes du niveau
            Dictionary<string, List<int>> classesNotes = new Dictionary<string, List<int>>();

            foreach (Classe cls in niveau.getLesClasse())
            {
                List<int> notesClasse = new List<int>();

                foreach (Eleve elv in cls.getLesEleves())
                {
                    if (elv.rdbNiveau != null && elv.dateSortie == default)
                    {
                        switch (elv.rdbNiveau.Name)
                        {
                            case "rdbA": notesClasse.Add(5); break;
                            case "rdbB": notesClasse.Add(4); break;
                            case "rdbC": notesClasse.Add(3); break;
                            case "rdbD": notesClasse.Add(2); break;
                            case "rdbE": notesClasse.Add(1); break;
                        }
                    }
                }

                if (notesClasse.Count > 0)
                {
                    classesNotes[cls.nomDeLaClasse] = notesClasse;
                }
            }

            if (classesNotes.Count == 0) return;

            // Définir les couleurs pour chaque courbe
            Color[] couleurs = { Color.Blue, Color.Red, Color.Green, Color.Orange, Color.Purple, Color.Brown, Color.Magenta };
            int couleurIndex = 0;

            // Réduire la largeur à 70% de la largeur disponible
            int largeurGraphique = (int)(bounds.Width * 0.7);
            int positionX = bounds.Left + (bounds.Width - largeurGraphique) / 2;

            Rectangle graphBounds = new Rectangle(
                positionX - 25,
                bounds.Top + 80,
                largeurGraphique,
                bounds.Height - 100
            );

            // Dessiner les axes
            using (Pen axePen = new Pen(Color.Black, 2))
            {
                graphics.DrawLine(axePen, graphBounds.Left, graphBounds.Bottom, graphBounds.Right, graphBounds.Bottom);
                graphics.DrawLine(axePen, graphBounds.Left, graphBounds.Top, graphBounds.Left, graphBounds.Bottom);
            }

            // Dessiner les labels des axes
            string[] labels = { "E", "D", "C", "B", "A" };
            float stepX = graphBounds.Width / (labels.Length - 1);

            using (Font axisFont = new Font("Arial", 12))
            {
                for (int i = 0; i < labels.Length; i++)
                {
                    float x = graphBounds.Left + (i * stepX);
                    graphics.DrawLine(Pens.Black, x, graphBounds.Bottom, x, graphBounds.Bottom + 5);
                    graphics.DrawString(labels[i], axisFont, Brushes.Black, x - 6, graphBounds.Bottom + 10);
                }
            }

            // Position de la légende
            int legendeStartY = graphBounds.Bottom + 40;
            int legendeX = graphBounds.Left;

            // Nouveau calcul de l'espacement de la légende
            // Utiliser une approche en colonnes pour mieux gérer l'espace
            int nombreClassesParLigne = 4; // Limitons à 4 classes par ligne
            int espacementHorizontal = largeurGraphique / nombreClassesParLigne;
            int espacementVertical = 30; // Espacement vertical entre les lignes
            Font legendFont = new Font("Arial", 10);

            // Calcul de maxYValue et facteurEchelle...
            double maxYValue = 0;
            foreach (var cls in classesNotes)
            {
                var notesClasse = cls.Value;
                double moyenne = notesClasse.Average();
                double variance = notesClasse.Sum(note => Math.Pow(note - moyenne, 2)) / notesClasse.Count;
                double ecartType = Math.Sqrt(variance);
                double yMax = (1.0 / (ecartType * Math.Sqrt(2 * Math.PI)));
                maxYValue = Math.Max(maxYValue, yMax);
            }

            double facteurEchelle = graphBounds.Height / (maxYValue * 1.2);

            // Dessiner les courbes et la légende
            couleurIndex = 0;
            int ligneActuelle = 0;
            int colonneActuelle = 0;

            foreach (var cls in classesNotes)
            {
                var notesClasse = cls.Value;
                Color couleurCourbe = couleurs[couleurIndex % couleurs.Length];

                // Dessiner la courbe (code existant)
                double moyenne = notesClasse.Average();
                double variance = notesClasse.Sum(note => Math.Pow(note - moyenne, 2)) / notesClasse.Count;
                double ecartType = Math.Sqrt(variance);

                List<PointF> points = new List<PointF>();
                for (double i = 1; i <= 5; i += 0.1)
                {
                    double z = (i - moyenne) / ecartType;
                    double yy = (1.0 / (ecartType * Math.Sqrt(2 * Math.PI))) * Math.Exp(-(z * z) / 2.0);
                    float pixelX = graphBounds.Left + (float)((i - 1) / 4.0 * graphBounds.Width);
                    float pixelY = graphBounds.Bottom - (float)(yy * facteurEchelle);
                    points.Add(new PointF(pixelX, pixelY));
                }

                if (points.Count > 1)
                {
                    using (Pen courbePen = new Pen(couleurCourbe, 2.5f))
                    {
                        graphics.DrawLines(courbePen, points.ToArray());
                    }
                }

                // Dessiner la légende avec le nouvel arrangement
                int x = legendeX + (colonneActuelle * espacementHorizontal);
                int y = legendeStartY + (ligneActuelle * espacementVertical);

                using (Brush brush = new SolidBrush(couleurCourbe))
                {
                    graphics.FillRectangle(brush, x, y, 15, 15);
                    graphics.DrawString(cls.Key, legendFont, Brushes.Black, x + 20, y);
                }

                colonneActuelle++;
                if (colonneActuelle >= nombreClassesParLigne)
                {
                    colonneActuelle = 0;
                    ligneActuelle++;
                }

                couleurIndex++;
            }

            // Ajouter le titre
            using (Font titleFont = new Font("Arial", 16, FontStyle.Bold))
            {
                string nomNiveauPropre = niveau.nomDuNiveau.Trim().Replace("\u0000", "");
                string titre = $"Courbes de Gauss - Niveau {nomNiveauPropre}";
                graphics.DrawString(titre, titleFont, Brushes.Black, graphBounds.Left, graphBounds.Top - 35);
            }
        }

        private void DessinerCourbeGaussReduite(Graphics graphics, Rectangle bounds, List<int> notes, Color couleur)
        {
            if (notes.Count < 5) return;

            double moyenne = notes.Average();
            double variance = notes.Sum(note => Math.Pow(note - moyenne, 2)) / notes.Count;
            double ecartType = Math.Sqrt(variance);

            List<PointF> points = new List<PointF>();
            for (double x = 1; x <= 7; x += 0.1) // Étendu à 7 points au lieu de 5
            {
                double z = (x - moyenne) / ecartType;
                double y = (1.0 / (ecartType * Math.Sqrt(2 * Math.PI))) * Math.Exp(-(z * z) / 2.0);

                float pixelX = bounds.Left + (float)((x - 1) / 6.0 * bounds.Width); // Ajusté pour 7 points
                float pixelY = bounds.Bottom - (float)(y * bounds.Height * 2.5); // Facteur d'échelle ajusté

                points.Add(new PointF(pixelX, pixelY));
            }

            if (points.Count > 1)
            {
                using (Pen courbePen = new Pen(couleur, 1.5f))
                {
                    graphics.DrawLines(courbePen, points.ToArray());
                }
            }
        }

        private void DessinerCourbeGauss(Graphics graphics, Rectangle bounds, List<int> notes, Color couleur)
        {
            if (notes.Count < 5) return;

            double moyenne = notes.Average();
            double variance = notes.Sum(note => Math.Pow(note - moyenne, 2)) / notes.Count;
            double ecartType = Math.Sqrt(variance);

            List<PointF> points = new List<PointF>();
            for (double x = 1; x <= 7; x += 0.1)
            {
                double z = (x - moyenne) / ecartType;
                double y = (1.0 / (ecartType * Math.Sqrt(2 * Math.PI))) * Math.Exp(-(z * z) / 2.0);

                float pixelX = bounds.Left + (float)((x - 1) / 6.0 * bounds.Width);
                float pixelY = bounds.Bottom - (float)(y * bounds.Height * 3);

                points.Add(new PointF(pixelX, pixelY));
            }

            if (points.Count > 1)
            {
                using (Pen courbePen = new Pen(couleur, 1.5f))
                {
                    graphics.DrawLines(courbePen, points.ToArray());
                }
            }
        }

        private void DessinerCourbeGauss(Graphics graphics, Rectangle bounds, List<int> notes, string nomClasse)
        {
            if (notes.Count < 5) return;

            double moyenne = notes.Average();
            double variance = notes.Sum(note => Math.Pow(note - moyenne, 2)) / notes.Count;
            double ecartType = Math.Sqrt(variance);
            string moyenneLettre = ConvertMoyenneToLetter(moyenne);

            int largeurCourbe = 400;
            int hauteurCourbe = 150;
            int margeX = 1;
            int margeY = 5;

            Rectangle zoneCourbe = new Rectangle(
                bounds.Left + margeX + 50,
                bounds.Top + margeY - 100,
                largeurCourbe,
                hauteurCourbe
            );

            using (Font titleFont = new Font("Arial", 11, FontStyle.Bold))
            {
                string titre = $"Courbe de Gauss {nomClasse}\nMoyenne: {moyenneLettre}, Écart type: {ecartType:F2}";
                graphics.DrawString(titre, titleFont, Brushes.Black,
                    zoneCourbe.Width - 400, zoneCourbe.Top - 180);
            }

            using (Pen axePen = new Pen(Color.Black, 1))
            {
                graphics.DrawLine(axePen,
                    zoneCourbe.Left, zoneCourbe.Bottom,
                    zoneCourbe.Right, zoneCourbe.Bottom);
                graphics.DrawLine(axePen,
                    zoneCourbe.Left, zoneCourbe.Top,
                    zoneCourbe.Left, zoneCourbe.Bottom);
            }

            string[] labels = { "E", "D", "C", "B", "A", " ", " " };
            float stepX = zoneCourbe.Width / (labels.Length - 1);

            using (Font axisFont = new Font("Arial", 10))
            {
                for (int i = 0; i < labels.Length; i++)
                {
                    float x = zoneCourbe.Left + (i * stepX);
                    if (i < 5)
                    {
                        graphics.DrawLine(Pens.Black, x, zoneCourbe.Bottom, x, zoneCourbe.Bottom + 3);
                        graphics.DrawString(labels[i], axisFont, Brushes.Black,
                            x - 3, zoneCourbe.Bottom + 3);
                    }
                }
            }

            List<PointF> points = new List<PointF>();
            for (double x = 1; x <= 7; x += 0.1)
            {
                double z = (x - moyenne) / ecartType;
                double y = (1.0 / (ecartType * Math.Sqrt(2 * Math.PI))) * Math.Exp(-(z * z) / 2.0);

                float pixelX = zoneCourbe.Left + (float)((x - 1) / 6.0 * zoneCourbe.Width);
                float pixelY = zoneCourbe.Bottom - (float)(y * hauteurCourbe * 3);

                points.Add(new PointF(pixelX, pixelY));
            }

            if (points.Count > 1)
            {
                using (Pen courbePen = new Pen(Color.Blue, 1.5f))
                {
                    graphics.DrawLines(courbePen, points.ToArray());
                }

                // Ajout de la ligne rouge pour la moyenne
                float moyenneX = zoneCourbe.Left + (float)((moyenne - 1) / 6.0 * zoneCourbe.Width);
                using (Pen moyennePen = new Pen(Color.Red, 1.5f))
                {
                    graphics.DrawLine(moyennePen,
                        moyenneX, zoneCourbe.Top,
                        moyenneX, zoneCourbe.Bottom);
                }
            }
        }

        public void PrintFichesEnT(object sender, PrintPageEventArgs e)
        {
            // Marges et dimensions
            int margeGauche = (int)e.MarginBounds.Left;
            int margeHaut = (int)e.MarginBounds.Top;
            int largeurFiche = 140;
            int hauteurFiche = 70;
            int espaceEntreFiches = 15;
            int espaceEntreLignes = 15;

            int positionX = margeGauche;
            int positionY = margeHaut;

            // Hauteur de la légende et de la courbe
            int hauteurLegende = 80;
            int hauteurCourbe = 140;
            int espacementCourbeLegende = 25; // Espacement entre la courbe et la légende

            // Utilisation des variables membres
            int limiteBasFiches = e.MarginBounds.Bottom - this.hauteurLegende - this.hauteurCourbe - this.espacementCourbeLegende;

            // Variables pour stocker les notes de la classe actuelle
            List<int> notesClasseActuelle = new List<int>();
            string nomClasseActuelle = "";

            // Vérifier si nous devons ajouter la page blanche
            if (ajouterPageBlanche)
            {
                e.Graphics.Clear(Color.White); // Effacer la page avec un fond blanc
                e.HasMorePages = false; // Indiquer qu'il n'y a plus de pages à imprimer
                ajouterPageBlanche = false; // Réinitialiser l'indicateur
                return;
            }

            Graphics graphics = e.Graphics;

            // Phase 1 : Impression des fiches élèves
            if (!impressionFichesElevesTerminee)
            {
                // Boucle sur les niveaux et classes
                foreach (Niveau niv in Global.lesNiveaux.Skip(Global.indexNiveau))
                {
                    foreach (Classe cls in niv.getLesClasse().Skip(Global.indexClasse))
                    {
                        notesClasseActuelle.Clear();
                        nomClasseActuelle = cls.nomDeLaClasse;

                        // Déterminer la couleur de fond pour ce niveau
                        Color couleurNiveau = Color.Gray;
                        switch (cls.nomDeLaClasse.First())
                        {
                            case '6': couleurNiveau = Color.FromArgb(253, 255, 157); break;
                            case '5': couleurNiveau = Color.FromArgb(188, 255, 159); break;
                            case '4': couleurNiveau = Color.FromArgb(235, 194, 154); break;
                            case '3': couleurNiveau = Color.FromArgb(156, 225, 236); break;
                        }

                        // Afficher un titre pour la classe
                        graphics.DrawString(cls.nomDeLaClasse, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, positionX, positionY);
                        positionY += 30;

                        foreach (Eleve elv in cls.getLesEleves().OrderBy(elv => elv.nomEleve))
                        {
                            if (elv.dateSortie == default)
                            {
                                // Collecter les notes pour la courbe de Gauss
                                if (elv.rdbNiveau != null)
                                {
                                    switch (elv.rdbNiveau.Name)
                                    {
                                        case "rdbA": notesClasseActuelle.Add(5); break;
                                        case "rdbB": notesClasseActuelle.Add(4); break;
                                        case "rdbC": notesClasseActuelle.Add(3); break;
                                        case "rdbD": notesClasseActuelle.Add(2); break;
                                        case "rdbE": notesClasseActuelle.Add(1); break;
                                    }
                                }

                                // Vérifier si on atteint la limite pour les fiches
                                if (positionY + hauteurFiche > limiteBasFiches)
                                {
                                    // Dessiner la courbe et la légende avant de passer à la page suivante
                                    if (notesClasseActuelle.Count >= 5)
                                    {
                                        Rectangle courbesBounds = new Rectangle(
                                            margeGauche,
                                            e.MarginBounds.Bottom - hauteurLegende - hauteurCourbe - espacementCourbeLegende,
                                            e.MarginBounds.Width,
                                            hauteurCourbe
                                        );
                                        DessinerCourbeGauss(graphics, courbesBounds, notesClasseActuelle, nomClasseActuelle);
                                    }
                                    DessinerLegende(graphics, e.MarginBounds);

                                    e.HasMorePages = true;
                                    return;
                                }

                                // Dessiner la fiche de l'élève
                                Rectangle rectFiche = new Rectangle(positionX, positionY, largeurFiche, hauteurFiche);
                                using (Brush brush = new SolidBrush(couleurNiveau))
                                {
                                    graphics.FillRectangle(brush, rectFiche);
                                }
                                graphics.DrawRectangle(Pens.Black, rectFiche);

                                // Ajouter les informations de l'élève
                                graphics.DrawString(elv.nomEleve.ToUpper(), new Font("Arial", 6, FontStyle.Bold), Brushes.Black, positionX + 5, positionY + 5);
                                graphics.DrawString(elv.prenomEleve, new Font("Arial", 7), Brushes.Black, positionX + 5, positionY + 25);

                                // Dessiner les rectangles pour les options
                                int couleurX = positionX + 5;
                                int couleurY = positionY + 50;
                                int rectangleWidth = 30;
                                int rectangleHeight = 10;
                                int espaceEntreRectangles = 10;

                                if (elv.LV1 != null && elv.LV1.couleur != default)
                                {
                                    using (Brush optionBrush = new SolidBrush(elv.LV1.couleur))
                                    {
                                        graphics.FillRectangle(optionBrush, couleurX, couleurY, rectangleWidth, rectangleHeight);
                                    }
                                    couleurX += rectangleWidth + espaceEntreRectangles;
                                }

                                if (elv.option1 != null && elv.option1.couleur != default)
                                {
                                    using (Brush optionBrush = new SolidBrush(elv.option1.couleur))
                                    {
                                        graphics.FillRectangle(optionBrush, couleurX, couleurY, rectangleWidth, rectangleHeight);
                                    }
                                    couleurX += rectangleWidth + espaceEntreRectangles;
                                }

                                if (elv.option2 != null && elv.option2.couleur != default)
                                {
                                    using (Brush optionBrush = new SolidBrush(elv.option2.couleur))
                                    {
                                        graphics.FillRectangle(optionBrush, couleurX, couleurY, rectangleWidth, rectangleHeight);
                                    }
                                }

                                positionX += largeurFiche + espaceEntreFiches;

                                if (positionX + largeurFiche > e.MarginBounds.Right)
                                {
                                    positionX = margeGauche;
                                    positionY += hauteurFiche + espaceEntreLignes;
                                }
                            }
                        }

                        if (notesClasseActuelle.Count >= 5)
                        {
                            Rectangle courbesBounds = new Rectangle(
                                margeGauche,
                                e.MarginBounds.Bottom - this.hauteurLegende - this.hauteurCourbe - this.espacementCourbeLegende,
                                e.MarginBounds.Width,
                                this.hauteurCourbe
                            );
                            DessinerCourbeGauss(graphics, courbesBounds, notesClasseActuelle, nomClasseActuelle);
                            DessinerStatistiques(graphics, courbesBounds, cls);

                        }
                        DessinerLegende(graphics, e.MarginBounds);

                        Global.indexClasse++;
                        if (Global.indexClasse < niv.getLesClasse().Count)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                    }

                    Global.indexClasse = 0;
                    Global.indexNiveau++;
                    if (Global.indexNiveau < Global.lesNiveaux.Count)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }
            }

            // Après avoir traité toutes les classes et niveaux :
            if (Global.indexNiveau >= Global.lesNiveaux.Count)
            {
                impressionFichesElevesTerminee = true; // Passer à la phase 2
                Global.indexNiveau = 0; // Réinitialiser l'index pour les graphiques
                e.HasMorePages = true; // Indiquer qu'il y a des pages supplémentaires
                return;
            }

            // Phase 2 : Impression des graphiques des courbes de Gauss
            else
            {
                // Vérifier que l'index est dans les limites
                if (Global.indexNiveau >= 0 && Global.indexNiveau < Global.lesNiveaux.Count)
                {
                    Niveau niveauActuel = Global.lesNiveaux[Global.indexNiveau];

                    // Augmenter significativement la hauteur du rectangle pour le graphique
                    int hauteurGraphique = (int)(e.MarginBounds.Height * 0.8); // Utiliser 80% de la hauteur disponible
                    Rectangle bounds = new Rectangle(
                        e.MarginBounds.Left,
                        e.MarginBounds.Top + 50, // Réduire la marge supérieure
                        e.MarginBounds.Width,
                        hauteurGraphique
                    );

                    // Dessiner les courbes pour le niveau actuel
                    DessinerCourbesPourNiveau(e.Graphics, bounds, niveauActuel);

                    // Passer au niveau suivant
                    Global.indexNiveau++;

                    // Vérifier s'il reste des niveaux à traiter
                    if (Global.indexNiveau < Global.lesNiveaux.Count)
                    {
                        e.HasMorePages = true; // Continuer avec le niveau suivant
                    }
                    else
                    {
                        e.HasMorePages = false; // Terminer l'impression
                    }
                }
                else
                {
                    e.HasMorePages = false; // Terminer l'impression en cas d'erreur
                }
            }
        }

        private void DessinerStatistiques(Graphics graphics, Rectangle bounds, Classe classe)
        {
            // Position de départ pour les statistiques (à droite de la courbe)
            int startX = bounds.Left + 460;
            int startY = bounds.Bottom - this.hauteurLegende - this.hauteurCourbe - 200; // Utilisation des membres
            Font statsFont = new Font("Arial", 10);
            Font titleFont = new Font("Arial", 14, FontStyle.Bold);
            int lineHeight = 40;

            graphics.DrawString("Statistiques de la classe", titleFont, Brushes.Black, startX, startY);
            startY += (int)(lineHeight * 1.5); // Conversion explicite de float en int

            // Calculer les statistiques
            var lesEleves = classe.getLesEleves();
            int nbTotEleve = 0;
            int nbFille = 0, nbGarcon = 0;
            int nbNiveauA = 0, nbNiveauB = 0, nbNiveauC = 0, nbNiveauD = 0, nbNiveauE = 0;
            int nbLatin = 0, nbEspagnol = 0, nbAllemand = 0, nbAnglaisLv2 = 0;
            int nbBilingue = 0, nbSegpa = 0, nbUPE2A = 0, nbUlis = 0;

            foreach (Eleve eleve in lesEleves)
            {
                if (eleve.dateSortie == default) // Ne compter que les élèves actifs
                {
                    nbTotEleve++;

                    // Compter par genre
                    if (eleve.sexeEleve == "H") nbGarcon++;
                    else if (eleve.sexeEleve == "F") nbFille++;

                    // Compter par niveau
                    if (eleve.rdbNiveau != null)
                    {
                        switch (eleve.rdbNiveau.Name)
                        {
                            case "rdbA": nbNiveauA++; break;
                            case "rdbB": nbNiveauB++; break;
                            case "rdbC": nbNiveauC++; break;
                            case "rdbD": nbNiveauD++; break;
                            case "rdbE": nbNiveauE++; break;
                        }
                    }

                    // Compter les options
                    if (eleve.LV1Eleve == "Bilingue") nbBilingue++;

                    if (eleve.option1Eleve == "Upe2a") nbUPE2A++;
                    else if (eleve.option1Eleve == "Ulis") nbUlis++;
                    else if (eleve.option1Eleve == "Segpa") nbSegpa++;
                    else if (eleve.option1Eleve.Contains("Angl")) nbAnglaisLv2++;
                    else if (eleve.option1Eleve.Contains("All")) nbAllemand++;
                    else if (eleve.option1Eleve.Contains("Esp")) nbEspagnol++;

                    if (eleve.option2Eleve == "Latin") nbLatin++;
                }
            }

            // Afficher les statistiques
            var statsList = new List<(string label, int value)>
    {
        ("Elèves totaux", nbTotEleve),
        ("Filles", nbFille),
        ("Garçons", nbGarcon),
        ("Niveau A", nbNiveauA),
        ("Niveau B", nbNiveauB),
        ("Niveau C", nbNiveauC),
        ("Niveau D", nbNiveauD),
        ("Niveau E", nbNiveauE),
        ("Bilingue", nbBilingue),
        ("Latin", nbLatin),
        ("Allemand", nbAllemand),
        ("Espagnol", nbEspagnol),
        ("Anglais LV2", nbAnglaisLv2),
        ("SEGPA", nbSegpa),
        ("ULIS", nbUlis),
        ("UPE2A", nbUPE2A)
    };

            // Organiser en deux colonnes
            int colWidth = 200;
            int midPoint = statsList.Count / 2;

            // Pour les conversions float en int dans les calculs de position
            for (int i = 0; i < midPoint; i++)
            {
                var stat1 = statsList[i];
                graphics.DrawString($"{stat1.label}: {stat1.value}", statsFont, Brushes.Black,
                    startX, (float)startY + (i * lineHeight)); // Cast explicite si nécessaire

                if (i + midPoint < statsList.Count)
                {
                    var stat2 = statsList[i + midPoint];
                    graphics.DrawString($"{stat2.label}: {stat2.value}", statsFont, Brushes.Black,
                        startX + colWidth, (float)startY + (i * lineHeight)); // Cast explicite si nécessaire
                }
            }
        }

        public void DessinerLegende(Graphics graphics, Rectangle marginBounds)
        {
            float legendeX = marginBounds.Left;
            float legendeY = marginBounds.Bottom - 80;
            Font legendeFont = new Font("Arial", 10, FontStyle.Bold);

            Dictionary<string, Color> optionsNormalisees = new Dictionary<string, Color>();

            int largeurDisponible = marginBounds.Right - marginBounds.Left;
            int nombreOptionsParLigne = largeurDisponible / 120;
            float espacementHorizontal = largeurDisponible / (float)nombreOptionsParLigne;

            float couleurX = legendeX;
            float couleurY = legendeY;
            int compteurOptions = 0;

            string NormaliserNomOption(string nomOption)
            {
                if (string.IsNullOrEmpty(nomOption) || nomOption == "Aucune") return "";

                if (nomOption.Contains("Allemand")) return "Allemand";
                if (nomOption.Contains("Anglais")) return "Anglais";
                if (nomOption.Contains("Espagnol")) return "Espagnol";
                return nomOption;
            }

            // Parcourir tous les élèves pour collecter les options
            foreach (var eleve in Global.elevesValides)
            {
                if (eleve.dateSortie == default)
                {
                    // Vérifier que la couleur n'est pas transparente avant d'ajouter l'option
                    if (eleve.LV1 != null && !string.IsNullOrEmpty(eleve.LV1.nomOption) && eleve.LV1.couleur.A != 0)
                    {
                        string nomNormalise = NormaliserNomOption(eleve.LV1.nomOption);
                        if (!string.IsNullOrEmpty(nomNormalise))
                        {
                            optionsNormalisees[nomNormalise] = eleve.LV1.couleur;
                        }
                    }

                    if (eleve.option1 != null && !string.IsNullOrEmpty(eleve.option1.nomOption) && eleve.option1.couleur.A != 0)
                    {
                        string nomNormalise = NormaliserNomOption(eleve.option1.nomOption);
                        if (!string.IsNullOrEmpty(nomNormalise))
                        {
                            optionsNormalisees[nomNormalise] = eleve.option1.couleur;
                        }
                    }

                    if (eleve.option2 != null && !string.IsNullOrEmpty(eleve.option2.nomOption) && eleve.option2.couleur.A != 0)
                    {
                        string nomNormalise = NormaliserNomOption(eleve.option2.nomOption);
                        if (!string.IsNullOrEmpty(nomNormalise))
                        {
                            optionsNormalisees[nomNormalise] = eleve.option2.couleur;
                        }
                    }
                }
            }

            var optionsTriees = optionsNormalisees
                .OrderBy(kvp => kvp.Key)
                .ToList();

            foreach (var option in optionsTriees)
            {
                using (Brush brush = new SolidBrush(option.Value))
                {
                    graphics.FillRectangle(brush, couleurX, couleurY, 30, 18);
                }

                graphics.DrawString(option.Key, legendeFont, Brushes.Black, couleurX + 35, couleurY);

                compteurOptions++;

                if (compteurOptions >= nombreOptionsParLigne)
                {
                    couleurX = legendeX;
                    couleurY += 25;
                    compteurOptions = 0;
                }
                else
                {
                    couleurX += espacementHorizontal;
                }
            }
        }
    }
}
